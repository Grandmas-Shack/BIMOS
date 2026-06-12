using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace KadenZombie8.BIMOS.UI.Options
{
    /// <summary>
    /// Summons a pop-up that prompts the user to either discard their changes or cancel.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class BackButton : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onHasUnsavedChanges;

        [SerializeField]
        private UnityEvent _onNoUnsavedChanges;

        [SerializeField]
        private ApplyOptions _applyOptions;

        private Button _button;

        private void Awake() => _button = GetComponent<Button>();

        private void OnEnable() => _button.onClick.AddListener(Pressed);

        private void OnDisable() => _button.onClick.RemoveListener(Pressed);

        public void Pressed()
        {
            if (_applyOptions.HasUnsavedChanges)
                _onHasUnsavedChanges?.Invoke();
            else
                _onNoUnsavedChanges?.Invoke();
        }
    }
}
