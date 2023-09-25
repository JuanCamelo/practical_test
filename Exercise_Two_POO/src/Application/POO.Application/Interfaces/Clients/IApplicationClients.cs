using POO.Application.DTOs.Request;
using POO.Infraestructure.Entities;

namespace POO.Application.Interfaces.Clients
{
    public interface IApplicationClients
    {
        Task<IEnumerable<Client>> GetAsync();
        Task<string> AddAsync(ModelAccountClient model);
    }
}
