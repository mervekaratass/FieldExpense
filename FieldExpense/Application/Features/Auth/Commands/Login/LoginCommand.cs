using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Utilities.Hashing;
using Core.Utilities.JWT;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IRoleRepository _roleRepository;

            public LoginCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IRoleRepository roleRepository)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _roleRepository = roleRepository;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.User? user = await _userRepository.GetAsync(
                    i => i.Email == request.Email);

                if(user is null)
                {
                    throw new BusinessException("Giriş başarısız.");
                }
               
                bool isPasswordMatch = HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

                if (!isPasswordMatch)
                    throw new BusinessException("Giriş başarısız.");

                // Kullanıcı rollerini sorgula.
              
                Role userRole = await _roleRepository.GetAsync(i => i.Id == user.RoleId);

                var userRoles = new List<Core.Entities.BaseRole> { userRole };

                return _tokenHelper.CreateToken(user, userRoles);
               
            }
        }
    }
}
