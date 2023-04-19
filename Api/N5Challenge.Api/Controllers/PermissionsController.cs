using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using N5Challenge.Api.Contracts;
using N5Challenge.Api.Services;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionsController : ControllerBase
    {
        private readonly ILogger<PermissionsController> logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IElasticSearchService elasticSearchService;

        public PermissionsController(ILogger<PermissionsController> logger,
                                     IUnitOfWork unitOfWork,
                                     IElasticSearchService elasticSearchService)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.elasticSearchService = elasticSearchService;
        }

        [HttpPost]
        [Route("request-permission")]
        public async Task<IActionResult> RequestPermission([FromBody] Permission permission)
        {
            try
            {
                permission.PermissionDate = DateTime.Today;
                await unitOfWork.PermissionsRepository.Add(permission);
                PermissionType permissionType = await unitOfWork.PermissionsTypeRepository.Find(permission.PermissionTypeId);
                elasticSearchService.IndexDocument(
                    new PermissionInformation
                    {
                        Id = permission.Id,
                        EmployeeName = permission.EmployeeName,
                        EmployeeLastName = permission.EmployeeLastName,
                        PermissionDate = permission.PermissionDate,
                        PermissionTypeId = permission.PermissionTypeId,
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
            Permission permissionResult = await unitOfWork.PermissionsRepository.Find(permission.Id);

            if (permissionResult == null)
            {
                return BadRequest("El permiso no existe.");
            }

            try
            {
                PermissionType permissionType = await unitOfWork.PermissionsTypeRepository.Find(permission.PermissionTypeId);
                elasticSearchService.UpdateIndexDocument(
                    new PermissionInformation
                    {
                        Id = permission.Id,
                        EmployeeName = permission.EmployeeName,
                        EmployeeLastName = permission.EmployeeLastName,
                        PermissionDate = permission.PermissionDate,
                        PermissionTypeId = permission.PermissionTypeId,
                        PermissionType = new PermissionTypeInformation { Id = permissionType.Id, Description = permissionType.Description }
                    });
                await unitOfWork.PermissionsRepository.Update(permission);
                return Ok();
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
