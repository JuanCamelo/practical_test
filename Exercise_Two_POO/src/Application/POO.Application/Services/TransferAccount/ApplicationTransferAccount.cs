using AutoMapper;
using POO.Application.DTOs.Request;
using POO.Application.DTOs.Response;
using POO.Application.Interfaces.Account;
using POO.Application.Interfaces.Clients;
using POO.Application.Interfaces.TransferAccount;
using POO.Domain.Interfaces;
using POO.Infraestructure.Entities;
using POO.Infraestructure.Interfaces;

namespace POO.Application.Services.TransferAccount
{
    public class ApplicationTransferAccount : IApplicationTransferAccount
    {
        private readonly IRepository<AccountTransfer> _accountTransferRepository;
        private IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApplicationAccount _applicationAccount;
        public ApplicationTransferAccount(
            IRepository<AccountTransfer> accountTransferRepositoryy,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IApplicationAccount applicationAccount)
        {
            _accountTransferRepository= accountTransferRepositoryy;
            _mapper = mapper;
            _unitOfWork= unitOfWork;
            _applicationAccount= applicationAccount;
        }

        public async Task<IEnumerable<ViewAccountTransaction>> CreateTransferAccount(ModelAccountTransfer model)
        {
            try
            {
                var idAccount = await _applicationAccount.getAcountIdAsync(model.Document);

                if (idAccount == Guid.Empty) throw new Exception("Document is not valid");

                AccountTransfer objResult = _mapper.Map<AccountTransfer>(model);
                objResult.AccountId = idAccount;
                await _accountTransferRepository.AddAsync(objResult);

                await _unitOfWork.SaveChangesAsync();
                return _mapper.Map<IEnumerable<ViewAccountTransaction>>(await GetTransferAccount(idAccount));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<ViewAccountTransaction>> GetTransferAccount(Guid accountId)
        {
            try
            {
                var accountTransfer = await _accountTransferRepository.GetAllAsync<AccountTransfer>(whereCondition: c => c.AccountId.Equals(accountId));

                return _mapper.Map<IEnumerable<ViewAccountTransaction>>(accountTransfer);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
