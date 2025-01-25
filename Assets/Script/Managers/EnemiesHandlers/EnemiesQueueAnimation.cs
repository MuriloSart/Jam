using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Entities;
using Unity.VisualScripting;

public class EnemiesQueueAnimation : MonoBehaviour
{
    public float animationTime = 1f;

    private Queue<EnemyAnimationData> animationQueue = new();
    private bool isAnimating = false;

    [ReadOnly] public List<Entity> activeEnemies = new();

    public event System.Action OnAllAnimationsComplete;

    private class EnemyAnimationData
    {
        public Entity Enemy { get; }
        public Vector3 TargetPosition { get; }

        public EnemyAnimationData(Entity enemy, Vector3 targetPosition)
        {
            Enemy = enemy;
            TargetPosition = targetPosition;
        }
    }

    public void EnqueueEnemy(Entity enemyTransform, Vector3 targetPosition)
    {
        activeEnemies.Add(enemyTransform);
        animationQueue.Enqueue(new EnemyAnimationData(enemyTransform, targetPosition));

        if (!isAnimating)
        {
            StartCoroutine(ProcessAnimationQueue());
        }
    }

    private IEnumerator ProcessAnimationQueue()
    {
        isAnimating = true;

        while (animationQueue.Count > 0)
        {
            var animationData = animationQueue.Dequeue();

            if (animationData.Enemy != null)
            {
                animationData.Enemy.transform.DOMove(animationData.TargetPosition, animationTime);
                yield return new WaitForSeconds(animationTime / 5);
            }
        }

        isAnimating = false;

        OnAllAnimationsComplete?.Invoke();
    }

    public void VerifyAndReorganize()
    {
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i].gameObject.IsDestroyed())
            {
                activeEnemies.RemoveAt(i);
            }
        }

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            if (EnemiesManager.Instance.positions != null && i < EnemiesManager.Instance.positions.Count)
            {
                Vector3 newPosition = EnemiesManager.Instance.positions[i];
                activeEnemies[i].transform.DOMove(newPosition, animationTime);
            }
        }
        OnAllAnimationsComplete?.Invoke();
    }
}
