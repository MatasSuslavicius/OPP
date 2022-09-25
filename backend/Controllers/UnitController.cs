using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tower_battle.Services;

namespace tower_battle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        UnitService m_unitService;
        public UnitController(UnitService unitService)
        {
            m_unitService = unitService;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok(m_unitService.Create());
        }
    }
}
