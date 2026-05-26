using KadenZombie8.BIMOS.Rig.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KadenZombie8.BIMOS
{
    /// <summary>
    /// Toggles the flatscreen menu when the menu button is pressed.
    /// </summary>
    public class MenuToggleFlatscreen : MonoBehaviour
    {
        [SerializeField]
        private InputActionReference _menuButtonReference;

        [SerializeField]
        private InputActionReference _leftGripReference;

        [SerializeField]
        private InputActionReference _rightGripReference;

        [SerializeField]
        private GameObject _menuCanvas;

        [SerializeField]
        ScreenModeCamera _screenModeCamera;

        private readonly int mouseIndex = 1;

        private void Awake() => _menuButtonReference.action.Enable();

        private void OnEnable() => _menuButtonReference.action.performed += ToggleMenuButton;

        private void OnDisable() => _menuButtonReference.action.performed -= ToggleMenuButton;

        public void ToggleMenuButton(InputAction.CallbackContext _) => ToggleMenu();

        public void ToggleMenu()
        {
            var showMenu = !_menuCanvas.activeSelf;
            _menuCanvas.SetActive(showMenu);
            _screenModeCamera.IsActive = !showMenu;

            if (showMenu)
            {
                _leftGripReference.action.ApplyBindingOverride(mouseIndex, new InputBinding() { overridePath = "" });
                _rightGripReference.action.ApplyBindingOverride(mouseIndex, new InputBinding() { overridePath = "" });
            }
            else
            {
                _leftGripReference.asset.RemoveAllBindingOverrides();
                _rightGripReference.asset.RemoveAllBindingOverrides();
            }
        }
    }
}
