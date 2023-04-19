using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using N5Challenge.Api.Contracts;
using N5Challenge.Api.Services;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure;
using MediatR;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using N5Challenge.Mediator.Queries;
using N5Challenge.Mediator.Commands;
using N5Challenge.Api.Contracts.Request;

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionsController : ControllerBase
    {
        private readonly ILogger<PermissionsController> logger;
        private readonly IMediator mediator;
        private readonly IElasticSearchService elasticSearchService;

        public PermissionsController(ILogger<PermissionsController> logger,
                                     IMediator mediator,
                                     IElasticSearchService elasticSearchService)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.elasticSearchService = elasticSearchService;
        }

        [HttpPost]
        [Route("request-permission")]
        public async Task<IActionResult> RequestPermission([FromBody] PermissionRequest permission)
        {
            try
            {
                Permission addedPermission = await mediator.Send(new CreatePermissionCommand(permission.EmployeeName,
                                                                permission.EmployeeLastName,
                                                                permission.PermissionTypeId));

                PermissionType permissionType = await mediator.Send(new GetPermissionTypeByIdQuery() { Id = addedPermission.PermissionTypeId });

                elasticSearchService.IndexDocument(
                    new PermissionInformation
                    {
                        Id = addedPermission.Id,
                        EmployeeName = addedPermission.EmployeeName,
                        EmployeeLastName = addedPermission.EmployeeLastName,
                        PermissionDate = addedPermission.PermissionDate,
                        PermissionTypeId = addedPermission.PermissionTypeId,
                        PermissionType = new PermissionTypeInformation { Id = permissionType.Id, Description = permissionType.Description }
                    });

                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("get-permissions")]
        public async Task<IActionResult> GetPermissions()
        {
            try
            {
                ISearchResponse<PermissionInformation> result = await elasticSearchService.GetAll();
                return Ok(result.Documents.ToList());
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("modify-permission")]
        public async Task<IActionResult> ModifyPermission([FromBody] Permission permission)
        {
            try
            {                
                Permission updatedPermission = await mediator.Send(new UpdatePermissionCommand(permission.Id,
                                                                permission.EmployeeName,
                                                                permission.EmployeeLastName,
                                                                permission.PermissionTypeId));

                PermissionType permissionType = await mediator.Send(new GetPermissionTypeByIdQuery() { Id = updatedPermission.PermissionTypeId });

                elasticSearchService.UpdateIndexDocument(
                    new PermissionInformation
                    {
                        Id = updatedPermission.Id,
                        EmployeeName = updatedPermission.EmployeeName,
                        EmployeeLastName = updatedPermission.EmployeeLastName,
                        PermissionDate = updatedPermission.PermissionDate,
                        PermissionTypeId = updatedPermission.PermissionTypeId,
                        PermissionType = new PermissionTypeInformation { Id = permissionType.Id, Description = permissionType.Description }
                    });                
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
