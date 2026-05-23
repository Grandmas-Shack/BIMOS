using UnityEngine;

namespace KadenZombie8.BIMOS.Rig.Animation
{
    public class Hips : MonoBehaviour
    {
        [SerializeField]
        private AnimationRig _animationRig;

        [SerializeField]
        private Rigidbody _locomotionSphereRigidbody;

        [SerializeField]
        private Transform _headCameraOffset;

        [SerializeField]
        private AnimationCurve _hipsBackCurve = AnimationCurve.Linear(0f, 0f, 1f, 0.5f);

        private float _spineLength;

        private void Start()
        {
            _spineLength = Vector3.Distance(_animationRig.Transforms.Head.position, _animationRig.Transforms.Hips.position);
        }

        void Update()
        {
            var floor = _locomotionSphereRigidbody.position.y + 0.2f;
            var crouchingPercent = 1f - (_headCameraOffset.position.y - floor) / 1.1f;
            var back = _hipsBackCurve.Evaluate(crouchingPercent);
            var rotation = transform.rotation * Quaternion.Euler(back * 90f, 0f, 0f);
            transform.position = _headCameraOffset.position + rotation * (Vector3.down * _spineLength);
        }
    }
}