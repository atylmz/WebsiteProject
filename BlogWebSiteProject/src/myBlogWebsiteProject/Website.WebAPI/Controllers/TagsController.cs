using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.Tags.Commands.CreateTag;
using Website.Application.Features.Tags.Commands.DeleteTag;
using Website.Application.Features.Tags.Commands.UpdateTag;
using Website.Application.Features.Tags.Dtos;
using Website.Application.Features.Tags.Models;
using Website.Application.Features.Tags.Queries.GetByIdTag;
using Website.Application.Features.Tags.Queries.GetListTag;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdTagQuery getByIdTagQuery)
        {
            TagDto result = await Mediator.Send(getByIdTagQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTagQuery getListTagQuery = new() { PageRequest = pageRequest };
            TagListModel result = await Mediator.Send(getListTagQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTagCommand createTagCommand)
        {
            CreatedTagDto result = await Mediator.Send(createTagCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTagCommand deleteTagCommand)
        {
            DeletedTagDto result = await Mediator.Send(deleteTagCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTagCommand updateTagCommand)
        {
            UpdatedTagDto result = await Mediator.Send(updateTagCommand);
            return Ok(result);
        }
    }
}
