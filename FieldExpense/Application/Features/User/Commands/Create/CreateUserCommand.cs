using Application.Repositories;
using AutoMapper;
using Core.Utilities.Hashing;
using MediatR;
using Domain.Entities;
using Application.Services.RoleService;
using Application.Services.UserService;
using Core.Application.Pipelines.Authorization;

namespace Application.Features.User.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>,ISecuredRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IBAN { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }
        public string[] RequiredRoles => ["Admin","Personel"];


        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IRoleService _roleService;
            private readonly IMapper _mapper;
            private readonly IUserService _userService;

            public CreateUserCommandHandler(IUserRepository userRepository, IRoleService roleService, IMapper mapper, IUserService userService)
            {
                _userRepository = userRepository;
                _roleService = roleService;
                _mapper = mapper;
                _userService = userService;
            }

            public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                await _userService.EmailExistsAsync(request.Email);
                await _userService.PhoneExistsAsync(request.Phone);
                await _userService.IbanExistsAsync(request.IBAN);

                Role? role = await _roleService.GetByIdAsync(request.RoleId);



                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

                Domain.Entities.User user = _mapper.Map<Domain.Entities.User>(request);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _userRepository.AddAsync(user);

                var response = _mapper.Map<CreateUserResponse>(user);
                response.FullName = $"{user.FirstName} {user.LastName}";
                response.RoleName = role.Name;
                return response;
            }
        }
    }
}