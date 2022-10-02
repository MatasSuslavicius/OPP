using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tower_battle.Services;

namespace tower_battle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly UnitService m_unitService;
        public UnitController(UnitService unitService)
        {
            m_unitService = unitService;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok(m_unitService.Create());
        }

        [HttpPost("LevelUp")]
        public async Task<IActionResult> LevelUp()
        {
            return Ok(m_unitService.LevelUp());
        }

        [HttpPost("ClearUnits")]
        public async Task<IActionResult> ClearUnits()
        {
            m_unitService.ClearUnits();
            return Ok();
        }

        [HttpPost("ResetLevel")]
        public async Task<IActionResult> ResetLevel()
        {
            m_unitService.ResetLevel();
            return Ok();
        }
    }
}
