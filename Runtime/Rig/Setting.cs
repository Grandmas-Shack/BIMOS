using System;

namespace KadenZombie8.BIMOS.Settings
{
    public class Setting<T>
    {
        public event Action OnValueChanged;

        private string _key;

        private T _defaultValue;
        private T _savedValue;

        public T CurrentValue { get; private set; }
        public bool IsDefaultValue => CurrentValue.Equals(_defaultValue);
        public bool IsSavedValue => CurrentValue.Equals(_savedValue);

        public Setting(string key, T defaultValue)
        {
            _key = key;
            _defaultValue = defaultValue;
        }
    }
}
