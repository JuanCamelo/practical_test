using AutoMapper;
using Microsoft.EntityFrameworkCore;
using POO.Application.DTOs.Request;
using POO.Application.Interfaces.Account;
using POO.Domain.Interfaces;
using POO.Infraestructure.Entities;


namespace POO.Application.Services.Account
{
    public class ApplicationAccount : IApplicationAccount
    {
        private readonly IRepository<BankAccount> _bankAccountRepository;
        private IMapper _mapper;

        public ApplicationAccount(IRepository<BankAccount> bankAccountRepository, IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAcountAsync(ModelAccount model)
        {
            try
            {
                BankAccount objResult = _mapper.Map<BankAccount>(model);
                await _bankAccountRepository.AddAsync(objResult);

                return await Task.FromResult(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Guid> getAcountIdAsync(int documet)
        {
            try
            {
                BankAccount result =  (await _bankAccountRepository.GetAllAsync<BankAccount>(whereCondition: c => c.Client.DocumentNumber.Equals(documet),
                                                                   includes: source => source.Include(c => c.Client))).FirstOrDefault();

                return result.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
