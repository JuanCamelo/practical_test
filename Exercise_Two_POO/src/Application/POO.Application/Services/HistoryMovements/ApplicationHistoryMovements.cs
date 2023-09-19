using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POO.Application.DTOs.Response;
using POO.Application.Interfaces.HistoryMovements;
using POO.Domain.Interfaces;
using POO.Infraestructure.Entities;

namespace POO.Application.Services.HistoryMovements
{
    public class ApplicationHistoryMovements : IApplicationHistoryMovements
    {
        private readonly IRepository<BankAccount> _bankAccount;
        private IMapper _mapper;
        private readonly IDomianHistoryMovements _domianHistoryMovements;

        public ApplicationHistoryMovements(
            IRepository<BankAccount> bankAccount,
            IMapper mapper,
            IDomianHistoryMovements domianHistoryMovements)
        {
            _bankAccount = bankAccount;
            _mapper = mapper;
            _domianHistoryMovements = domianHistoryMovements;
        }

        public async Task<IEnumerable<ViewHistoryMovements>> HistoryMovementsAsync(int idDocument)
        {
            try
            {
                var result = await _bankAccount.GetAllAsync<BankAccount>(whereCondition: c => c.Client.DocumentNumber.Equals(idDocument),
                                                                   includes: source => source.Include(c => c.Client)
                                                                                             .Include(c => c.AccountTransfers)                
                                                                                             .Include(c => c.AccountWithdrawals));


                return _mapper.Map<IEnumerable<ViewHistoryMovements>>(_domianHistoryMovements.LatestMovements(result.FirstOrDefault()));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
