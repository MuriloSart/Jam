using System.Collections.Generic;
using UnityEngine;
using Entities;

public class EnemiesManager : Singleton<EnemiesManager>
{
    public Transform areaRect;
    public Transform startPosition;
    public EnemiesQueueAnimation queueAnimation;
    public int maxEnemies = 8;

    [ReadOnly] public List<Vector2> positions = new();

    [SerializeField] private List<Entity> enemiesPrefabs = new();

    public void EnemyKilled(Entity enemy)
    {
        queueAnimation.activeEnemies.Remove(enemy);
    }

    public void CreateEnemies()
    {
        ArrangePositions();
        InstantiateEnemies();
    }

    private void ArrangePositions()
    {
        if (areaRect == null)
        {
            Debug.LogError("Nenhuma área definida! Atribua um Transform com SpriteRenderer");
            return;
        }

        float availableWidth = areaRect.transform.localScale.x;

        AdjustEnemiesQuantity();

        float positionWidth = availableWidth / maxEnemies;

        float startX = areaRect.position.x - (availableWidth / 2);
        float yPosition = areaRect.position.y;

        for (int i = 1; i < maxEnemies + 1; i++)
        {
            float positionX = startX + i * positionWidth;
            Vector2 position = new(positionX, yPosition);
            positions.Add(position);
        }
    }

    private void AdjustEnemiesQuantity()
    {
        while (enemiesPrefabs.Count > maxEnemies)
        {
            enemiesPrefabs.RemoveAt(enemiesPrefabs.Count - 1);
        }
    }

    private void InstantiateEnemies()
    {
        var i = 0;
        foreach (var entity in enemiesPrefabs)
        {
            Entity enemy = Instantiate(entity, startPosition.position, Quaternion.identity, startPosition);
            queueAnimation.EnqueueEnemy(enemy, positions[i]);
            ++i;
        }
    }
}
