using POO.Domain.Interfaces;
using POO.Domain.Model;
using POO.Infraestructure.Entities;

namespace POO.Domain.Services
{
    public class DomianHistoryMovements : IDomianHistoryMovements
    {
        public IEnumerable<LatestMovements> LatestMovements(BankAccount accountModel)
        {
            List<LatestMovements> result = new List<LatestMovements>();
            for (int i = 0; i < accountModel.AccountTransfers.Count(); i++)
            {
                var accountTransfers = accountModel.AccountTransfers.ElementAt(i);
                var accountWithdrawals = accountModel.AccountWithdrawals.ElementAt(i);

                result.Add(new LatestMovements
                {
                    Ammount = accountWithdrawals.Amount,
                    BeginningBalance = accountTransfers?.Amount,
                    EndingBalance = accountTransfers?.Amount - accountWithdrawals.Amount,
                    DateRetirement = accountWithdrawals.RetirementDate.ToString("dd/mm/yyyy"),
                    DateTransfer = accountTransfers.DateTransfer.ToString("dd/mm/yyyy")
                });
            }

            return result;
        }
    }
}
