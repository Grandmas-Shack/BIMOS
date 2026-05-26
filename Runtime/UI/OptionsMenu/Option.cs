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

        public bool IsDefaultValue => CurrentValue.Equals(DefaultValue);

        public T CurrentValue { get; private set; }
        private T _savedValue;
        
        private ApplyOptions _applyOptions;

        public bool IsSavedValue => CurrentValue.Equals(_savedValue);

        protected virtual void Awake()
        {
            _savedValue = Load();
            CurrentValue = _savedValue;
            _applyOptions = GetComponentInParent<ApplyOptions>();
            ApplyValue(CurrentValue);
        }

        protected virtual void Changed(T value)
        {
            CurrentValue = value;
            OnValueChanged?.Invoke();

            if (IsSavedValue)
                _applyOptions.UnregisterOption(this);
            else
                _applyOptions.RegisterOption(this);
        }

        public void Apply()
        {
            Save(CurrentValue);
            _savedValue = CurrentValue;
            Changed(CurrentValue);
        }

        public void Discard()
        {
            CurrentValue = _savedValue;
            ApplyValue(CurrentValue);
            Changed(CurrentValue);
        }

        public void Revert()
        {
            CurrentValue = DefaultValue;
            ApplyValue(CurrentValue);
            Changed(CurrentValue);
        }

        protected abstract void ApplyValue(T value);
        protected abstract void Save(T value);
        protected abstract T Load();
    }
}
