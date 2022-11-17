using Core.Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Website.Application.Features.Categories.Commands.CreateCategory;
using Website.Application.Features.Categories.Commands.DeleteCategory;
using Website.Application.Features.Categories.Commands.UpdateCategory;
using Website.Application.Features.Categories.Dtos;
using Website.Application.Features.Categories.Models;
using Website.Application.Features.Categories.Queries.GetByIdCategory;
using Website.Application.Features.Categories.Queries.GetListCategory;

namespace Website.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQuery getByIdCategoryQuery)
        {
            CategoryDto result = await Mediator.Send(getByIdCategoryQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCategoryQuery getListCategoryQuery = new() { PageRequest = pageRequest };
            CategoryListModel result = await Mediator.Send(getListCategoryQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreatedCategoryDto result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            UpdatedCategoryDto result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            DeletedCategoryDto result = await Mediator.Send(deleteCategoryCommand);
            return Ok(result);
        }
    }
}
