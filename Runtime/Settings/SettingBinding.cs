using KadenZombie8.BIMOS.Rig;
using UnityEngine;

namespace KadenZombie8.BIMOS.Settings.Bindings
{
    public abstract class SettingBinding<T> : MonoBehaviour
    {
        [SerializeField]
        private string _key;

        private Setting<T> _setting;

        private void Awake()
        {
            BIMOSUtils.Settings.TryGetSetting(_key, out var setting);
            _setting = (Setting<T>)setting;
            SettingUpdated(_setting.Value);
        }

        private void OnEnable() => _setting.OnValueChanged += SettingUpdated;

        private void OnDisable() => _setting.OnValueChanged -= SettingUpdated;

        protected abstract void SettingUpdated(T value);
    }
}
