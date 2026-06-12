using KadenZombie8.BIMOS.Rig.Movement;
using KadenZombie8.BIMOS.UI.Options;
using UnityEngine;
using UnityEngine.InputSystem;

namespace KadenZombie8.BIMOS.UI
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
        private GameObject _optionsMenu;

        [SerializeField]
        private GameObject _discardPopup;

        [SerializeField]
        private BackButton _back;

        [SerializeField]
        ScreenModeCamera _screenModeCamera;

        private void Awake() => _menuButtonReference.action.Enable();

        private void OnEnable() => _menuButtonReference.action.performed += ToggleMenuButton;

        private void OnDisable() => _menuButtonReference.action.performed -= ToggleMenuButton;

        public void ToggleMenuButton(InputAction.CallbackContext _) => ToggleMenu();

        public void ToggleMenu()
        {
            if (_optionsMenu.activeSelf)
            {
                if (_discardPopup.activeSelf)
                    _discardPopup.SetActive(false);
                else
                    _back.Pressed();
                return;
            }

            var showMenu = !_menuCanvas.activeSelf;
            _menuCanvas.SetActive(showMenu);
            _screenModeCamera.IsActive = !showMenu;
        }
    }
}
