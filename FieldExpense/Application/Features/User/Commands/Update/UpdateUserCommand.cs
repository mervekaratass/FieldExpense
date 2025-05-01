using Application.Repositories;
using Application.Services.RoleService;
using Application.Services.User;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Hashing;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.User.Commands.Update
{
    public class UpdateUserCommand : IRequest<UpdateUserResponse>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string IBAN { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IRoleService _roleService;
            private readonly IUserService _userService;

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IRoleService roleService, IUserService userService)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _roleService = roleService;
                _userService = userService;
            }

            public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                await _userService.EmailExistsForOtherUserAsync(request.Id,request.Email);
                await _userService.PhoneExistsForOtherUserAsync(request.Id, request.Phone);
                await _userService.IbanExistsForOtherUserAsync(request.Id, request.IBAN);


                var user = await _userRepository.GetAsync(x => x.Id == request.Id, include:u=>u.Include(x=>x.Role));
                if (user == null)
                    throw new BusinessException("Kullanıcı bulunamadı.");

                Role? role = await _roleService.GetByIdAsync(request.RoleId);

                _mapper.Map(request, user);

                if (!string.IsNullOrEmpty(request.Password))
                {
                    HashingHelper.CreatePasswordHash(request.Password, out byte[] hash, out byte[] salt);
                    user.PasswordHash = hash;
                    user.PasswordSalt = salt;
                }

                await _userRepository.UpdateAsync(user);
                return _mapper.Map<UpdateUserResponse>(user);
            }
        }


    }
}
