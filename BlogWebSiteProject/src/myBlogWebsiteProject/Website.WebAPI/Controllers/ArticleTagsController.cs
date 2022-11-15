using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.ArticleTags.Commands.CreateArticleTag;
using Website.Application.Features.ArticleTags.Commands.DeleteArticleTag;
using Website.Application.Features.ArticleTags.Commands.UpdateArticleTag;
using Website.Application.Features.ArticleTags.Dtos;
using Website.Application.Features.ArticleTags.Models;
using Website.Application.Features.ArticleTags.Queries.GetByIdArticleTag;
using Website.Application.Features.ArticleTags.Queries.GetListArticleTag;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleTagsController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdArticleTagQuery getByIdArticleTagQuery)
        {
            ArticleTagDto result = await Mediator.Send(getByIdArticleTagQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListArticleTagQuery getListArticleTagQuery = new() { PageRequest = pageRequest };
            ArticleTagListModel result = await Mediator.Send(getListArticleTagQuery);
            return Created("", result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateArticleTagCommand createArticleTagCommand)
        {
            CreatedArticleTagDto result = await Mediator.Send(createArticleTagCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateArticleTagCommand updateArticleTagCommand)
        {
            UpdatedArticleTagDto result = await Mediator.Send(updateArticleTagCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteArticleTagCommand deleteArticleTagCommand)
        {
            DeletedArticleTagDto result = await Mediator.Send(deleteArticleTagCommand);
            return Ok(result);
        }

    }
}