using AutoMapper;
using netCoreApi.Dtos.Character;
using netCoreApi.Dtos.Weapon;
using netCoreApi.Models;

namespace netCoreApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
        }
    }
}