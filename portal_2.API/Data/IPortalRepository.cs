using System.Collections.Generic;
using System.Threading.Tasks;
using portal_2.API.Models;

namespace portal_2.API.Data
{
    public interface IPortalRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Broker>> GetBrokers();
        Task<Broker> GetBroker(int brokerid);
    }
}