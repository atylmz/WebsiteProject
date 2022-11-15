using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.ArticleCategories.Commands.CreateArticleCategory;
using Website.Application.Features.ArticleCategories.Commands.DeleteArticleCategory;
using Website.Application.Features.ArticleCategories.Commands.UpdateArticleCategory;
using Website.Application.Features.ArticleCategories.Dtos;
using Website.Application.Features.ArticleCategories.Models;
using Website.Application.Features.ArticleCategories.Queries.GetByIdArticleCategory;
using Website.Application.Features.ArticleCategories.Queries.GetListArticleCategory;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleCategoriesController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdArticleCategoryQuery getByIdArticleCategoryQuery)
        {
            ArticleCategoryDto result = await Mediator.Send(getByIdArticleCategoryQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListArticleCategoryQuery getListArticleCategoryQuery = new() { PageRequest = pageRequest };
            ArticleCategoryListModel result = await Mediator.Send(getListArticleCategoryQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateArticleCategoryCommand createArticleCategoryCommand)
        {
            CreatedArticleCategoryDto result = await Mediator.Send(createArticleCategoryCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateArticleCategoryCommand updateArticleCategoryCommand)
        {
            UpdatedArticleCategoryDto result = await Mediator.Send(updateArticleCategoryCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteArticleCategoryCommand deleteArticleCategoryCommand)
        {
            DeletedArticleCategoryDto result = await Mediator.Send(deleteArticleCategoryCommand);
            return Ok(result);
        }
    }
}
