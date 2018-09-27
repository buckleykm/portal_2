using System.Threading.Tasks;
using portal_2.API.Models;

namespace portal_2.API.Data
{
    public interface IAuthRepository
    {
         Task<Broker> Register (Broker broker, string password);
         Task<Broker> Login (string username, string password);
         Task<bool> BrokerExists (string username);
    }
}