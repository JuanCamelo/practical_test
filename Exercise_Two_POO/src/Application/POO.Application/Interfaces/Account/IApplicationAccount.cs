using POO.Application.DTOs.Request;

namespace POO.Application.Interfaces.Account
{
    public interface IApplicationAccount
    {
        public Task<bool> CreateAcountAsync(ModelAccount model);
        public Task<Guid> getAcountIdAsync(int documet);
    }
}
