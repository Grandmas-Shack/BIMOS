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
        private GameObject _menuCanvas;

        [SerializeField]
        ScreenModeCamera _screenModeCamera;

        private void Awake() => _menuButtonReference.action.Enable();

        private void OnEnable() => _menuButtonReference.action.performed += ToggleMenu;

        private void OnDisable() => _menuButtonReference.action.performed -= ToggleMenu;

        public void ToggleMenu(InputAction.CallbackContext _)
        {
            var showMenu = !_menuCanvas.activeSelf;
            _menuCanvas.SetActive(showMenu);
            _screenModeCamera.IsActive = !showMenu;
        }
    }
}
