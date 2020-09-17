namespace Chase
{
    using Chase.Pieces;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    public class ChaseManage : MonoBehaviour
    {
        public List<BasePieces> allPiecesFirstPlayers;
        public List<BasePieces> allPiecesSecondPlayers;
        public void ExecuteStart()
        {
            BasePieces[] _allPieces = Resources.LoadAll<BasePieces>("Pieces");
            PawnInstanc(_allPieces.Where(item => item.ePieces.Equals(EPieces.Pawn)).First());
        }
        void PawnInstanc(BasePieces pawn)
        {
            for (int i = 0; i < BoardManage.instance.detailBoxes[1].boxManages.Length; i++) // PawnLineFirstPlayer
            {
                BasePieces _pieces = Instantiate(pawn, BoardManage.instance.detailBoxes[1].boxManages[i].transform);
                allPiecesFirstPlayers.Add(_pieces);
            }

            for (int i = 0; i < BoardManage.instance.detailBoxes[6].boxManages.Length; i++) // PawnLineSecondPlayer
            {
                BasePieces _pieces = Instantiate(pawn, BoardManage.instance.detailBoxes[6].boxManages[i].transform);
                _pieces.eSelectSide = ESelectStartColor.SecondColor;
                allPiecesSecondPlayers.Add(_pieces);
            }
        }
    }
}
