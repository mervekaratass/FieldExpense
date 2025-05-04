

using Application.Repositories;
using Application.Services.UserService;
using Core.Application.Pipelines.Authorization;
using Core.Utilities.Hashing;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Application.Features.Auth.Commands.UpdatePassword
{
    public class UpdatePasswordCommand : IRequest<UpdatePasswordResponse>, ISecuredRequest
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }

        public string[] RequiredRoles => new[] { "Admin", "Personel" };

        public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, UpdatePasswordResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserService _userService;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public UpdatePasswordCommandHandler(IUserRepository userRepository, IUserService userService, IHttpContextAccessor httpContextAccessor)
            {
                _userRepository = userRepository;
                _userService = userService;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<UpdatePasswordResponse> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
            {
                int userId = int.Parse(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value!);
                var user = await _userService.GetByIdAsync(userId);

                if (!HashingHelper.VerifyPasswordHash(request.CurrentPassword, user.PasswordHash, user.PasswordSalt))
                    throw new Exception("Mevcut şifre yanlış.");

                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                await _userRepository.UpdateAsync(user);

                return new UpdatePasswordResponse { Message = "Şifre başarıyla güncellendi." };
            }
        }
    }
}
