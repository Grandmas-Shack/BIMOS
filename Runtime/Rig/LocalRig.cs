using UnityEngine;

namespace KadenZombie8.BIMOS.Rig
{
    /// <summary>
    /// Tries to set the attached rig component to the local player rig.
    /// </summary>
    [DefaultExecutionOrder(-1)]
    [RequireComponent(typeof(BIMOSRig))]
    public class LocalRig : MonoBehaviour
    {
        private void Awake()
        {
            var rig = GetComponent<BIMOSRig>();
            BIMOSUtils.TrySetLocalRig(rig);
        }
    }
}
