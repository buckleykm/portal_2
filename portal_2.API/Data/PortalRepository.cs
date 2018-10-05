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

        public async Task<IEnumerable<App>> GetAppsForUser(int userid)
        {
            var apps = await _context.Apps.Where(a => a.UserId == userid).ToListAsync();

            return apps;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(a => a.Apps).FirstOrDefaultAsync(b => b.Id == id);

            return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = _context.Users.Include(a => a.Apps);
            
            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;

        }

    }
}