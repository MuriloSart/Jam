namespace Entities.Abilities
{
    public class PernilongoAbility : AbilityBase
    {
        public int bonusDamage = 2;
        public Entity entity;

        void Start()
        {
            entity ??= GetComponent<Entity>();
        }

        public override void Cast()
        {
            entity.Damage += bonusDamage;
        }

    }
}