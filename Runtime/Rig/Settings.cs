namespace KadenZombie8.BIMOS.Settings
{
    public class Settings
    {
        /// <summary>
        /// The device currently being used to control the player's rig.
        /// <para>0 = VR</para>
        /// <para>1 = Flatscreen</para>
        /// </summary>
        public Setting<int> ControlType;

        public void Initialize()
        {
            // Initialise all the settings
        }
    }
}
