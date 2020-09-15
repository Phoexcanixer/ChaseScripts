namespace Chase.Table
{
    using UnityEngine;
    using Common.Singleton;
    public class BoardManage : ExSingleton<BoardManage>
    {
        public DetailBox[] detailBoxes;
        public Material guideMat;
        #region SubControll
        public SubBoardMovePieces subBoardMovePieces = new SubBoardMovePieces();
        #endregion
        #region ContextMenu
        [ContextMenu("SetSlotBoxes")]
        void SetSlotBoxes()
        {
            for (int i = 0; i < detailBoxes.Length; i++)
            {
                for (int j = 0; j < detailBoxes[i].boxManages.Length; j++)
                {
                    detailBoxes[i].boxManages[j].slot = new Vector2Int(i, j);
                    detailBoxes[i].boxManages[j].name = $"Box[{i}][{j}]";
                }
            }
        }
        #endregion
    }
}
