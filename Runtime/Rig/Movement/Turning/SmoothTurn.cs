using UnityEngine;

namespace KadenZombie8.BIMOS.Rig.Movement
{
    /// <summary>
    /// Turn type with continuous rotation
    /// </summary>
    public class SmoothTurn : MonoBehaviour
    {
        private VirtualTurning _virtualTurning;
        private PhysicsRig _physicsRig;
        private float _turnVector;

        private void OnEnable() => _virtualTurning.TurnEvent += OnTurn;

        private void OnDisable() => _virtualTurning.TurnEvent -= OnTurn;

        private void Awake()
        {
            _physicsRig = GetComponent<PhysicsRig>();
            _virtualTurning = GetComponent<VirtualTurning>();
        }

        private void OnTurn(float direction) => _turnVector = direction;

        private void Update()
        {
            var turnDirection = _turnVector / Mathf.Abs(_turnVector);
            var degreesToTurn = _virtualTurning.TurnSpeed * Time.deltaTime;
            _physicsRig.Rigidbodies.Pelvis.transform.Rotate(0f, degreesToTurn * turnDirection, 0f);
        }
    }
}