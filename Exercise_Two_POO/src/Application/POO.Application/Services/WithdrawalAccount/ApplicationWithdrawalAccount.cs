using AutoMapper;
using POO.Application.DTOs.Request;
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

        public ApplicationWithdrawalAccount(
            IRepository<AccountWithdrawal> accountWithdrawalRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _accountWithdrawalRepository = accountWithdrawalRepository;
            _mapper = mapper;
            _unitOfWork= unitOfWork;
        }

        public async Task<string> CreateWithdrawalAccount(ModelAccountWithdrawal model)
        {
            try
            {
                AccountWithdrawal objResult = _mapper.Map<AccountWithdrawal>(model);
                await _accountWithdrawalRepository.AddAsync(objResult);

                await _unitOfWork.SaveChangesAsync();
                return "succesfull!";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
