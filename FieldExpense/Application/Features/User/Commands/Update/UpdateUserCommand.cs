using Application.Repositories;
using Application.Services.RoleService;
using AutoMapper;
using Core.Utilities.Hashing;
using Domain.Entities;
using MediatR;

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
            

            public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                
            }

            public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
                if (user == null)
                    throw new Exception("Kullanıcı bulunamadı.");

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
