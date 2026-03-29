using KadenZombie8.BIMOS.Settings;
using UnityEngine.UI;

namespace KadenZombie8.BIMOS.UI.Options
{
    public class ToggleOption : Option<bool>
    {
        private Toggle _toggle;

        protected override void Awake()
        {
            base.Awake();
            _toggle = GetComponentInChildren<Toggle>();
        }

        private void OnEnable() => _toggle.onValueChanged.AddListener(Changed);

        private void OnDisable() => _toggle.onValueChanged.RemoveListener(Changed);

        protected override void ApplyValue(bool value) => _toggle.isOn = value;

        protected override void Save(bool value) => BIMOSPrefs.SetBool(Key, value);

        protected override bool Load() => BIMOSPrefs.GetBool(Key, DefaultValue);
    }
}
