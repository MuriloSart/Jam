using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Entities;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class AlliesQueueAnimation : MonoBehaviour
{
    public float animationTime = 1f;

    private Queue<AllyAnimationData> animationQueue = new();
    private bool isAnimating = false;

    [ReadOnly] public List<Entity> activeAllies = new();

    public event System.Action OnAllAnimationsComplete;

    private class AllyAnimationData
    {
        public Entity Ally { get; }
        public Vector3 TargetPosition { get; }

        public AllyAnimationData(Entity ally, Vector3 targetPosition)
        {
            Ally = ally;
            TargetPosition = targetPosition;
        }
    }

    public void EnqueueAlly(Entity allyTransform, Vector3 targetPosition)
    {
        activeAllies.Add(allyTransform);
        animationQueue.Enqueue(new AllyAnimationData(allyTransform, targetPosition));

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

            if (animationData.Ally != null)
            {
                animationData.Ally.transform.DOMove(animationData.TargetPosition, animationTime);
                yield return new WaitForSeconds(animationTime / 5);
            }
        }

        isAnimating = false;

        OnAllAnimationsComplete?.Invoke();
    }

    public void VerifyAndReorganize()
    {
        if (activeAllies.Count <= 0) SceneManager.LoadScene(0);

        for (int i = activeAllies.Count - 1; i >= 0; i--)
        {
            if (activeAllies[i].gameObject.IsDestroyed())
            {
                activeAllies.RemoveAt(i);
            }
        }

        for (int i = 0; i < activeAllies.Count; i++)
        {
            if (AlliesManager.Instance.positions != null && i < AlliesManager.Instance.positions.Count)
            {
                Vector3 newPosition = AlliesManager.Instance.positions[i];
                activeAllies[i].transform.DOMove(newPosition, animationTime);
            }
        }

        OnAllAnimationsComplete?.Invoke();
    }
}
