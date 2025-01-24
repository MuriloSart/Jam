using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemiesQueueAnimation : MonoBehaviour
{
    public float animationTime = 1f;

    private Queue<EnemyAnimationData> animationQueue = new();
    private bool isAnimating = false;

    private List<Transform> activeAEnemies = new();

    private class EnemyAnimationData
    {
        public Transform EnemyTransform { get; }
        public Vector3 TargetPosition { get; }

        public EnemyAnimationData(Transform enemyTransform, Vector3 targetPosition)
        {
            EnemyTransform = enemyTransform;
            TargetPosition = targetPosition;
        }
    }

    public void EnqueueEnemy(Transform enemyTransform, Vector3 targetPosition)
    {
        activeAEnemies.Add(enemyTransform);
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

            if (animationData.EnemyTransform != null)
            {
                animationData.EnemyTransform.DOMove(animationData.TargetPosition, animationTime);
                yield return new WaitForSeconds(animationTime / 5);
            }
        }

        isAnimating = false;
    }

    private void Update()
    {
        VerifyAndReorganize();
    }

    public void VerifyAndReorganize()
    {
        for (int i = activeAEnemies.Count - 1; i >= 0; i--)
        {
            if (activeAEnemies[i] == null)
            {
                activeAEnemies.RemoveAt(i);
            }
        }

        for (int i = 0; i < activeAEnemies.Count; i++)
        {
            if (EnemiesManager.Instance.positions != null && i < EnemiesManager.Instance.positions.Count)
            {
                Vector3 newPosition = EnemiesManager.Instance.positions[i];
                activeAEnemies[i].DOMove(newPosition, animationTime);
            }
        }
    }
}
