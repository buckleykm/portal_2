using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using portal_2.API.Helpers;
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

        public async Task<IEnumerable<App>> GetApps()
        {
            var apps = await _context.Apps.ToListAsync();

            return apps;
        }

        public async Task<IEnumerable<App>> GetAppsForBroker(int brokerid)
        {
            var apps = await _context.Apps.Where(a => a.BrokerId == brokerid).ToListAsync();

            return apps;
        }

        public async Task<Broker> GetBroker(int id)
        {
            var broker = await _context.Brokers.Include(a => a.Apps).FirstOrDefaultAsync(b => b.Id == id);

            return broker;
        }

        public async Task<PagedList<Broker>> GetBrokers(BrokerParams brokerParams)
        {
            var brokers = _context.Brokers.Include(a => a.Apps);
            
            return await PagedList<Broker>.CreateAsync(brokers, brokerParams.PageNumber, brokerParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;

        }

    }
}