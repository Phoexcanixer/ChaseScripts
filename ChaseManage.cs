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
            //RookInstanc(_allPieces.Where(item => item.ePieces.Equals(EPieces.Rook)).First());
            //KnightInstanc(_allPieces.Where(item => item.ePieces.Equals(EPieces.Knight)).First());
            //BishopInstance(_allPieces.Where(item => item.ePieces.Equals(EPieces.Bishop)).First());
            //QueenInstance(_allPieces.Where(item => item.ePieces.Equals(EPieces.Queen)).First());
            //KingInstance(_allPieces.Where(item => item.ePieces.Equals(EPieces.King)).First());

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
        void BishopInstance(BasePieces bishop)
        {
            SpawnPieceTwin(ESelectStartColor.FirstColor, bishop, new Vector2Int(0, 2), new Vector2Int(0, 5), BoardManage.instance.firstPlayerMat, allPiecesFirstPlayers); // RookLineFirstPlayer
            SpawnPieceTwin(ESelectStartColor.SecondColor, bishop, new Vector2Int(7, 2), new Vector2Int(7, 5), BoardManage.instance.secondPlayerMat, allPiecesSecondPlayers); // RookLineSecondPlayer
        }
        void QueenInstance(BasePieces queen)
        {
            SpawnPieceSingle(ESelectStartColor.FirstColor, queen, new Vector2Int(0, 3), BoardManage.instance.firstPlayerMat, allPiecesFirstPlayers); // RookLineFirstPlayer
            SpawnPieceSingle(ESelectStartColor.SecondColor, queen, new Vector2Int(7, 3), BoardManage.instance.secondPlayerMat, allPiecesSecondPlayers); // RookLineSecondPlayer
        }
        void KingInstance(BasePieces king)
        {
            SpawnPieceSingle(ESelectStartColor.FirstColor, king, new Vector2Int(0, 4), BoardManage.instance.firstPlayerMat, allPiecesFirstPlayers); // RookLineFirstPlayer
            SpawnPieceSingle(ESelectStartColor.SecondColor, king, new Vector2Int(7, 4), BoardManage.instance.secondPlayerMat, allPiecesSecondPlayers); // RookLineSecondPlayer
        }
        void SpawnPieceSingle(ESelectStartColor eSelectStartColor, BasePieces piece, Vector2Int slot, Material mat, List<BasePieces> basePieces)
        {
            Spawn(BoardManage.instance.detailBoxes[slot.x].boxManages[slot.y].transform);
            void Spawn(Transform parentPiece)
            {
                BasePieces _pieces = Instantiate(piece, parentPiece);
                _pieces.eSelectSide = eSelectStartColor;
                _pieces.meshRdr.material = mat;
                basePieces.Add(_pieces);
            }
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
