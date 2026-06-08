using KadenZombie8.BIMOS.Settings;

namespace KadenZombie8.BIMOS.Rig
{
    public static class BIMOSUtils
    {
        /// <summary>
        /// The local player's rig.
        /// </summary>
        public static BIMOSRig LocalRig { get; private set; }

        /// <summary>
        /// The local player's rig settings.
        /// </summary>
        public static BIMOSSettings Settings { get; private set; }

        /// <summary>
        /// Tries to set the rig as the local player's rig.
        /// </summary>
        /// <param name="rig">The rig to try and set as the local player rig.</param>
        public static bool TrySetLocalRig(BIMOSRig rig)
        {
            if (LocalRig != null && LocalRig != rig) return false;
            Settings = new();
            LocalRig = rig;
            return true;
        }
    }
}
