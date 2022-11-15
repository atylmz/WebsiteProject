using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.Articles.Commands.CreateArticle;
using Website.Application.Features.Articles.Commands.DeleteArticle;
using Website.Application.Features.Articles.Commands.UpdateArticle;
using Website.Application.Features.Articles.Dtos;
using Website.Application.Features.Articles.Models;
using Website.Application.Features.Articles.Queries.GetByIdArticle;
using Website.Application.Features.Articles.Queries.GetListArticle;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdArticleQuery getByIdArticleQuery)
        {
            ArticleDto result = await Mediator.Send(getByIdArticleQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListArticleQuery getListArticleQuery = new() { PageRequest = pageRequest };
            ArticleListModel result = await Mediator.Send(getListArticleQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateArticleCommand createArticleCommand)
        {
            CreatedArticleDto result = await Mediator.Send(createArticleCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateArticleCommand updateArticleCommand)
        {
            UpdatedArticleDto result = await Mediator.Send(updateArticleCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteArticleCommand deleteArticleCommand)
        {
            DeletedArticleDto result = await Mediator.Send(deleteArticleCommand);
            return Ok(result);
        }
    }
}
