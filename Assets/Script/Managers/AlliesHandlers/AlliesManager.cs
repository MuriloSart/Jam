using System.Collections.Generic;
using Entities;
using UnityEngine;

public class AlliesManager : Singleton<AlliesManager>
{
    public Transform areaRect;
    public Transform startPosition;
    public AlliesQueueAnimation queueAnimation;
    public int maxAllies = 8;
    public List<Entity> alliesQueue = new();

    [ReadOnly]public List<Vector2> positions = new();

    public void AllyKilled(Entity ally)
    {
        alliesQueue.Remove(ally);
        queueAnimation.VerifyAndReorganize();
    }

    private void Start()
    {
        ArrangePositions();
        InstantiateAllies();
    }

    private void ArrangePositions()
    {
        if (areaRect == null)
        {
            Debug.LogError("Nenhuma área definida! Atribua um Transform com SpriteRenderer");
            return;
        }

        float availableWidth = areaRect.transform.localScale.x;

        int entityCount = Mathf.Min(alliesQueue.Count, maxAllies);

        float positionWidth = availableWidth / maxAllies;

        float startX = areaRect.position.x + (availableWidth / 2);
        float yPosition = areaRect.position.y;

        for (int i = 1; i < maxAllies + 1; i++)
        {
            float positionX = startX - i * positionWidth;
            Vector2 position = new(positionX, yPosition);
            positions.Add(position);
        }
    }

    private void InstantiateAllies()
    {
        var i = 0;
        foreach(var entity in alliesQueue)
        {
            Entity ally = Instantiate(entity, startPosition.position, Quaternion.identity, startPosition);
            queueAnimation.EnqueueAlly(ally.transform, positions[i]);
            ++i;
        }
    }
}