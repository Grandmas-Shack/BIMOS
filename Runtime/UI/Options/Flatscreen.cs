using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KadenZombie8.BIMOS.UI.Options
{
    public class Flatscreen : MonoBehaviour
    {
        private Toggle _toggle;

        [SerializeField]
        private Tabs _tabs;

        private void Awake() => _toggle = GetComponentInChildren<Toggle>();

        private void OnEnable() => _toggle.onValueChanged.AddListener(OnValueChanged);

        private void OnDisable() => _toggle.onValueChanged.RemoveListener(OnValueChanged);

        private void OnValueChanged(bool isSelected)
        {
            foreach (var tab in _tabs.Enable)
                tab.SetActive(isSelected);
            foreach (var tab in _tabs.Disable)
                tab.SetActive(!isSelected);
        }
    }

    [Serializable]
    public struct Tabs
    {
        public List<GameObject> Enable;
        public List<GameObject> Disable;
    }
}
