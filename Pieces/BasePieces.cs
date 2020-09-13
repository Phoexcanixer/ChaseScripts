namespace Chase.Pieces
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    public abstract class BasePieces : MonoBehaviour, IPointerClickHandler
    {
        public bool isClick;
        public abstract void Move();
        public void OnPointerClick(PointerEventData eventData)
        {
            GetComponentInChildren<MeshRenderer>().sharedMaterial.color = (isClick = !isClick) ? Color.red : Color.white;
        }
    }
}
