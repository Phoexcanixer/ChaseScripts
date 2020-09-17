namespace Chase.Table
{
    using Common.ArrayList;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    public class SubBoardMovePieces
    {
        Vector2Int _slot;
        List<Vector2Int> _allSlot;
        ESelectStartColor _side;
        public void ClearBorad()
        {
            for (int i = 0; i < BoardManage.instance.detailBoxes.Length; i++)
            {
                for (int j = 0; j < BoardManage.instance.detailBoxes[i].boxManages.Length; j++)
                {
                    BoardManage.instance.detailBoxes[i].boxManages[j].ShowPathMove(false);
                    BoardManage.instance.detailBoxes[i].boxManages[j].ShowGuide(false);
                }
            }
        }
        public void CheckMovePieces(EPieces ePieces, ESelectStartColor eSelectSide, Vector2Int slot)
        {
            _allSlot = new List<Vector2Int>();
            _slot = slot;
            _side = eSelectSide;

            switch (ePieces)
            {
                case EPieces.Pawn: Pawn(); break;
                case EPieces.Rook:
                    break;
                case EPieces.Knight:
                    break;
                case EPieces.Bishop:
                    break;
                case EPieces.Queen:
                    break;
                case EPieces.King:
                    break;
                default:
                    break;
            }
        }
        void Pawn()
        {
            if (BoardManage.instance.detailBoxes.CheckOutOfRange(_slot.x + 1))
            {
                // Up
                if (BoardManage.instance.detailBoxes[_slot.x + 1].boxManages[_slot.y].transform.childCount <= 0)
                {
                    _allSlot.Add(new Vector2Int(_slot.x + 1, _slot.y));
                }
                // Left
                if (BoardManage.instance.detailBoxes[_slot.x + 1].boxManages.CheckOutOfRange(_slot.y - 1))
                {
                    var _piece = BoardManage.instance.detailBoxes[_slot.x + 1].boxManages[_slot.y - 1].GetPieces();
                    if (BoardManage.instance.detailBoxes[_slot.x + 1].boxManages[_slot.y - 1].transform.childCount > 0 && _piece != null && !_piece.eSelectSide.Equals(_side))
                    {
                        _allSlot.Add(new Vector2Int(_slot.x + 1, _slot.y - 1));
                    }
                }
                // Right
                if (BoardManage.instance.detailBoxes[_slot.x + 1].boxManages.CheckOutOfRange(_slot.y + 1))
                {
                    var _piece = BoardManage.instance.detailBoxes[_slot.x + 1].boxManages[_slot.y + 1].GetPieces();
                    if (BoardManage.instance.detailBoxes[_slot.x + 1].boxManages[_slot.y + 1].transform.childCount > 0 && _piece != null && !_piece.eSelectSide.Equals(_side))
                    {
                        _allSlot.Add(new Vector2Int(_slot.x + 1, _slot.y + 1));
                    }
                }

                CheckInteractBoard();
            }
        }
        void CheckInteractBoard()
        {
            _allSlot = _allSlot.OrderBy(item => item.x).ThenBy(item => item.y).ToList();
            for (int i = 0; i < BoardManage.instance.detailBoxes.Length; i++)
            {
                for (int j = 0; j < BoardManage.instance.detailBoxes[i].boxManages.Length; j++)
                {
                    BoardManage.instance.detailBoxes[i].boxManages[j].ShowPathMove(false);
                    BoardManage.instance.detailBoxes[i].boxManages[j].ShowGuide(false);
                    CheckMove(BoardManage.instance.detailBoxes[i].boxManages[j].slot);
                }
            }
            void CheckMove(Vector2Int slot)
            {
                if (_allSlot.Count <= 0)
                    return;

                Vector2Int _tempSlot = new Vector2Int();
                _allSlot.ForEach(item =>
                {
                    if (item == slot)
                    {
                        BoardManage.instance.detailBoxes[item.x].boxManages[item.y].ShowPathMove(true);
                        BoardManage.instance.detailBoxes[item.x].boxManages[item.y].ShowGuide(true);
                        _tempSlot = item;
                    }
                });
                _allSlot.Remove(_tempSlot);
            }
        }

    }
}
