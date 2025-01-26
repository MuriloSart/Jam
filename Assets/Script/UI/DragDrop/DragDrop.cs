using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    [ReadOnly] public Transform originalParent;
    [ReadOnly] public Transform currentParent;

    private bool isInSlot = false;
    private float doubleClickThreshold = 0.3f;
    private float lastClickTime = 0f;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalParent = transform.parent;
        currentParent = originalParent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        transform.position = Input.mousePosition;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (currentParent != null)
            transform.SetParent(currentParent);
        else
            BackToStart();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        float timeSinceLastClick = Time.time - lastClickTime;

        if (timeSinceLastClick <= doubleClickThreshold) OnDoubleClick();

        lastClickTime = Time.time;
    }

    public void SetInSlot(bool inSlot)
    {
        isInSlot = inSlot;
    }

    private void OnDoubleClick()
    {
        if (isInSlot)
        {
            BackToStart();

            isInSlot = false;

            canvasGroup.blocksRaycasts = true;
        }
    }

    private void BackToStart()
    {
        transform.SetParent(originalParent);

        currentParent = originalParent;
    }
}
