using System.Collections.Generic;
using UnityEngine;
using Entities;

public class EnemiesManager : Singleton<EnemiesManager>
{
    public Transform areaRect;
    public Transform startPosition;
    public List<Entity> enemiesQueue = new();
    public int maxEnemies = 8;
    public EnemiesQueueAnimation queueAnimation;

    [ReadOnly] public List<Vector2> positions = new();

    private void Start()
    {
        ArrangeEntities();
        InstantiateEnemies();
    }

    public void EnemyKilled(Entity enemy)
    {
        enemiesQueue.Remove(enemy);
        queueAnimation.VerifyAndReorganize();
    }

    private void ArrangeEntities()
    {
        if (areaRect == null)
        {
            Debug.LogError("Nenhuma área definida! Atribua um Transform com SpriteRenderer");
            return;
        }

        float availableWidth = areaRect.transform.localScale.x;

        int entityCount = Mathf.Min(enemiesQueue.Count, maxEnemies);

        float positionWidth = availableWidth / maxEnemies;

        float startX = areaRect.position.x + (availableWidth / 2);
        float yPosition = areaRect.position.y;

        for (int i = 1; i < maxEnemies + 1; i++)
        {
            float positionX = startX - i * positionWidth;
            Vector2 position = new(positionX, yPosition);
            positions.Add(position);
        }
    }

    private void InstantiateEnemies()
    {
        var i = 0;
        foreach (var entity in enemiesQueue)
        {
            Entity enemy = Instantiate(entity, startPosition.position, Quaternion.identity, startPosition);
            queueAnimation.EnqueueEnemy(enemy.transform, positions[i]);
            ++i;
        }
    }
}
