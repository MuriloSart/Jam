namespace Entities.Death
{
    public class AllyDeath : DeathBase
    {
        public override void Kill()
        {
            AlliesManager.Instance.AllyKilled(entity);
            Destroy(this.gameObject);
        }
    }
}