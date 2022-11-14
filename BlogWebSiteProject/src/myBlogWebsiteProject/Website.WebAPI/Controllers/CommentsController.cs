using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.Comments.Commands.CreateComment;
using Website.Application.Features.Comments.Commands.DeleteComment;
using Website.Application.Features.Comments.Commands.UpdateComment;
using Website.Application.Features.Comments.Dtos;
using Website.Application.Features.Comments.Models;
using Website.Application.Features.Comments.Queries.GetByIdComment;
using Website.Application.Features.Comments.Queries.GetListComment;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : BaseController
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCommentQuery getByIdCommentQuery)
        {
            CommentDto result = await Mediator.Send(getByIdCommentQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCommentQuery getListCommentQuery = new() { PageRequest = pageRequest };
            CommentListModel result = await Mediator.Send(getListCommentQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCommentCommand createCommentCommand)
        {
            CreatedCommentDto result = await Mediator.Send(createCommentCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCommentCommand updateCommentCommand)
        {
            UpdatedCommentDto result = await Mediator.Send(updateCommentCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCommentCommand deleteCommentCommand)
        {
            DeletedCommentDto result = await Mediator.Send(deleteCommentCommand);
            return Ok(result);
        }
    }
}
