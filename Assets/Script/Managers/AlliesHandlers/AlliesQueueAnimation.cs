using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AlliesQueueAnimation : MonoBehaviour
{
    public float animationTime = 1f;

    private Queue<AllyAnimationData> animationQueue = new();
    private bool isAnimating = false;

    private List<Transform> activeAllies = new();

    private class AllyAnimationData
    {
        public Transform AllyTransform { get; }
        public Vector3 TargetPosition { get; }

        public AllyAnimationData(Transform allyTransform, Vector3 targetPosition)
        {
            AllyTransform = allyTransform;
            TargetPosition = targetPosition;
        }
    }

    public void EnqueueAlly(Transform allyTransform, Vector3 targetPosition)
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

            if (animationData.AllyTransform != null)
            {
                animationData.AllyTransform.DOMove(animationData.TargetPosition, animationTime);
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
        for (int i = activeAllies.Count - 1; i >= 0; i--)
        {
            if (activeAllies[i] == null)
            {
                activeAllies.RemoveAt(i);
            }
        }

        for (int i = 0; i < activeAllies.Count; i++)
        {
            if (AlliesManager.Instance.positions != null && i < AlliesManager.Instance.positions.Count)
            {
                Vector3 newPosition = AlliesManager.Instance.positions[i];
                activeAllies[i].DOMove(newPosition, animationTime);
            }
        }
    }
}
