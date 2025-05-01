using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public interface IUserService
    {
        Task<Domain.Entities.User?> GetByIdAsync(int id);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> IbanExistsAsync(string iban);
        Task<bool> PhoneExistsAsync(string email);
        Task<bool> EmailExistsForOtherUserAsync(int userId, string email);
        Task<bool> IbanExistsForOtherUserAsync(int userId, string iban);
        Task<bool> PhoneExistsForOtherUserAsync(int userId, string phone);


    }
}
