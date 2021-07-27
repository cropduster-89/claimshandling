using ClaimsHandling.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClaimsHandling.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LossTypeController : ControllerBase
    {
        private readonly ILossTypeService _lossTypeService;

        public LossTypeController(ILossTypeService lossTypeService)
        {
            _lossTypeService = lossTypeService;
        }

        [HttpGet]
        public IActionResult TryLogin([FromQuery] int pageSize,
                                      [FromQuery] int pageIndex)
        {
            try
            {
                return Ok(_lossTypeService.GetPage(pageSize, pageIndex));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
