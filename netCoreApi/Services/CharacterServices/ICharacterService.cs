using System.Collections.Generic;
using System.Threading.Tasks;
using netCoreApi.Dtos.Character;
using netCoreApi.Models;

namespace netCoreApi.Services.CharacterServices
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
         Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
         Task<ServiceResponse<List<AddCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
    }
}