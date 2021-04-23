using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using netCoreApi.Models;

namespace netCoreApi.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
         private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {Id = 1 , Name = "Jeffri", Class = Rpgclass.Knigth}
        };
        public async Task<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return characters;
        }

        public async Task<List<Character>> GetAllCharacters()
        {
           return characters;
        }

        public async Task<Character> GetCharacterById(int id)
        {
             return characters.FirstOrDefault(c => c.Id == id);
        }
    }
}