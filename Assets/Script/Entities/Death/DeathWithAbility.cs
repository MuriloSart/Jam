namespace Entities.Death
{
    public class DeathWithAbility : DeathBase
    {
        public override void Kill()
        {
            entity.UseAbility();
            base.Kill();
        }
    }
}
