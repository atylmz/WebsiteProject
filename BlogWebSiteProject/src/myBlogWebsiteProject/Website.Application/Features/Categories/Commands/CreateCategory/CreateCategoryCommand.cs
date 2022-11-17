using AutoMapper;
using MediatR;
using Website.Application.Features.Categories.Dtos;
using Website.Application.Features.Categories.Rules;
using Website.Application.Services.CategoryService;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Categories.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreatedCategoryDto>, ISecuredRequest
    {
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public string[] Roles => new[] {Admin, CategoryAdd};

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreatedCategoryDto>
        {
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _ruleBusinessRules;

            public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, CategoryBusinessRules ruleBusinessRules)
            {
                _categoryService = categoryService;
                _mapper = mapper;
                _ruleBusinessRules = ruleBusinessRules;
            }

            public async Task<CreatedCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _ruleBusinessRules.CategoryTitleShouldNotBeExist(request.Title);
                if(request.ParentId != 0)
                    await _ruleBusinessRules.CategoryShouldBeExistWhenInsertSubCategory(request.ParentId);


                Category mappedCategory = _mapper.Map<Category>(request);
                Category addedCategory =await _categoryService.CreateCategory(mappedCategory);
                CreatedCategoryDto createdCategoryDto = _mapper.Map<CreatedCategoryDto>(addedCategory);

                return createdCategoryDto;
            }
        }
    }
}
