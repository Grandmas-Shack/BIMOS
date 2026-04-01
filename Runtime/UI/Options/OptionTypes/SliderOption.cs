using KadenZombie8.BIMOS.Settings;
using UnityEngine.UI;

namespace KadenZombie8.BIMOS.UI.Options
{
    public class SliderOption : Option<float>
    {
        private Slider _slider;

        protected override void Awake()
        {
            _slider = GetComponentInChildren<Slider>();
            base.Awake();
        }

        private void OnEnable() => _slider.onValueChanged.AddListener(Changed);

        private void OnDisable() => _slider.onValueChanged.RemoveListener(Changed);

        protected override void ApplyValue(float value) => _slider.value = value;

        protected override void Save(float value) => BIMOSPrefs.SetFloat(Key, value);

        protected override float Load() => BIMOSPrefs.GetFloat(Key, DefaultValue);
    }
}
