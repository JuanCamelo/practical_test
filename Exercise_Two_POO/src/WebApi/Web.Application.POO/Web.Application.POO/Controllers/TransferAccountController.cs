using Microsoft.AspNetCore.Mvc;
using POO.Application.DTOs.Request;
using POO.Application.Interfaces.TransferAccount;

namespace Web.Application.POO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferAccountController : ControllerBase
    {
        private readonly IApplicationTransferAccount _applicationTransferAccount;

        public TransferAccountController(IApplicationTransferAccount applicationTransferAccount)
        {
            _applicationTransferAccount = applicationTransferAccount;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTranferAsync([FromBody] ModelAccountTransfer model)
        {
            try
            {
                string result = await _applicationTransferAccount.CreateTransferAccount(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(409, ex.Message); ;
            }
        }
    }
}
