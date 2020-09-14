namespace Chase.Table
{
    using System.Linq;
    using UnityEngine;

    public class SetPositionBox : MonoBehaviour
    {
        public ESelectStartColor eSelectStartColor;
        public Material[] allMats;
        [ContextMenu("SetPosition")]
        void SetPos()
        {
            Material _first = null, _second = null;
            SetMat(ref _first, ref _second);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = i % 2 == 0 ? _first : _second;
                transform.GetChild(i).transform.localPosition = new Vector3(i, 0, 0);
            }
        }
        void SetMat(ref Material first, ref Material second)
        {
            switch (eSelectStartColor)
            {
                case ESelectStartColor.FirstColor:
                    first = allMats.First();
                    second = allMats.Last();
                    break;
                default:
                    first = allMats.Last();
                    second = allMats.First();
                    break;
            }
        }
    }
}
