using Chase.Table;
using System;
using UnityEngine;

#region Class&Struct
[Serializable]
public struct DetailBox
{
    public BoxManage[] boxManages;
}
#endregion

#region Enum
public enum ESelectStartColor { FirstColor = -1, SecondColor = 1 }
public enum EPieces { Pawn, Rook, Knight, Bishop, Queen, King }
public enum ESelectGame { Chase, Checkers }
#endregion
