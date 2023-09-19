using AutoMapper;
using POO.Application.DTOs.Request;
using POO.Application.Interfaces.Account;
using POO.Application.Interfaces.Clients;
using POO.Domain.Interfaces;
using POO.Infraestructure.Entities;
using POO.Infraestructure.Interfaces;

namespace POO.Application.Services.Clients
{
    public class ApplicationClients : IApplicationClients
    {
        private readonly IRepository<Client> _repositoryClient;
        private readonly IApplicationAccount _applicatioAccount;
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public ApplicationClients(
            IRepository<Client> repositoryClient,
            IMapper mapper,
            IApplicationAccount applicatioAccount,
            IUnitOfWork unitOfWork)
        {
            _repositoryClient = repositoryClient;
            _mapper = mapper;
            _applicatioAccount = applicatioAccount;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> AddAsync(ModelAccountClient model)
        {
            try
            {
                Client objClient = _mapper.Map<Client>(model);
                await _repositoryClient.AddAsync(objClient);

                ModelAccount objAccount = _mapper.Map<ModelAccount>(model);
                objAccount.ClientId = objClient.Id;
                await _applicatioAccount.CreateAcountAsync(objAccount);

                await _unitOfWork.SaveChangesAsync();
                return "Sucessfull!";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<dynamic> GetAsync()
        {
            try
            {
                var result = await _repositoryClient.GetAllAsync<Client>();
                return result;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
