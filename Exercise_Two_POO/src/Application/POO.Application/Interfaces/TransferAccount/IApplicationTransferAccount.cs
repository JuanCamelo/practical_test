using POO.Application.DTOs.Request;

namespace POO.Application.Interfaces.TransferAccount
{
    public interface IApplicationTransferAccount
    {
        Task<string> CreateTransferAccount(ModelAccountTransfer model);
    }
}
