using System;
using KadenZombie8.BIMOS.Rig.Animation;
using KadenZombie8.BIMOS.Rig.Movement;
using UnityEngine;

namespace KadenZombie8.BIMOS.Rig
{
    [DefaultExecutionOrder(-1)]
    public class BIMOSRig : MonoBehaviour
    {
        public event Action<BIMOSRig> OnDisabled;

        public ControllerRig ControllerRig;
        public PhysicsRig PhysicsRig;
        public AnimationRig AnimationRig;

        private void OnDisable() => OnDisabled?.Invoke(this);
    }
}