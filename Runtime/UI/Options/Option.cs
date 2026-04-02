using System;
using UnityEngine;

namespace KadenZombie8.BIMOS.UI.Options
{
    public abstract class Option<T> : MonoBehaviour, IAppliable, IRevertible
    {
        public event Action OnValueChanged;

        [SerializeField]
        protected string Key;

        [SerializeField]
        protected T DefaultValue;

        public bool IsDefaultValue => _currentValue.Equals(DefaultValue);

        private T _currentValue;
        private T _savedValue;
        
        private ApplyOptions _applyOptions;

        public bool IsSavedValue => _currentValue.Equals(_savedValue);

        protected virtual void Awake()
        {
            _savedValue = Load();
            _currentValue = _savedValue;
            _applyOptions = GetComponentInParent<ApplyOptions>();
            ApplyValue(_currentValue);
        }

        protected virtual void Changed(T value)
        {
            _currentValue = value;
            OnValueChanged?.Invoke();

            if (IsSavedValue)
                _applyOptions.UnregisterOption(this);
            else
                _applyOptions.RegisterOption(this);
        }

        public void Apply()
        {
            Save(_currentValue);
            _savedValue = _currentValue;
            Changed(_currentValue);
        }

        public void Discard()
        {
            _currentValue = _savedValue;
            ApplyValue(_currentValue);
            Changed(_currentValue);
        }

        public void Revert()
        {
            _currentValue = DefaultValue;
            ApplyValue(_currentValue);
            Changed(_currentValue);
        }

        protected abstract void ApplyValue(T value);
        protected abstract void Save(T value);
        protected abstract T Load();
    }
}
