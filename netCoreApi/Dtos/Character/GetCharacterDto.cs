using System.Collections.Generic;
using netCoreApi.Dtos.Skill;
using netCoreApi.Dtos.Weapon;
using netCoreApi.Models;

namespace netCoreApi.Dtos.Character
{
    public class GetCharacterDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Killua";
        public int HitPoints { get; set; } = 100;
        public int Strength { get; set; } = 10;
        public int Defense { get; set; } = 10;
        public int Intelligence { get; set; } = 10;
        public Rpgclass Class { get; set; } = Rpgclass.Cleric;
        public GetWeaponDto Weapon {get; set;}
        public List<GetSkillDto> Skills {get; set;}
        public int Figths {get; set;}
        public int Victories {get;set;}
        public int Defeats {get; set;}
    }
}