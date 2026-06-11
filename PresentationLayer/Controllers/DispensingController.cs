using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petrol_Pump_Web_API.ApplicationLayer.DTOS;
using Petrol_Pump_Web_API.ApplicationLayer.Services;

namespace Petrol_Pump_Web_API.PresentationLayer.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DispensingController : ControllerBase
    {
        private readonly DispensingService _service;

        public DispensingController(DispensingService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] DispensingDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _service.AddRecord(dto);

            return Ok(new
            {
                success = true,
                message = "Saved successfully"
            });
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(string? dispenserNo,
    string? paymentMode,
    DateTime? startDate,
    DateTime? endDate)
        {
            var data = await _service.GetAll(dispenserNo,
        paymentMode,
        startDate,
        endDate);
            return Ok(data);
        }
    }
}
