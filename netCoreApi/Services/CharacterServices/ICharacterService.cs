using System.Collections.Generic;
using System.Threading.Tasks;
using netCoreApi.Models;

namespace netCoreApi.Services.CharacterServices
{
    public interface ICharacterService
    {
         Task<List<Character>> GetAllCharacters();
         Task<Character> GetCharacterById(int id);
         Task<List<Character>> AddCharacter(Character newCharacter);
    }
}