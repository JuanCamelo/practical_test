using POO.Application.DTOs.Request;
using POO.Application.DTOs.Response;

namespace POO.Application.Interfaces.TransferAccount
{
    public interface IApplicationTransferAccount
    {
        Task<IEnumerable<ViewAccountTransaction>> CreateTransferAccount(ModelAccountTransfer model);
    }
}
