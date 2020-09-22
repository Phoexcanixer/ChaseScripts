namespace Chess.Pieces
{
    using UnityEngine;
    public class KingCheck : MonoBehaviour
    {
        ESelectStartColor _selectStartColor;
        void Start()
        {
            _selectStartColor = GetComponent<BasePieces>().eSelectSide;
            BoardManage.instance.chessManage.CallBackCheckKingCheckmate += CheckPiecesEatKing;
        }
        void CheckPiecesEatKing()
        {
            Debug.Log($"{_selectStartColor} -- Check");
        }
        void OnDestroy()
        {
            Debug.Log($"{ ~(_selectStartColor - 1)} --- Win");
        }
    }
}
