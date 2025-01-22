using System.Collections.Generic;
using Entities;

public class EnemiesManager : Singleton<EnemiesManager>
{
    public List<Entity> enemies;

    private void OnEnable()
    {
        if (enemies != null)
        {
            foreach (var entity in enemies)
            {
                entity.OnAbilityUsed += HandleAbilityUsed;
            }
        }
    }

    private void OnDisable()
    {
        if (enemies != null)
        {
            foreach (var entity in enemies)
            {
                entity.OnAbilityUsed -= HandleAbilityUsed;
            }
        }
    }

    private void HandleAbilityUsed(Entity entity)
    {
        //fazer com que colete entidades com a interface ICaptureAbilities
    }
}