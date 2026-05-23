using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KadenZombie8.BIMOS.UI.Options
{
    public class SliderInputFieldConnection : MonoBehaviour
    {
        private Slider _slider;
        private TMP_InputField _inputField;

        private void Awake()
        {
            _slider = GetComponentInChildren<Slider>();
            _inputField = GetComponentInChildren<TMP_InputField>();
            OnSliderValueChanged(_slider.value);
        }

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
            _inputField.onEndEdit.AddListener(OnInputFieldValueChanged);
        }

        private void OnDisable()
        {
            _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
            _inputField.onEndEdit.RemoveListener(OnInputFieldValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            value = Mathf.Round(value * 10f) / 10f;
            _inputField.text = value.ToString();
        }

        private void OnInputFieldValueChanged(string stringValue)
        {
            if (!float.TryParse(stringValue, out float value)) value = _slider.value;
            value = Mathf.Clamp(value, _slider.minValue, _slider.maxValue);
            _slider.value = value;
            _inputField.text = _slider.value.ToString();
        }
    }
}
