using UnityEngine;

namespace KadenZombie8.BIMOS.Rig
{
    [RequireComponent(typeof(BodyCollisionIgnorer), typeof(HoldDetector))]
    public class IgnoreBodyCollisionWhileHeld : MonoBehaviour
    {
        private BodyCollisionIgnorer _bodyCollisionIgnorer;
        private HoldDetector _holdDetector;

        private void Awake()
        {
            _bodyCollisionIgnorer = GetComponent<BodyCollisionIgnorer>();
            _holdDetector = GetComponent<HoldDetector>();
        }

        private void OnEnable()
        {
            _holdDetector.OnFirstGrab.AddListener(IgnoreBodyCollisionTrue);
            _holdDetector.OnLastRelease.AddListener(IgnoreBodyCollisionFalse);
        }

        private void OnDisable()
        {
            _holdDetector.OnFirstGrab.RemoveListener(IgnoreBodyCollisionTrue);
            _holdDetector.OnLastRelease.RemoveListener(IgnoreBodyCollisionFalse);
        }

        private void IgnoreBodyCollisionTrue(Hand hand) => IgnoreBodyCollision(hand, true);

        private void IgnoreBodyCollisionFalse(Hand hand) => IgnoreBodyCollision(hand, false);

        private void IgnoreBodyCollision(Hand hand, bool ignore)
        {
            _bodyCollisionIgnorer.SetIgnoreBodyCollision(hand.Rig, ignore);
        }
    }
}
