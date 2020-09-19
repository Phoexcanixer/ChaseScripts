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
            KnightInstanc(_allPieces.Where(item => item.ePieces.Equals(EPieces.Knight)).First());
            return this;
        }
        void PawnInstanc(BasePieces pawn)
        {
            PawnSpawn(ESelectStartColor.FirstColor, 1, BoardManage.instance.firstPlayerMat, allPiecesFirstPlayers); // PawnLineFirstPlayer
            PawnSpawn(ESelectStartColor.SecondColor, 6, BoardManage.instance.secondPlayerMat, allPiecesSecondPlayers); // PawnLineSecondPlayer

            void PawnSpawn(ESelectStartColor eSelectStartColor, int slot, Material mat, List<BasePieces> basePieces)
            {
                for (int i = 0; i < BoardManage.instance.detailBoxes[slot].boxManages.Length; i++)
                {
                    BasePieces _pieces = Instantiate(pawn, BoardManage.instance.detailBoxes[slot].boxManages[i].transform);
                    _pieces.eSelectSide = eSelectStartColor;
                    _pieces.meshRdr.material = mat;
                    basePieces.Add(_pieces);
                }
            }
        }
        void RookInstanc(BasePieces rook)
        {
            SpawnPieceTwin(ESelectStartColor.FirstColor, rook, Vector2Int.zero, new Vector2Int(0, 7), BoardManage.instance.firstPlayerMat, allPiecesFirstPlayers); // RookLineFirstPlayer
            SpawnPieceTwin(ESelectStartColor.SecondColor, rook, new Vector2Int(7, 0), new Vector2Int(7, 7), BoardManage.instance.secondPlayerMat, allPiecesSecondPlayers); // RookLineSecondPlayer

        }
        void KnightInstanc(BasePieces knight)
        {
            SpawnPieceTwin(ESelectStartColor.FirstColor, knight, new Vector2Int(0, 1), new Vector2Int(0, 6), BoardManage.instance.firstPlayerMat, allPiecesFirstPlayers); // RookLineFirstPlayer
            SpawnPieceTwin(ESelectStartColor.SecondColor, knight, new Vector2Int(7, 1), new Vector2Int(7, 6), BoardManage.instance.secondPlayerMat, allPiecesSecondPlayers); // RookLineSecondPlayer
        }
        void SpawnPieceTwin(ESelectStartColor eSelectStartColor, BasePieces piece, Vector2Int slotFirst, Vector2Int slotLast, Material mat, List<BasePieces> basePieces)
        {
            Spawn(BoardManage.instance.detailBoxes[slotFirst.x].boxManages[slotFirst.y].transform);
            Spawn(BoardManage.instance.detailBoxes[slotLast.x].boxManages[slotLast.y].transform);

            void Spawn(Transform parentPiece)
            {
                BasePieces _pieces = Instantiate(piece, parentPiece);
                _pieces.eSelectSide = eSelectStartColor;
                _pieces.meshRdr.material = mat;
                basePieces.Add(_pieces);
            }
        }
    }
}
