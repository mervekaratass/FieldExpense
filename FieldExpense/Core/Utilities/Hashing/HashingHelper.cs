﻿using System.Security.Cryptography;
using System.Text;


namespace Core.Utilities.Hashing
{
    public static class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using HMACSHA512 hmac = new();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));


        }

        public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using HMACSHA512 hmac = new(passwordSalt);

            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return computedHash.SequenceEqual(passwordHash);


        }

    }
}
