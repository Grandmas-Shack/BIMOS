using System;

namespace KadenZombie8.BIMOS.Settings
{
    public class Setting<T> : ISetting
    {
        public event Action<T> OnValueChanged;

        public string Key { get; private set; }

        private readonly T _defaultValue;
        private T _savedValue;

        public T Value
        {
            get => _value;
            set
            {
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        private T _value;

        public bool IsDefaultValue => Value.Equals(_defaultValue);
        public bool IsSavedValue => Value.Equals(_savedValue);

        public Setting(string key, T defaultValue)
        {
            Key = key;
            _defaultValue = defaultValue;
            _savedValue = Load();
            Value = _savedValue;
        }

        public void Discard() => Value = _savedValue;

        public void Revert() => Value = _defaultValue;

        public void Save()
        {
            if (typeof(T) == typeof(bool))
                BIMOSPrefs.SetBool(Key, Convert.ToBoolean(Value));
            else if (typeof(T) == typeof(int))
                BIMOSPrefs.SetInt(Key, Convert.ToInt32(Value));
            else if (typeof(T) == typeof(float))
                BIMOSPrefs.SetFloat(Key, Convert.ToSingle(Value));
            else if (typeof(T) == typeof(string))
                BIMOSPrefs.SetString(Key, Convert.ToString(Value));

            _savedValue = Value;
        }

        public T Load()
        {
            object value;

            if (typeof(T) == typeof(bool))
                value = BIMOSPrefs.GetBool(Key, Convert.ToBoolean(_defaultValue));
            else if (typeof(T) == typeof(int))
                value = BIMOSPrefs.GetInt(Key, Convert.ToInt32(_defaultValue));
            else if (typeof(T) == typeof(float))
                value = BIMOSPrefs.GetFloat(Key, Convert.ToSingle(_defaultValue));
            else if (typeof(T) == typeof(string))
                value = BIMOSPrefs.GetString(Key, Convert.ToString(_defaultValue));
            else
                return _defaultValue;

            return (T)value;
        }
    }
}
