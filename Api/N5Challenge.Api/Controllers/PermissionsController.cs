using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using N5Challenge.Domain;
using N5Challenge.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionsController : ControllerBase
    {
        private readonly ILogger<PermissionsController> logger;
        private readonly IUnitOfWork unitOfWork;

        public PermissionsController(ILogger<PermissionsController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        [Route("request-permission")]
        public async Task<IActionResult> RequestPermission([FromBody] Permission permission)
        {
            try
            {
                await unitOfWork.PermissionsRepository.Add(permission);
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
                List<Permission> permissions = await unitOfWork.PermissionsRepository.List(include: x => x.Include(p => p.PermissionType));
                return Ok(permissions);
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
