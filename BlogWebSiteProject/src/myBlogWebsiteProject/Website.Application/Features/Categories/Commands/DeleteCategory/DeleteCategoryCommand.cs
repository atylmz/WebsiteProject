using AutoMapper;
using MediatR;
using Website.Application.Features.Categories.Dtos;
using Website.Application.Features.Categories.Rules;
using Website.Application.Services.CategoryService;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;
using static Website.Domain.Constants.OperationClaims;
using static Website.Application.Features.Categories.Constants.OperationClaims;
using Core.Application.Pipelines.Authorization;

namespace Website.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<DeletedCategoryDto>, ISecuredRequest
    {
        public int Id { get; set; }

        public string[] Roles => new[] { Admin, CategoryDelete };

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeletedCategoryDto>
        {
            private readonly ICategoryService _categoryService;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;
            private readonly ICategoryRepository _categoryRepository;

            public DeleteCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, CategoryBusinessRules categoryBusinessRules, ICategoryRepository categoryRepository)
            {
                _categoryService = categoryService;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
                _categoryRepository = categoryRepository;
            }

            public async Task<DeletedCategoryDto> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryShouldBeExistWhenDelete(request.Id);

                Category mappedCategory = _mapper.Map<Category>(request);
                Category deletedCategory = await _categoryService.DeleteCategory(mappedCategory);
                DeletedCategoryDto deletedCategoryDto = _mapper.Map<DeletedCategoryDto>(deletedCategory);

                return deletedCategoryDto;
            }
        }
    }
}
