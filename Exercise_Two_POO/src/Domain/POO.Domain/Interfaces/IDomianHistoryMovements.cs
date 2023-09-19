using POO.Domain.Model;
using POO.Infraestructure.Entities;

namespace POO.Domain.Interfaces
{
    public interface IDomianHistoryMovements
    {
        IEnumerable<LatestMovements> LatestMovements(BankAccount accountModel);
    }
}
