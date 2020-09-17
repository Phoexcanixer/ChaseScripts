namespace Chase.Pieces
{
    using Chase.Table;
    using UnityEngine;
    using UnityEngine.EventSystems;
    public class BasePieces : MonoBehaviour, IPointerClickHandler
    {
        public EPieces ePieces;
        public ESelectStartColor eSelectSide;
        [HideInInspector] public MeshRenderer meshRdr;
        public bool isClick;
        void Awake() => meshRdr = GetComponentInChildren<MeshRenderer>();
        public virtual void Move()
        {
            BoardManage.instance.presentTargetBox.ClearChild();
            transform.SetParent(BoardManage.instance.presentTargetBox.transform);
            transform.localPosition = Vector2.zero;

            DefaulValue();
            BoardManage.instance.subBoardMovePieces.ClearBorad();
            BoardManage.instance.presentPieces = null;
            BoardManage.instance.presentTargetBox = null;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            meshRdr.material.color = (isClick = !isClick) ? Color.blue : Color.white;
            BoardManage.instance.subBoardMovePieces.CheckMovePieces(ePieces, eSelectSide, GetComponentInParent<BoxManage>().slot);
            BoardManage.instance.presentPieces?.DefaulValue();
            BoardManage.instance.presentPieces = this;
        }
        public void DefaulValue()
        {
            isClick = false;
            meshRdr.material.color = Color.white;
        }
    }
}
