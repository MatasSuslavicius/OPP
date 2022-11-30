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
        

        [HttpPost("LevelUp")]
        public async Task<IActionResult> LevelUp([FromQuery]bool isRightPlayer)
        {
            return Ok(m_unitService.LevelUp(isRightPlayer));
        }

        [HttpPost("ResetLevel")]
        public async Task<IActionResult> ResetLevel()
        {
            m_unitService.ResetLevel();
            return Ok();
        }
    }
}
