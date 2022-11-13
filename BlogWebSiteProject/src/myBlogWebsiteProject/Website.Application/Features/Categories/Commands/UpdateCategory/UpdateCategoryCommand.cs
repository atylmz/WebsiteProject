using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Categories.Dtos;
using Website.Application.Features.Categories.Rules;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<UpdatedCategoryDto>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdatedCategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<UpdatedCategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                await _categoryBusinessRules.CategoryTitleShouldNotBeExist(request.Title);
                await _categoryBusinessRules.CategoryShouldBeExistWhenUpdate(request.Id);

                Category mappedCategory = _mapper.Map<Category>(request);
                Category updatedCategory = await _categoryRepository.UpdateAsync(mappedCategory);
                UpdatedCategoryDto updatedCategoryDto = _mapper.Map<UpdatedCategoryDto>(updatedCategory);

                return updatedCategoryDto;
            }
        }
    }
}
