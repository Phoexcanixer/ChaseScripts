namespace Chase
{
    using Chase.Pieces;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    public class ChaseManage : MonoBehaviour
    {
        public List<BasePieces> allPiecesFirstPlayers = new List<BasePieces>();
        public List<BasePieces> allPiecesSecondPlayers = new List<BasePieces>();
        public ChaseManage ExecuteStart()
        {
            BasePieces[] _allPieces = Resources.LoadAll<BasePieces>("Pieces");
            PawnInstanc(_allPieces.Where(item => item.ePieces.Equals(EPieces.Pawn)).First());
            RookInstanc(_allPieces.Where(item => item.ePieces.Equals(EPieces.Rook)).First());
            return this;
        }
        void PawnInstanc(BasePieces pawn)
        {
            PawnSpawn(ESelectStartColor.FirstColor, 1, BoardManage.instance.firstPlayerMat); // PawnLineFirstPlayer
            PawnSpawn(ESelectStartColor.SecondColor, 6, BoardManage.instance.secondPlayerMat); // PawnLineSecondPlayer

            void PawnSpawn(ESelectStartColor eSelectStartColor, int slot, Material mat)
            {
                for (int i = 0; i < BoardManage.instance.detailBoxes[slot].boxManages.Length; i++)
                {
                    BasePieces _pieces = Instantiate(pawn, BoardManage.instance.detailBoxes[slot].boxManages[i].transform);
                    _pieces.eSelectSide = eSelectStartColor;
                    _pieces.meshRdr.material = mat;
                    allPiecesFirstPlayers.Add(_pieces);
                }
            }
        }
        void RookInstanc(BasePieces rook)
        {
            RookSpawn(ESelectStartColor.FirstColor, 0, BoardManage.instance.firstPlayerMat); // RookLineFirstPlayer
            RookSpawn(ESelectStartColor.SecondColor, 7, BoardManage.instance.secondPlayerMat); // RookLineSecondPlayer

            void RookSpawn(ESelectStartColor eSelectStartColor, int slot, Material mat)
            {
                Spawn(BoardManage.instance.detailBoxes[slot].boxManages.First().transform);
                Spawn(BoardManage.instance.detailBoxes[slot].boxManages.Last().transform);

                void Spawn(Transform parentPiece)
                {
                    BasePieces _pieces = Instantiate(rook, parentPiece);
                    _pieces.eSelectSide = eSelectStartColor;
                    _pieces.meshRdr.material = mat;
                    allPiecesFirstPlayers.Add(_pieces);
                }
            }
        }
    }
}
