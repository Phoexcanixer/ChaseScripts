namespace Chase
{
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
    #endregion
}
