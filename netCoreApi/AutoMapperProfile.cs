using AutoMapper;
using netCoreApi.Dtos.Character;
using netCoreApi.Models;

namespace netCoreApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}