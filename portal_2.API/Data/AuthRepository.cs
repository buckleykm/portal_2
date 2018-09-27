using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portal_2.API.Models;

namespace portal_2.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;

        }
        public async Task<bool> BrokerExists(string username)
        {
            if (await _context.Brokers.AnyAsync(x => x.Username == username))
                return true;
            
            return false;
        }

        public async Task<Broker> Login(string username, string password)
        {
            var broker = await _context.Brokers.FirstOrDefaultAsync(x => x.Username  == username);

            if (broker == null)
                return null;

            if (!VerifyPasswordHash(password, broker.PasswordHash, broker.PasswordSalt))
                return null;
            
            return broker;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
               var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
               for (int i = 0; i < computedHash.Length; i++)
               {
                   if (computedHash[i] != passwordHash[i]) return false;
               }
            }
            return true;
        }

        public async Task<Broker> Register(Broker broker, string password)
        {
           byte[] passwordHash, passwordSalt;
           CreatePasswordHash(password, out passwordHash, out passwordSalt);

           broker.PasswordHash = passwordHash;
           broker.PasswordSalt = passwordSalt;

           await _context.Brokers.AddAsync(broker);
           await _context.SaveChangesAsync();

           return broker;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            };
        }
    }
}