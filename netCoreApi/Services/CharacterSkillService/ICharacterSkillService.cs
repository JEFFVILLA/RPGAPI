using System.Threading.Tasks;
using netCoreApi.Dtos.Character;
using netCoreApi.Dtos.CharacterSkill;
using netCoreApi.Models;

namespace netCoreApi.Services.CharacterSkillService
{
    public interface ICharacterSkillService
    {
         Task<ServiceResponse<GetCharacterDto>> AddCharacterSkill(AddCharacterSkillDto newCharacterSkill);
    }
}