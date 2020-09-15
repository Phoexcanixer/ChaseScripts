namespace Chase.Pieces
{
    using Chase.Table;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public abstract class BasePieces : MonoBehaviour, IPointerClickHandler
    {
        public EPieces ePieces;
        public ESelectStartColor eSelectSide;
        public bool isClick;
        public abstract void Move();
        public void OnPointerClick(PointerEventData eventData)
        {
            GetComponentInChildren<MeshRenderer>().material.color = (isClick = !isClick) ? Color.red : Color.white;
            BoardManage.instance.subBoardMovePieces.CheckMovePieces(ePieces, eSelectSide, GetComponentInParent<BoxManage>().slot);
            gameObject.layer = 2;
        }
    }
}
