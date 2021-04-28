using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using netCoreApi.Data;
using netCoreApi.Dtos.Fight;
using netCoreApi.Models;

namespace netCoreApi.Services.FightService
{
    public class FightService : IFightService
    {
          private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FightService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<AttackResultDto>> SkillAttack(SkillAttackDto request)
        {
             ServiceResponse<AttackResultDto> response = new ServiceResponse<AttackResultDto>();
            try
            {
                Character attacker = await _context.Characters.Include(c => c.CharacterSkills).ThenInclude(cs =>cs.Skill).FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                Character opponnent = await _context.Characters.FirstOrDefaultAsync(c => c.Id == request.OpponnentId);
                

                CharacterSkill characterSkill = attacker.CharacterSkills.FirstOrDefault(cs => cs.Skill.Id == request.SkillId);
                
                if (characterSkill ==null) 
                {
                    response.Success = false;
                    response.Message = $"{attacker.Name} doesn't know that skill";
                    return response;
                }
                int damage = characterSkill.Skill.Damage + (new Random().Next(attacker.Intelligence));
                damage -= new Random().Next(opponnent.Defense);
                if(damage >0)
                    opponnent.HitPoints -= damage;
                if(opponnent.HitPoints <= 0)
                    response.Message  = $"{opponnent.Name} has been defeated!!!!";
                _context.Characters.Update(opponnent);
                await _context.SaveChangesAsync();

                response.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    AttackerHp = attacker.HitPoints,
                    Oponnent = opponnent.Name,
                    OponnentHp = opponnent.HitPoints,
                    Damage = damage
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<AttackResultDto>> WeaponnAttack(WeaponAttackDto request)
        {
            ServiceResponse<AttackResultDto> response = new ServiceResponse<AttackResultDto>();
            try
            {
                Character attacker = await _context.Characters.Include(c => c.Weapon).FirstOrDefaultAsync(c => c.Id == request.AttackerId);
                Character opponnent = await _context.Characters.Include(c => c.Weapon).FirstOrDefaultAsync(c => c.Id == request.OponnentId);

                int damage = attacker.Weapon.Damage + (new Random().Next(attacker.Strength));
                damage -= new Random().Next(opponnent.Defense);
                if(damage >0)
                    opponnent.HitPoints -= damage;
                if(opponnent.HitPoints <= 0)
                    response.Message  = $"{opponnent.Name} has been defeated!!!!";
                _context.Characters.Update(opponnent);
                await _context.SaveChangesAsync();

                response.Data = new AttackResultDto
                {
                    Attacker = attacker.Name,
                    AttackerHp = attacker.HitPoints,
                    Oponnent = opponnent.Name,
                    OponnentHp = opponnent.HitPoints,
                    Damage = damage
                };
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}