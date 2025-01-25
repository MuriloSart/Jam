using Entities.Health;

namespace Entities.Damage
{
    public class DamageBuffedByKill : DamageBase
    {
        public override void Deal(int damage, HealthBase health)
        {
            base.Deal(damage, health);
            if(health.CurrentLife <= 0 || entity.health.CurrentLife > 0) entity.UseAbility(); 
        }
    }
}