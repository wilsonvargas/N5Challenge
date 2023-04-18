

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N5Challenge.Domain.Entities;
using N5Challenge.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("api/permissions-type")]
    public class PermissionsTypeController : ControllerBase
    {
        private readonly ILogger<PermissionsTypeController> logger;
        private readonly IUnitOfWork unitOfWork;

        public PermissionsTypeController(ILogger<PermissionsTypeController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-permissions-type")]
        public async Task<IActionResult> GetPermissionsType()
        {
            try
            {
                List<PermissionType> permissions = await unitOfWork.PermissionsTypeRepository.List();
                return Ok(permissions);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }       
    }
}
