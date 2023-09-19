using POO.Application.DTOs.Response;

namespace POO.Application.Interfaces.HistoryMovements
{
    public interface IApplicationHistoryMovements
    {
        Task<IEnumerable<ViewHistoryMovements>> HistoryMovementsAsync(int idDocument);
    }
}
