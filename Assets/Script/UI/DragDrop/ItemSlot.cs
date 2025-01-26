using UnityEngine;
using UnityEngine.EventSystems;

namespace Ui
{
    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        [ReadOnly] public GameObject entity;
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                var dragDrop = eventData.pointerDrag.GetComponent<DragDrop>();
                if (dragDrop != null)
                {
                    entity = eventData.pointerDrag.GetComponent<EntityHolder>().entity;

                    dragDrop.currentParent = this.transform;

                    dragDrop.SetInSlot(true);
                }
            }
        }

        private void Update()
        {
            if(transform.childCount <= 0) entity = null;
        }
    }
}

