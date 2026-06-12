using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using static KadenZombie8.BIMOS.Rig.Movement.VirtualCrouching;

namespace KadenZombie8.BIMOS.Rig.Movement
{
    /// <summary>
    /// Handles character's virtual movement with smooth locomotion
    /// </summary>
    public class SmoothLocomotion : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The walk speed of the character")]
        private float _defaultWalkSpeed = 1.5f;

        public enum RunModeType
        {
            Toggle,
            Hold
        }
        private RunModeType _runMode;

        [SerializeField]
        private InputActionReference _moveAction;

        [SerializeField]
        private InputActionReference _runAction;

        [SerializeField]
        private ControllerRig _controllerRig;

        public LocomotionSphere LocomotionSphere { get; private set; }

        private Vector2 _moveDirection;

        private Crouching _crouching;

        public float WalkSpeed { get; set; }

        public bool IsRunning { get; private set; }
        private bool _isRunPressed;

        /// <summary>
        /// The product of this and the walk speed is the run speed
        /// </summary>
        public float RunSpeedMultiplier = 2f;

        /// <summary>
        /// The product of this and the walk speed is the crouch speed
        /// </summary>
        public float CrouchSpeedMultiplier = 0.5f;

        private void Awake()
        {
            LocomotionSphere = GetComponentInChildren<LocomotionSphere>();
            _crouching = GetComponent<Crouching>();

            _moveAction.action.Enable();
            _runAction.action.Enable();

            ResetWalkSpeed();
        }

        private void OnEnable()
        {
            _moveAction.action.performed += OnMove;
            _moveAction.action.canceled += OnMove;

            _runAction.action.performed += OnRunPressed;
            _runAction.action.canceled += OnRunPressed;
        }

        private void OnDisable()
        {
            _moveAction.action.performed -= OnMove;
            _moveAction.action.canceled -= OnMove;

            _runAction.action.performed -= OnRunPressed;
            _runAction.action.canceled -= OnRunPressed;
        }

        private void OnMove(InputAction.CallbackContext context) => _moveDirection = context.ReadValue<Vector2>();
        private void OnRunPressed(InputAction.CallbackContext context)
        {
            var device = context.action.activeControl.device;
            var isKeyboard = device is Keyboard;

            _runMode = isKeyboard ? RunModeType.Hold : RunModeType.Toggle;

            if (_runMode == RunModeType.Toggle)
            {
                if (context.performed)
                    IsRunning = !IsRunning;
            }
            else
            {
                _isRunPressed = context.performed;
            }
        }

        private void FixedUpdate() => Move();

        private void Move()
        {
            var cameraHeight = _controllerRig.Transforms.Camera.position.y - LocomotionSphere.transform.position.y;
            var crouchingHeight = (_crouching.CrouchingLegHeight + _crouching.StandingLegHeight) / 2f;
            var isCrouching = cameraHeight < crouchingHeight;

            if (_runMode == RunModeType.Hold) IsRunning = _isRunPressed;

            if (_runMode == RunModeType.Toggle && _moveDirection.magnitude < 0.1f || isCrouching)
                IsRunning = false;

            var currentSpeed = WalkSpeed;
            if (IsRunning)
                currentSpeed *= RunSpeedMultiplier;
            else if (isCrouching)
                currentSpeed *= CrouchSpeedMultiplier;

            var targetLinearVelocity = _controllerRig.HeadForwardRotation * new Vector3(_moveDirection.x, 0, _moveDirection.y) * currentSpeed;
            LocomotionSphere.RollFromLinearVelocity(targetLinearVelocity);
        }

        /// <summary>
        /// Resets walk speed to avatar's walk speed
        /// </summary>
        public void ResetWalkSpeed() => WalkSpeed = _defaultWalkSpeed;
    }
}
