using UnityEngine;

namespace KadenZombie8.BIMOS.UI.Options
{
    public class RevertToDefaultButton : MonoBehaviour
    {
        [SerializeField]
        private GameObject _button;

        private IRevertible _option;

        private void Awake() => _option = GetComponentInChildren<IRevertible>();

        private void Start() => UpdateButtonState();

        private void OnEnable() => _option.OnValueChanged += UpdateButtonState;

        private void OnDisable() => _option.OnValueChanged -= UpdateButtonState;

        private void UpdateButtonState() => _button.SetActive(!_option.IsDefaultValue);
    }
}
