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

namespace Website.Application.Features.Categories.Queries.GetByIdCategory
{
    public class GetByIdCategoryQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }

        public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQuery, CategoryDto>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly CategoryBusinessRules _categoryBusinessRules;

            public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
                _categoryBusinessRules = categoryBusinessRules;
            }

            public async Task<CategoryDto> Handle(GetByIdCategoryQuery request, CancellationToken cancellationToken)
            {
                Category? category = await _categoryRepository.GetAsync(x=>x.Id == request.Id);

                await _categoryBusinessRules.CategoryShouldBeExistWhenDelete(category);

                CategoryDto categoryDto = _mapper.Map<CategoryDto>(category);

                return categoryDto;
            }
        }
    }
}
