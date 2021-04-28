using System.Threading.Tasks;
using netCoreApi.Dtos.Fight;
using netCoreApi.Models;

namespace netCoreApi.Services.FightService
{
    public interface IFightService
    {
         Task<ServiceResponse<AttackResultDto>> WeaponnAttack(WeaponAttackDto request);
          Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request);
    }
}