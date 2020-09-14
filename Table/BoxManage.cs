namespace Chase.Table
{
    using Chase.Pieces;
    using UnityEngine;
    using UnityEngine.EventSystems;
    public class BoxManage : MonoBehaviour, IPointerClickHandler
    {
        public Vector2Int slot;
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log($"{name}: {slot}");
            if (transform.childCount > 0)
            {
                GetComponentInChildren<BasePieces>()?.OnPointerClick(eventData);
            }
            else
                GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
