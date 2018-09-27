using System.Collections.Generic;
using Newtonsoft.Json;
using portal_2.API.Models;

namespace portal_2.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedBrokers()
        {
            var brokerData = System.IO.File.ReadAllText("Data/BrokerSeedData.json");
            var brokers = JsonConvert.DeserializeObject<List<Broker>>(brokerData);
            foreach (var broker in brokers)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("P@ssw0rd", out passwordHash, out passwordSalt);

                broker.PasswordHash = passwordHash;
                broker.PasswordSalt = passwordSalt;
                broker.Username = broker.Username.ToLower();

                _context.Brokers.Add(broker);
            }

            _context.SaveChanges();
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