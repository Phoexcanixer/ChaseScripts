namespace Chase.Table
{
    using UnityEngine;
    using Common.Singleton;
    using Chase.Pieces;

    public class BoardManage : ExSingleton<BoardManage>
    {

        public Material guideMat;
        public DetailBox[] detailBoxes;
        #region Property
        public BasePieces presentPieces { get; set; }
        public BoxManage presentTargetBox { get; set; }
        #endregion
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
