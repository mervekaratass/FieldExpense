﻿using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Commands.Delete
{
    public class DeleteUserCommand : IRequest<DeleteUserResponse>,ISecuredRequest
    {
        public int Id { get; set; }

        public string[] RequiredRoles => ["Admin"];
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;

            public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.User? user = await _userRepository.GetAsync(u => u.Id == request.Id, include:u=>u.Include(x=>x.Role));
                if (user == null)
                    throw new BusinessException("Kullanıcı bulunamadı.");

                await _userRepository.DeleteAsync(user);
                return _mapper.Map<DeleteUserResponse>(user);
            }
        }
    }
}
