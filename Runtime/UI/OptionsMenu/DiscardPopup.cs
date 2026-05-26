using UnityEngine;
using UnityEngine.Events;

namespace KadenZombie8.BIMOS.UI.Options
{
    /// <summary>
    /// Summons a pop-up that prompts the user to either discard their changes or cancel.
    /// </summary>
    public class DiscardPopup : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onHasUnsavedChanges;

        [SerializeField]
        private UnityEvent _onNoUnsavedChanges;

        private ApplyOptions _applyOptions;

        private void Awake() => _applyOptions = GetComponent<ApplyOptions>();

        public void BackPressed()
        {
            if (_applyOptions.HasUnsavedChanges)
                _onHasUnsavedChanges?.Invoke();
            else
                _onNoUnsavedChanges?.Invoke();
        }
    }
}
