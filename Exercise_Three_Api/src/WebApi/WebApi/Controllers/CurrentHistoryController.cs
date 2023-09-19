using Microsoft.AspNetCore.Mvc;
using WebApi.Application.Contract;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrentHistoryController : ControllerBase
    {
        private readonly IAppplicationtCurrenHistory _appplicationtCurrenHistory;

        public CurrentHistoryController(IAppplicationtCurrenHistory appplicationtCurrenHistory)
        {
            _appplicationtCurrenHistory = appplicationtCurrenHistory;
        }

        [HttpGet]
        public async Task<IActionResult> CreateWithdrawalAsync()
        {
            try
            {
                var result = await _appplicationtCurrenHistory.LastYearHistoryAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(409, ex.Message); ;
            }
        }

        [HttpGet("ratesConversion")]
        public async Task<IActionResult> HistoryRatesConversionAsync()
        {
            try
            {
                var result = await _appplicationtCurrenHistory.HistoryRatesConversionAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(409, ex.Message); ;
            }
        }

        [HttpGet("Tiemeseries")]
        public async Task<IActionResult> HistoryTiemeseriesAsync()
        {
            try
            {
                var result = await _appplicationtCurrenHistory.HistoryTiemeseriesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(409, ex.Message); ;
            }
        }
    }
}
