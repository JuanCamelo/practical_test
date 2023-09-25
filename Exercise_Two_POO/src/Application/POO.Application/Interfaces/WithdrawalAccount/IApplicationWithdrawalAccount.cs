using POO.Application.DTOs.Request;
using POO.Application.DTOs.Response;

namespace POO.Application.Interfaces.WithdrawalAccount
{
    public interface IApplicationWithdrawalAccount
    {
        Task<IEnumerable<ViewAccountTransaction>> CreateWithdrawalAccount(ModelAccountWithdrawal model);
    }
}
