

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N5Challenge.Domain.Entities;
using N5Challenge.Mediator.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("api/permissions-type")]
    public class PermissionsTypeController : ControllerBase
    {
        private readonly ILogger<PermissionsTypeController> logger;
        private readonly IMediator mediator;

        public PermissionsTypeController(ILogger<PermissionsTypeController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("get-permissions-type")]
        public async Task<IActionResult> GetPermissionsType()
        {
            try
            {
                List<PermissionType> permissions = await mediator.Send(new GetPermissionTypeListQuery());
                return Ok(permissions);
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }       
    }
}
