namespace Entities.Death
{
    public class AllyDeathWithAbility : DeathBase
    {
        public override void Kill()
        {
            AlliesManager.Instance.AllyKilled(entity);
            entity.UseAbility();
            Destroy(this.gameObject);
        }
    }
}
