namespace Chase.Pieces
{
    using Chase.Table;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public abstract class BasePieces : MonoBehaviour, IPointerClickHandler
    {
        public EPieces ePieces;
        public ESelectStartColor eSelectSide;
        public bool isClick;

        MeshRenderer _meshRdr;
        void Awake() => _meshRdr = GetComponentInChildren<MeshRenderer>();
        public virtual void Move()
        {
            transform.SetParent(BoardManage.instance.presentTargetBox.transform);
            transform.localPosition = Vector2.zero;
            
            isClick = false;
            _meshRdr.material.color = Color.white;
            BoardManage.instance.subBoardMovePieces.ClearBorad();
            BoardManage.instance.presentPieces = null;
            BoardManage.instance.presentTargetBox = null;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _meshRdr.material.color = (isClick = !isClick) ? Color.blue : Color.white;
            BoardManage.instance.subBoardMovePieces.CheckMovePieces(ePieces, eSelectSide, GetComponentInParent<BoxManage>().slot);
            BoardManage.instance.presentPieces = this;
        }
    }
}
