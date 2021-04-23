using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using netCoreApi.Dtos.Character;
using netCoreApi.Models;

namespace netCoreApi.Services.CharacterServices
{
    public class CharacterService : ICharacterService
    {
         private static List<Character> characters = new List<Character> {
            new Character(),
            new Character {Id = 1 , Name = "Jeffri", Class = Rpgclass.Knigth}
        };

        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<AddCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<AddCharacterDto>> serviceResponse = new ServiceResponse<List<AddCharacterDto>>();
            characters.Add(_mapper.Map<AddCharacterDto>(newCharacter));
            serviceResponse.Data = (characters.Select(c => _mapper.Map<AddCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
         ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
         serviceResponse.Data = characters;
           return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.Id == id));
             return serviceResponse;
        }
    }
}