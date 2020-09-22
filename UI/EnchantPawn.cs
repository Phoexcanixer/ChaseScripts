namespace Chess
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class EnchantPawn : MonoBehaviour
    {
        public static Action<bool> CallBackSelectEnchant { get; set; }
        public Toggle _baseTog;
        Canvas _thisCvs;
        void Awake()
        {
            _thisCvs = GetComponent<Canvas>();
            CallBackSelectEnchant = EnchantPawnSelect;
        }
        void EnchantPawnSelect(bool isShow)
        {
            _thisCvs.enabled = isShow;

            if (!isShow)
            {
                _baseTog.isOn = true;
                BoardManage.instance.presentPieces.DefaulValue();
                BoardManage.instance.SwichTurn();
            }
        }
    }
}
