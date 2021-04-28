using System.Linq;
using AutoMapper;
using netCoreApi.Dtos.Character;
using netCoreApi.Dtos.Skill;
using netCoreApi.Dtos.Weapon;
using netCoreApi.Models;

namespace netCoreApi
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>()
                .ForMember(dto => dto.Skills, c => c.MapFrom(c => c.CharacterSkills.Select(cs => cs.Skill)));
            CreateMap<AddCharacterDto, Character>();
            CreateMap<Weapon, GetWeaponDto>();
            CreateMap<Skill, GetSkillDto>();
        }
    }
}