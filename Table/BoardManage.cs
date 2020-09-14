namespace Chase.Table
{
    using UnityEngine;
    public class BoardManage : MonoBehaviour
    {
        public DetailBox[] detailBoxes;
       
        [ContextMenu("SetSlotBoxes")]
        void SetSlotBoxes()
        {
            for (int i = 0; i < detailBoxes.Length; i++)
            {
                for (int j = 0; j < detailBoxes[i].boxManages.Length; j++)
                {
                    detailBoxes[i].boxManages[j].slot = new Vector2Int(i,j);
                    detailBoxes[i].boxManages[j].name = $"Box[{i}][{j}]";
                }
            }
        }
    }
}
