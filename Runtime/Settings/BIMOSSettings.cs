using System;
using System.Collections.Generic;

namespace KadenZombie8.BIMOS.Settings
{
    public class BIMOSSettings
    {
        private static readonly Dictionary<string, ISetting> _settings = new();

        #region Settings
        /// <summary>
        /// The device currently being used to control the player's rig.
        /// <para>0 = VR</para>
        /// <para>1 = Flatscreen</para>
        /// </summary>
        // Mouse
        public Setting<float> MouseSensitivity = new("Mouse_Sensitivity", 5f);
        public Setting<int> MouseGripType = new("Mouse_GripType", 0);

        // Gamepad
        public Setting<float> GamepadSensitivity = new("Gamepad_Sensitivity", 5f);

        // Video
        public Setting<float> FlatscreenFieldOfView = new("Video_FieldOfView", 60f);

        // Spectator
        public Setting<int> SpectatorOutput = new("Spectator_Output", 0);
        public Setting<int> SpectatorEye = new("Spectator_Eye", 0);
        public Setting<int> SpectatorCameraVisual = new("Spectator_CameraVisual", 0);
        public Setting<float> SpectatorFieldOfView = new("Spectator_FieldOfView", 90f);
        public Setting<float> SpectatorSmoothing = new("Spectator_Smoothing", 90f);

        // Debug
        public Setting<int> ControlType = new("Debug_ControlType", 0);
        #endregion

        public BIMOSSettings()
        {
            foreach (var field in GetType().GetFields())
            {
                if (field.GetValue(this) is ISetting setting)
                _settings.Add(setting.Key, setting);
            }
        }

        public static bool TryGetSetting(string key, out ISetting setting) => _settings.TryGetValue(key, out setting);
    }
}
