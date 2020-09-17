using Chase.Table;
using System;

#region Class&Struct
[Serializable]
public struct DetailBox
{
    public BoxManage[] boxManages;
}
#endregion

#region Enum
public enum ESelectStartColor { FirstColor, SecondColor }
public enum EPieces { Pawn, Rook, Knight, Bishop, Queen, King }
public enum ESelectGame { Chase, Checkers }
#endregion
