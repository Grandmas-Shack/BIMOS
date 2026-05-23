using UnityEngine;

namespace KadenZombie8.BIMOS.Rig.Movement
{
    /// <summary>
    /// Handles the movement from the player moving their headset
    /// in the real world.
    /// </summary>
    [RequireComponent(typeof(PhysicsRig))]
    public class RoomscaleMovement : MonoBehaviour
    {
        private PhysicsRig _physicsRig;
        private ControllerRig _controllerRig;

        private void Start()
        {
            _physicsRig = GetComponent<PhysicsRig>();
            var rig = _physicsRig.Rig;
            _controllerRig = rig.ControllerRig;
        }

        private void FixedUpdate()
        {
            // Position
            var deltaCameraPosition = _controllerRig.Transforms.HeadCameraOffset.position - _controllerRig.transform.position;

            var deltaCameraPositionFlattened = deltaCameraPosition;
            deltaCameraPositionFlattened.y = 0f;

            _controllerRig.Transforms.RoomscaleOffset.position -= deltaCameraPosition;

            _physicsRig.Rigidbodies.LocomotionSphere.position += deltaCameraPositionFlattened;
            _physicsRig.Rigidbodies.Knee.position += deltaCameraPositionFlattened;
            _physicsRig.Rigidbodies.Pelvis.position += deltaCameraPosition;
            _physicsRig.Rigidbodies.Head.position += deltaCameraPosition;

            _physicsRig.Crouching.TargetLegHeight += deltaCameraPosition.y;

            // Rotation
            var headForwardRotation = _controllerRig.HeadForwardRotation;
            _physicsRig.Rigidbodies.Pelvis.rotation = headForwardRotation;
        }
    }
}