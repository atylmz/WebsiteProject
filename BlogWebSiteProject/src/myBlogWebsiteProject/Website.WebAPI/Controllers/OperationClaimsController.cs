using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Website.Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Website.Application.Features.OperationClaims.Commands.UpdateOperationClaim;
using Website.Application.Features.OperationClaims.Dtos;
using Website.Application.Features.OperationClaims.Models;
using Website.Application.Features.OperationClaims.Queries.GetByIdOperationClaim;
using Website.Application.Features.OperationClaims.Queries.GetListOperationClaim;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
        {
            OperationClaimDto result = await Mediator.Send(getByIdOperationClaimQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
            OperationClaimListModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimCommand deleteOperationClaimCommand)
        {
            DeletedOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(result);
        }
    }
}
