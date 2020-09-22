namespace Chess.Pieces
{
    using Chess.Table;
    using UnityEngine;
    using UnityEngine.EventSystems;
    public class BasePieces : MonoBehaviour, IPointerClickHandler
    {
        public EPieces ePieces;
        public ESelectStartColor eSelectSide;
        [HideInInspector] public MeshRenderer meshRdr;
        public bool isClick, isFirstMove;
        void Awake() => meshRdr = GetComponentInChildren<MeshRenderer>();
        void Start()
        {
            if (ePieces.Equals(EPieces.King))
                gameObject.AddComponent<KingCheck>();
        }
        public virtual void Move()
        {
            isFirstMove = false;
            BoardManage.instance.presentTargetBox.ClearChild();
            transform.SetParent(BoardManage.instance.presentTargetBox.transform);
            transform.localPosition = Vector2.zero;

            if (BoardManage.instance.presentTargetBox.isPawnEnchant && ePieces.Equals(EPieces.Pawn))
                EnchantPawn.CallBackSelectEnchant?.Invoke(true);
            else
            {
                DefaulValue();
                BoardManage.instance.SwichTurn();
            }
            // BoardManage.instance.chessManage.CallBackCheckKingCheckmate?.Invoke();
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isClick && BoardManage.instance.eTurnPlayer.Equals(eSelectSide))
            {
                isClick = !isClick;
                meshRdr.material = eSelectSide.Equals(ESelectStartColor.FirstColor) ? BoardManage.instance.selectionFirstMat : BoardManage.instance.selectionSecondMat;
                BoardManage.instance.subBoardMovePieces.CheckMovePieces(ePieces, eSelectSide, GetComponentInParent<BoxManage>().slot);
                BoardManage.instance.presentPieces?.DefaulValue();
                BoardManage.instance.presentPieces = this;
            }
        }
        public void DefaulValue()
        {
            isClick = false;
            meshRdr.material = eSelectSide.Equals(ESelectStartColor.FirstColor) ? BoardManage.instance.firstPlayerMat : BoardManage.instance.secondPlayerMat;
        }
    }
}
