using Application.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.UserService
{
    public class UserManager : IUserService
    {
       private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            Domain.Entities.User? user= await _userRepository.GetAsync(u => u.Email == email && u.DeletedDate == null);
            if (user is null)
                return true;

                throw new BusinessException("Bu email adresi zaten kullanımda");

        
        }

        public async Task<Domain.Entities.User?> GetByIdAsync(int id)
        {
            Domain.Entities.User? user =await _userRepository.GetAsync(u => u.Id == id);

            if (user is null)
                throw new BusinessException("Kullanıcı bulunamadı.");

            return user;
        }

        public async Task<bool> IbanExistsAsync(string iban)
        {
            Domain.Entities.User? user = await _userRepository.GetAsync(u => u.IBAN == iban && u.DeletedDate == null);
            if (user is null)
                return true;

            throw new BusinessException("Bu iban bilgisi zaten kullanımda");
        }

        public async  Task<bool> PhoneExistsAsync(string phone)
        {
            Domain.Entities.User? user = await _userRepository.GetAsync(u => u.Phone == phone && u.DeletedDate == null);
            if (user is null)
                return true;

            throw new BusinessException("Bu telefon bilgisi zaten kullanımda");
        }

        public async Task<bool> EmailExistsForOtherUserAsync(int userId, string email)
        {
            Domain.Entities.User? user = await _userRepository.GetAsync(
                u => u.Email == email && u.Id != userId && u.DeletedDate == null
            );

            if (user is null)
                return true;

            throw new BusinessException("Bu email adresi  zaten kullanımda");
        }

        public async Task<bool> IbanExistsForOtherUserAsync(int userId, string iban)
        {
            Domain.Entities.User? user = await _userRepository.GetAsync(
                u => u.IBAN == iban && u.Id != userId && u.DeletedDate == null
            );

            if (user is null)
                return true;

            throw new BusinessException("Bu iban bilgisi zaten kullanımda");
        }
        public async Task<bool> PhoneExistsForOtherUserAsync(int userId, string phone)
        {
            Domain.Entities.User? user = await _userRepository.GetAsync(
                u => u.Phone == phone && u.Id != userId && u.DeletedDate == null
            );

            if (user is null)
                return true;

            throw new BusinessException("Bu telefon bilgisi zaten kullanımda");
        }


    }
}
