using Microsoft.AspNetCore.Mvc;
using POO.Application.Interfaces.HistoryMovements;

namespace Web.Application.POO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryMovementsController : ControllerBase
    {
        private readonly IApplicationHistoryMovements _applicationHistoryMovements;

        public HistoryMovementsController(IApplicationHistoryMovements applicationHistoryMovements)
        {
            _applicationHistoryMovements = applicationHistoryMovements;
        }

        [HttpGet]
        public async Task<IActionResult> CreateTranferAsync([FromQuery] int idDocument)
        {
            try
            {
                return Ok(await _applicationHistoryMovements.HistoryMovementsAsync(idDocument));
            }
            catch (Exception ex)
            {

                return StatusCode(409, ex.Message); ;
            }
        }
    }
}
