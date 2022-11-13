using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.ArticleMetas.Commands.CreateArticleMeta;
using Website.Application.Features.ArticleMetas.Commands.DeleteArticleMeta;
using Website.Application.Features.ArticleMetas.Commands.UpdateArticleMeta;
using Website.Application.Features.ArticleMetas.Dtos;
using Website.Application.Features.ArticleMetas.Models;
using Website.Application.Features.ArticleMetas.Queries.GetByIdArticleMeta;
using Website.Application.Features.ArticleMetas.Queries.GetListArticleMeta;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleMetaController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdArticleMetaQuery getByIdArticleMetaQuery)
        {
            ArticleMetaDto result = await Mediator.Send(getByIdArticleMetaQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListArticleMetaQuery getListArticleMetaQuery = new() { PageRequest = pageRequest };
            ArticleMetaListModel result = await Mediator.Send(getListArticleMetaQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateArticleMetaCommand createArticleMetaCommand)
        {
            CreatedArticleMetaDto result = await Mediator.Send(createArticleMetaCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateArticleMetaCommand updateArticleMetaCommand)
        {
            UpdatedArticleMetaDto result = await Mediator.Send(updateArticleMetaCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteArticleMetaCommand deleteArticleMetaCommand)
        {
            DeletedArticleMetaDto result = await Mediator.Send(deleteArticleMetaCommand);
            return Ok(result);
        }
    }
}
