using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using portal_2.API.Models;

namespace portal_2.API.Data
{
    public class PortalRepository : IPortalRepository
    {
        private readonly DataContext _context;
        public PortalRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Broker> GetBroker(int brokerid)
        {
            var broker = await _context.Brokers.Include(a => a.Apps).FirstOrDefaultAsync(b => b.BrokerId == brokerid);

            return broker;
        }

        public async Task<IEnumerable<Broker>> GetBrokers()
        {
            var brokers = await _context.Brokers.Include(a => a.Apps).ToListAsync();
            
            return brokers;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;

        }
    }
}