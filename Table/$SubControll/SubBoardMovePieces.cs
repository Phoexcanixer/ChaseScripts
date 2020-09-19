namespace Chase.Table
{
    using Chase.Pieces;
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
                case EPieces.Pawn: PawnMove(); break;
                case EPieces.Rook: RookMove(); break;
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
        void PawnMove()
        {
            int _slotPlayer = _side.Equals(ESelectStartColor.FirstColor) ? _slot.x + 1 : _slot.x - 1;
            if (BoardManage.instance.detailBoxes.CheckOutOfRange(_slotPlayer))
            {
                // Up
                if (BoardManage.instance.detailBoxes[_slotPlayer].boxManages[_slot.y].transform.childCount <= 0)
                {
                    _allSlot.Add(new Vector2Int(_slotPlayer, _slot.y));
                }
                // Left
                if (BoardManage.instance.detailBoxes[_slotPlayer].boxManages.CheckOutOfRange(_slot.y - 1))
                {
                    var _piece = BoardManage.instance.detailBoxes[_slotPlayer].boxManages[_slot.y - 1].GetPieces();
                    if (BoardManage.instance.detailBoxes[_slotPlayer].boxManages[_slot.y - 1].transform.childCount > 0 && _piece != null && !_piece.eSelectSide.Equals(_side))
                    {
                        _allSlot.Add(new Vector2Int(_slotPlayer, _slot.y - 1));
                    }
                }
                // Right
                if (BoardManage.instance.detailBoxes[_slotPlayer].boxManages.CheckOutOfRange(_slot.y + 1))
                {
                    var _piece = BoardManage.instance.detailBoxes[_slotPlayer].boxManages[_slot.y + 1].GetPieces();
                    if (BoardManage.instance.detailBoxes[_slotPlayer].boxManages[_slot.y + 1].transform.childCount > 0 && _piece != null && !_piece.eSelectSide.Equals(_side))
                    {
                        _allSlot.Add(new Vector2Int(_slotPlayer, _slot.y + 1));
                    }
                }
                CheckInteractBoard();
            }
        }
        void RookMove()
        {
            int _slotX = 1;
            int _slotY = 1;

            //Check UP
            while (BoardManage.instance.detailBoxes.CheckOutOfRange(_slot.x + _slotX))
            {
                int _slotUp = _slot.x + _slotX;
                BasePieces _piece = BoardManage.instance.detailBoxes[_slotUp].boxManages[_slot.y].GetPieces();
                if (!_piece)
                {
                    _allSlot.Add(new Vector2Int(_slotUp, _slot.y));
                    _slotX++;
                }
                else
                {
                    if (!_piece.eSelectSide.Equals(_side))
                        _allSlot.Add(new Vector2Int(_slotUp, _slot.y));

                    break;
                }
            }
            //Check Down
            _slotX = 1;
            while (BoardManage.instance.detailBoxes.CheckOutOfRange(_slot.x - _slotX))
            {
                int _slotDown = _slot.x - _slotX;
                BasePieces _piece = BoardManage.instance.detailBoxes[_slotDown].boxManages[_slot.y].GetPieces();
                if (!_piece)
                {
                    _allSlot.Add(new Vector2Int(_slotDown, _slot.y));
                    _slotX++;
                }
                else
                {
                    if (!_piece.eSelectSide.Equals(_side))
                        _allSlot.Add(new Vector2Int(_slotDown, _slot.y));

                    break;
                }
            }
            //Check Right
            while (BoardManage.instance.detailBoxes[_slot.x].boxManages.CheckOutOfRange(_slot.y + _slotY))
            {
                int _slotRight = _slot.y + _slotY;
                BasePieces _piece = BoardManage.instance.detailBoxes[_slot.x].boxManages[_slotRight].GetPieces();
                if (!_piece)
                {
                    _allSlot.Add(new Vector2Int(_slot.x, _slotRight));
                    _slotY++;
                }
                else
                {
                    if (!_piece.eSelectSide.Equals(_side))
                        _allSlot.Add(new Vector2Int(_slot.x, _slotRight));

                    break;
                }
            }
            //Check Left
            _slotY = 1;
            while (BoardManage.instance.detailBoxes[_slot.x].boxManages.CheckOutOfRange(_slot.y - _slotY))
            {
                int _slotRight = _slot.y - _slotY;
                BasePieces _piece = BoardManage.instance.detailBoxes[_slot.x].boxManages[_slotRight].GetPieces();
                if (!_piece)
                {
                    _allSlot.Add(new Vector2Int(_slot.x, _slotRight));
                    _slotY++;
                }
                else
                {
                    if (!_piece.eSelectSide.Equals(_side))
                        _allSlot.Add(new Vector2Int(_slot.x, _slotRight));

                    break;
                }
            }
            CheckInteractBoard();
        }

    }
}
