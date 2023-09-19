using Microsoft.AspNetCore.Mvc;
using POO.Application.DTOs.Request;
using POO.Application.Interfaces.WithdrawalAccount;

namespace Web.Application.POO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawalAccountController : ControllerBase
    {
        private readonly IApplicationWithdrawalAccount _applicationWithdrawalAccount;

        public WithdrawalAccountController(IApplicationWithdrawalAccount applicationWithdrawalAccount)
        {
            _applicationWithdrawalAccount = applicationWithdrawalAccount;
        }

        [HttpGet]
        public async Task<IActionResult> CreateWithdrawalAsync([FromBody] ModelAccountWithdrawal model)
        {
            try
            {
                var result = await _applicationWithdrawalAccount.CreateWithdrawalAccount(model);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(409, ex.Message); ;
            }
        }
    }
}
