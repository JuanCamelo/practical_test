using AutoMapper;
using POO.Application.DTOs.Request;
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
        public ApplicationTransferAccount(
            IRepository<AccountTransfer> accountTransferRepositoryy,
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _accountTransferRepository= accountTransferRepositoryy;
            _mapper = mapper;
            _unitOfWork= unitOfWork;
        }

        public async Task<string> CreateTransferAccount(ModelAccountTransfer model)
        {
            try
            {
                AccountTransfer objResult = _mapper.Map<AccountTransfer>(model);
                await _accountTransferRepository.AddAsync(objResult);

                await _unitOfWork.SaveChangesAsync();
                return "Succefull!";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
