using System;
using UnityEngine;

namespace KadenZombie8.BIMOS.UI.Options
{
    public abstract class Option<T> : MonoBehaviour, IRevertible
    {
        public event Action OnValueChanged;

        [SerializeField]
        protected string Key;

        [SerializeField]
        protected T DefaultValue;

        public bool IsDefaultValue => _currentValue.Equals(DefaultValue);

        private T _currentValue;
        private T _savedValue;

        protected virtual void Awake()
        {
            _savedValue = Load();
            _currentValue = _savedValue;
            ApplyValue(_currentValue);
        }

        protected virtual void Changed(T value)
        {
            _currentValue = value;
            OnValueChanged?.Invoke();
        }

        public void Apply() => Save(_currentValue);

        public void Discard()
        {
            _currentValue = _savedValue;
            ApplyValue(_currentValue);
        }

        public void Revert()
        {
            _currentValue = DefaultValue;
            ApplyValue(_currentValue);
        }

        protected abstract void ApplyValue(T value);
        protected abstract void Save(T value);
        protected abstract T Load();
    }
}
