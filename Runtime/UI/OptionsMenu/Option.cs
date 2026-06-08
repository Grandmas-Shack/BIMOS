using System;
using KadenZombie8.BIMOS.Rig;
using KadenZombie8.BIMOS.Settings;
using UnityEngine;

namespace KadenZombie8.BIMOS.UI.Options
{
    public abstract class Option<T> : MonoBehaviour, IAppliable, IRevertible
    {
        private Setting<T> _setting;

        public event Action OnValueChanged;

        [SerializeField]
        protected string Key;
        
        private ApplyOptions _applyOptions;

        public bool IsSavedValue => _setting.IsSavedValue;

        public bool IsDefaultValue => _setting.IsDefaultValue;

        protected virtual void Awake()
        {
            BIMOSUtils.Settings.TryGetSetting(Key, out var setting);
            _setting = (Setting<T>)setting;
            _applyOptions = GetComponentInParent<ApplyOptions>();
            UpdateOptionValue();
        }

        protected virtual void Changed(T value)
        {
            _setting.Value = value;
            OnValueChanged?.Invoke();

            if (_setting.IsSavedValue)
                _applyOptions.UnregisterOption(this);
            else
                _applyOptions.RegisterOption(this);
        }

        public void Apply()
        {
            _setting.Save();
            Changed(_setting.Value);
        }

        public void Discard()
        {
            _setting.Discard();
            UpdateOptionValue();
        }

        public void Revert()
        {
            _setting.Revert();
            UpdateOptionValue();
        }

        private void UpdateOptionValue()
        {
            SetOptionValue(_setting.Value);
            Changed(_setting.Value);
        }

        protected abstract void SetOptionValue(T value);
    }
}
