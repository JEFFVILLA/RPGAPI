using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using netCoreApi.Dtos.Fight;
using netCoreApi.Services.FightService;

namespace netCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FightController : ControllerBase
    {
        private readonly IFightService _fightService;
        public FightController(IFightService fightService)
        {
            _fightService = fightService;
        }

        [HttpPost("Weapon")]
        public async Task<IActionResult> WeaponAttack(WeaponAttackDto request)
        {
            return Ok(await _fightService.WeaponnAttack(request));
        }

          [HttpPost("Skill")]
        public async Task<IActionResult> WeaponAttack(SkillAttackDto request)
        {
            return Ok(await _fightService.SkillAttack(request));
        }
    }
}