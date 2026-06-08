using KadenZombie8.BIMOS.UI.Options;
using UnityEngine;

namespace KadenZombie8.BIMOS.UI
{
    public class ControlType : MonoBehaviour
    {
        private Option<int> _option;

        private void Awake() => _option = GetComponent<Option<int>>();

        private void OnEnable()
        {
            _option.OnValueChanged += OnValueChanged;
        }

        private void OnDisable() => _option.OnValueChanged -= OnValueChanged;

        private void OnValueChanged()
        {

        }
    }
}
