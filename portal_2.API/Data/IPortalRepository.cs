using System.Collections.Generic;
using System.Threading.Tasks;
using portal_2.API.Helpers;
using portal_2.API.Models;

namespace portal_2.API.Data
{
    public interface IPortalRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUser(int id);
        Task<IEnumerable<App>> GetApps();
        Task<IEnumerable<App>> GetAppsForUser(int userid);
    }
}