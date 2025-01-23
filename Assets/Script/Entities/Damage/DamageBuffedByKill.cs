namespace Entities.Damage
{
    public class DamageBuffedByKill : DamageBase
    {
        public override void Deal(int damage, Entity entity)
        {
            base.Deal(damage, entity);
            if(entity.health.CurrentLife <= 0) this.entity.UseAbility(); 
        }
    }
}