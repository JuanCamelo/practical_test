using POO.Application.DTOs.Request;
using POO.Infraestructure.Entities;

namespace POO.Application.Interfaces.WithdrawalAccount
{
    public interface IApplicationWithdrawalAccount
    {
        Task<string> CreateWithdrawalAccount(ModelAccountWithdrawal model);
    }
}
