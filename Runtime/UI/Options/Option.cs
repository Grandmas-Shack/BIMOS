using UnityEngine;

namespace KadenZombie8.BIMOS.UI.Options
{
    public abstract class Option<T> : MonoBehaviour
    {
        [SerializeField]
        protected string Key;

        [SerializeField]
        protected T DefaultValue;

        private T _currentValue;
        private T _savedValue;

        protected virtual void Awake()
        {
            _savedValue = Load();
            _currentValue = _savedValue;
            ApplyValue(_currentValue);
        }

        protected virtual void Changed(T value) => _currentValue = value;

        public void Apply()
        {
            _savedValue = _currentValue;
            Save(_savedValue);
        }

        public void Revert()
        {
            _currentValue = _savedValue;
            ApplyValue(_currentValue);
        }

        protected abstract void ApplyValue(T value);
        protected abstract void Save(T value);
        protected abstract T Load();
    }
}
