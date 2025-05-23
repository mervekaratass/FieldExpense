﻿using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Queries.GetById
{
    public class GetByIdUserQuery : IRequest<GetByIdUserResponse>, ISecuredRequest
    {
        public int Id { get; set; }
        public string[] RequiredRoles => ["Admin"];

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(u => u.Id == request.Id, include: u => u.Include(x => x.Role));

                if (user is null)
                    throw new BusinessException("Kullanıcı bulunamadı.");


                var response = _mapper.Map<GetByIdUserResponse>(user);
                return response;
            }
        }
    }

}