using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class UserManager : IUserService
    {
       private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Domain.Entities.User?> GetByIdAsync(int id)
        {
            Domain.Entities.User? user =await _userRepository.GetAsync(u => u.Id == id);

            if (user is null)
                throw new BusinessException("Kullanıcı bulunamadı.");

            return user;
        }
    }
}
