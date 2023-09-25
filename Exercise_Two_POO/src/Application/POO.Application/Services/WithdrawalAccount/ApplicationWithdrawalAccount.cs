using AutoMapper;
using POO.Application.DTOs.Request;
using POO.Application.DTOs.Response;
using POO.Application.Interfaces.Account;
using POO.Application.Interfaces.WithdrawalAccount;
using POO.Domain.Interfaces;
using POO.Infraestructure.Entities;
using POO.Infraestructure.Interfaces;

namespace POO.Application.Services.WithdrawalAccount
{
    public class ApplicationWithdrawalAccount : IApplicationWithdrawalAccount
    {
        private readonly IRepository<AccountWithdrawal> _accountWithdrawalRepository;
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationAccount _applicationAccount;

        public ApplicationWithdrawalAccount(
            IRepository<AccountWithdrawal> accountWithdrawalRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IApplicationAccount applicationAccount)
        {
            _accountWithdrawalRepository = accountWithdrawalRepository;
            _mapper = mapper;
            _unitOfWork= unitOfWork;
            _applicationAccount= applicationAccount;
        }

        public async Task<IEnumerable<ViewAccountTransaction>> CreateWithdrawalAccount(ModelAccountWithdrawal model)
        {
            try
            {
                var idAccount = await _applicationAccount.getAcountIdAsync(model.Document);

                if (idAccount == Guid.Empty) throw new Exception("Document is not valid");

                AccountWithdrawal objResult = _mapper.Map<AccountWithdrawal>(model);
                objResult.AccountId = idAccount;
                await _accountWithdrawalRepository.AddAsync(objResult);

                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<IEnumerable<ViewAccountTransaction>>( await GetWithdrawalAccount(idAccount)); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ViewAccountTransaction>> GetWithdrawalAccount(Guid accountId)
        {
            try
            {
                var accountWithdrawal = await _accountWithdrawalRepository.GetAllAsync<AccountWithdrawal>(whereCondition: c=> c.AccountId.Equals(accountId));

                return _mapper.Map<IEnumerable<ViewAccountTransaction>>(accountWithdrawal);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
