using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Tags.Contants;
using Website.Application.Services.Repositories;
using Website.Domain.Entites;

namespace Website.Application.Features.Tags.Rules
{
    public class TagBusinessRules : BaseBusinessRules
    {
        private readonly ITagRepository _tagRepository;

        public TagBusinessRules(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task TagTitleShouldNotBeExistWhenCreate(string title)
        {
            Domain.Entites.Tag? tag =await _tagRepository.GetAsync(x => x.Title == title);
            if (tag is not null) 
                throw new BusinessException(TagMessages.TagTitleShouldNotBeExist);
        }

        public async Task TagTitleShouldNotBeExistWhenUpdate(string title)
        {
            Domain.Entites.Tag? tag = await _tagRepository.GetAsync(x => x.Title == title);
            if (tag is not null)
                throw new BusinessException(TagMessages.TagTitleShouldNotBeExist);
        }

        public async Task TagShouldBeExistWhenUpdate(int id)
        {
            Tag? tag = await _tagRepository.GetAsync(x => x.Id == id);
            if (tag is null)
                throw new BusinessException(TagMessages.TagShoulBeExist);
        }

        public async Task TagShouldBeExistWhenSelected(int id)
        {
            Tag? tag = await _tagRepository.GetAsync(x => x.Id == id);
            if (tag is null)
                throw new BusinessException(TagMessages.TagShoulBeExist);
        }
    }
}
