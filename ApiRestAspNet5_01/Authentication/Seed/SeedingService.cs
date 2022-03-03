using ApiRestAspNet5_01.Context;
using ApiRestAspNet5_01.Models;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ApiRestAspNet5_01.Authentication.Seed
{
    public class SeedingService
    {
        private ApplicationDbContext _context;

        public SeedingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Users.Any()) return;

            string pass1 = ComputeHash("admin123", new SHA256CryptoServiceProvider());

            User u1 = new User { UserName =  "thiago", FullName = "Thiago Oliveira", Password = pass1, RefreshToken = "abcde", RefreshTokenExpiryTime = new DateTime(2022, 02, 02, 19, 30, 00) };
            User u2 = new User { UserName =  "galego", FullName = "Joe Colasanto", Password = ComputeHash("joe123", new SHA256CryptoServiceProvider()), RefreshToken = "fghij", RefreshTokenExpiryTime = new DateTime(2022, 02, 02, 20, 30, 00) };
            User u3 = new User { UserName =  "louise", FullName = "Louise Souza", Password = "louise123", RefreshToken = "klmno", RefreshTokenExpiryTime = new DateTime(2022, 02, 02, 21, 30, 00) };

            _context.Users.AddRange(u1, u2, u3);
            _context.SaveChanges();
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm) //Criptografia de senha!
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes);
        }
    }
}
