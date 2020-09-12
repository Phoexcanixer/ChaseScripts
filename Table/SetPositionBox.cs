namespace Chase.Table
{
    using System.Linq;
    using UnityEngine;

    public class SetPositionBox : MonoBehaviour
    {
        [Range(1, 2)] public float distancePoint = 1;
        public Material[] allMat;
        public ESelectStartColor eSelectStartColor;

        [ContextMenu("SetPosition")]
        void SetPos()
        {
            Material _first = null, _second = null;
            SetMat(ref _first, ref _second);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().material = i % 2 == 0 ? _first : _second;
                transform.GetChild(i).transform.localPosition = new Vector3(i * distancePoint, 0, 0);
            }
        }
        void SetMat(ref Material first, ref Material second)
        {
            switch (eSelectStartColor)
            {
                case ESelectStartColor.FirstColor:
                    first = allMat.First();
                    second = allMat.Last();
                    break;
                default:
                    first = allMat.Last();
                    second = allMat.First();
                    break;
            }
        }
    }
}
