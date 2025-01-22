namespace Entities.Death
{
    public class DeathWithAbility : DeathBase
    {
        public Entity entity;
        private void Start()
        {
            entity = GetComponent<Entity>();
        }
        public override void Kill()
        {
            entity.UseAbility();
            base.Kill();
        }
    }
}
