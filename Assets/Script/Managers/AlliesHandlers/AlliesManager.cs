using System.Collections.Generic;
using Entities;
using UnityEngine;

public class AlliesManager : Singleton<AlliesManager>
{
    public Transform areaRect;
    public Transform startPosition;
    public AlliesQueueAnimation queueAnimation;
    public int maxAllies = 8;
    public TeamData teamData;

    [Space]

    [ReadOnly]public List<Vector2> positions = new();

    [Space]

    [SerializeField][ReadOnly] private List<Entity> alliesPrefabs = new();

    public void AllyKilled(Entity ally)
    {
        queueAnimation.activeAllies.Remove(ally);
    }

    protected override void Init()
    {
        alliesPrefabs.Clear();
        foreach (GameObject ally in teamData.team)
        {
            alliesPrefabs.Add(ally.GetComponent<Entity>());
        }
    }

    public void CreateAllies()
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

        float positionWidth = availableWidth / maxAllies;

        AdjustAllyQuantity();

        float startX = areaRect.position.x + (availableWidth / 2);
        float yPosition = areaRect.position.y;

        for (int i = 1; i < maxAllies + 1; i++)
        {
            float positionX = startX - i * positionWidth;
            Vector2 position = new(positionX, yPosition);
            positions.Add(position);
        }
    }

    private void AdjustAllyQuantity()
    {
        while(alliesPrefabs.Count > maxAllies)
        {
            alliesPrefabs.RemoveAt(alliesPrefabs.Count - 1);
        }

    }

    private void InstantiateAllies()
    {
        var i = 0;
        foreach(var entity in alliesPrefabs)
        {
            Entity ally = Instantiate(entity, startPosition.position, Quaternion.identity, startPosition);
            queueAnimation.EnqueueAlly(ally, positions[i]);
            ++i;
        }
    }
}