namespace netCoreApi.Dtos.Fight
{
    public class AttackResultDto
    {
        public string Attacker {get; set;}
        public string Oponnent {get; set;}
        public int AttackerHp {get; set;}
        public int OponnentHp {get; set;}
        public int Damage {get; set;}
    }
}