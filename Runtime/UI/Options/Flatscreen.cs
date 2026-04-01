using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace KadenZombie8.BIMOS.UI.Options
{
    public class Flatscreen : MonoBehaviour
    {
        private TMP_Dropdown _dropdown;

        [SerializeField]
        private Tabs _tabs;

        private void Awake() => _dropdown = GetComponentInChildren<TMP_Dropdown>();

        private void OnEnable() => _dropdown.onValueChanged.AddListener(OnValueChanged);

        private void OnDisable() => _dropdown.onValueChanged.RemoveListener(OnValueChanged);

        private void OnValueChanged(int controlType)
        {
            bool isFlatscreen = controlType == 1;

            foreach (var tab in _tabs.Enable)
                tab.SetActive(isFlatscreen);
            foreach (var tab in _tabs.Disable)
                tab.SetActive(!isFlatscreen);
        }
    }

    [Serializable]
    public struct Tabs
    {
        public List<GameObject> Enable;
        public List<GameObject> Disable;
    }
}
