using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.Authors.Commands.CreateAuthor;
using Website.Application.Features.Authors.Commands.DeleteAuthor;
using Website.Application.Features.Authors.Commands.UpdateAuthor;
using Website.Application.Features.Authors.Dtos;
using Website.Application.Features.Authors.Models;
using Website.Application.Features.Authors.Queries.GetByIdAuthor;
using Website.Application.Features.Authors.Queries.GetListAuthor;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdAuthorQuery getByIdAuthorQuery)
        {
            AuthorDto result = await Mediator.Send(getByIdAuthorQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListAuthorQuery getListAuthorQuery = new() { PageRequest = pageRequest };
            AuthorListModel result = await Mediator.Send(getListAuthorQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAuthorCommand createAuthorCommand)
        {
            CreatedAuthorDto result = await Mediator.Send(createAuthorCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAuthorCommand updateAuthorCommand)
        {
            UpdatedAuthorDto result = await Mediator.Send(updateAuthorCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteAuthorCommand deleteAuthorCommand)
        {
            DeletedAuthorDto result = await Mediator.Send(deleteAuthorCommand);
            return Ok(result);
        }
    }
}
