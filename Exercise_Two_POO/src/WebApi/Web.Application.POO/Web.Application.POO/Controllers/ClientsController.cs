using Microsoft.AspNetCore.Mvc;
using POO.Application.DTOs.Request;
using POO.Application.Interfaces.Clients;

namespace Web.Application.POO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IApplicationClients _applicationClients;

        public ClientsController(IApplicationClients applicationClients)
        {
            _applicationClients = applicationClients;
        }
        [HttpGet]
        public async Task<dynamic> GetClientsAsync()
        {
            try
            {
                return await _applicationClients.GetAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<dynamic> PostAsync([FromBody] ModelAccountClient model)
        {
            try
            {
                return await _applicationClients.AddAsync(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
