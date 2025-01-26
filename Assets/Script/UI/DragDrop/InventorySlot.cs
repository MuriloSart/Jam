using UnityEngine;
using UnityEngine.EventSystems;

namespace Ui
{
    public class InventorySlot : MonoBehaviour, IDropHandler
    {
        [ReadOnly] public DragDrop entity;

        private void Start()
        {
            foreach (Transform child in transform)
            {
                entity = child.gameObject.GetComponent<DragDrop>();
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            var dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();

            if (eventData.pointerDrag != null && dragDrop == entity)
            {

                dragDrop.currentParent = this.transform;

                dragDrop.SetInSlot(false);
            }
        }
    }
}


