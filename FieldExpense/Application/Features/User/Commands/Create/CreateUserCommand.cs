using Application.Repositories;
using AutoMapper;
using Core.Utilities.Hashing;
using MediatR;
using Domain.Entities;

namespace Application.Features.User.Commands.Create
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IBAN { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }


        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IRoleRepository _roleRepository;
            private readonly IMapper _mapper;

            public CreateUserCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _roleRepository = roleRepository;
                _mapper = mapper;
            }

            public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                Role? role = await _roleRepository.GetAsync(r => r.Id == request.RoleId, cancellationToken: cancellationToken);
                if (role == null)
                    throw new Exception("Rol bulunamadı.");

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