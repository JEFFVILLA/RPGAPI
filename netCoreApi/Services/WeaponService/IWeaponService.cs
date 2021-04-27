using System.Threading.Tasks;
using netCoreApi.Dtos.Character;
using netCoreApi.Dtos.Weapon;
using netCoreApi.Models;

namespace netCoreApi.Services.WeaponService
{
    public interface IWeaponService
    {
         Task<ServiceResponse<GetCharacterDto>> AddWeapon(AddWeaponDto newWeapon);
    }
}