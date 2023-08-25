using JRChallenge.API.DTO;
using JRChallenge.Application.Permission.Commands;
using JRChallenge.Application.Permission.Queries;
using JRChallenge.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JRChallengeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator mediator;
        public PermissionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Permissions>> Get()
        {
            return await mediator.Send(new GetPermissions());
        }


        [HttpGet("{id}")]
        public async Task<Permissions> GetPermissionById(long id)
        {
          return await mediator.Send(new GetPermissionById() { Id = id });
        }

        [HttpPut]
        public async Task<ActionResult> ModifyPermission([FromBody] PermissionDTO permision)
        {
           await mediator.Send(new UpdatePermission()
            {
                Id = permision.Id,
                Name = permision.Name,
                SurName = permision.SurName,
                PermissionDate = permision.PermissionDate,
                Type = new PermissionTypes() { Id = permision.PermissionTypeId }
            });

            return StatusCode((int)HttpStatusCode.NoContent);
        }
    }
}