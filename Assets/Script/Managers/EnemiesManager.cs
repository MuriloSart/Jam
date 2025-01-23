using System.Collections.Generic;
using UnityEngine;
using Entities;

public class EnemiesManager : Singleton<EnemiesManager>
{
    public Transform areaRect;
    public List<Entity> enemyQueue = new();
    public int maxEnemies = 8;

    private void Start()
    {
        ArrangeEntities();
    }

    private void ArrangeEntities()
    {
        if (areaRect == null)
        {
            Debug.LogError("Nenhuma área definida! Atribua um Transform com SpriteRenderer");
            return;
        }

        float availableWidth = areaRect.transform.localScale.x;

        int entityCount = Mathf.Min(enemyQueue.Count, maxEnemies);

        float positionWidth = availableWidth / maxEnemies;

        float startX = areaRect.position.x - (availableWidth / 2);
        float yPosition = areaRect.position.y;

        for (int i = 1; i < maxEnemies + 1; i++)
        {
            float positionX = startX + i * positionWidth;
            Vector3 position = new Vector3(positionX, yPosition, 0);

            if (i < entityCount)
            {
                Entity enemy = Instantiate(enemyQueue[i - 1], position, Quaternion.identity, areaRect);
            }
        }
    }

    private void OnEnable()
    {
        if (enemyQueue != null)
        {
            foreach (var entity in enemyQueue)
            {
                entity.OnAbilityUsed += HandleAbilityUsed;
            }
        }
    }

    private void OnDisable()
    {
        if (enemyQueue != null)
        {
            foreach (var entity in enemyQueue)
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
