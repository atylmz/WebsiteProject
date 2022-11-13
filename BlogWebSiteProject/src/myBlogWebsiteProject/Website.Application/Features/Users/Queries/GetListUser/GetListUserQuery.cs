using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Website.Application.Features.Users.Models;
using Website.Application.Features.Users.Rules;
using Website.Application.Services.Repositories;

namespace Website.Application.Features.Users.Queries.GetListUser
{
    public class GetListUserQuery : IRequest<UserListModel>
    {
        public PageRequest PageRequest{ get; set; }

        public class GetListUserQueryHandler : IRequestHandler<GetListUserQuery, UserListModel>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetListUserQueryHandler(IUserRepository userRepository, IMapper mapper,
                                           UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<UserListModel> Handle(GetListUserQuery request, CancellationToken cancellationToken)
            {
                IPaginate<User> users = await _userRepository.GetListAsync(index: request.PageRequest.Page,
                                                                      size: request.PageRequest.PageSize);
                UserListModel mappedUserListModel = _mapper.Map<UserListModel>(users);
                return mappedUserListModel;
            }
        }
    }
}
