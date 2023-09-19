using POO.Application.DTOs.Request;
using POO.Application.DTOs.Response;

namespace POO.Application.Interfaces.Clients
{
    public interface IApplicationClients
    {
        Task<dynamic> GetAsync();
        Task<string> AddAsync(ModelAccountClient model);
    }
}
