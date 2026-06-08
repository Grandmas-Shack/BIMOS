using KadenZombie8.BIMOS.Settings;
using UnityEngine;

namespace KadenZombie8.BIMOS.Rig
{
    public class Video_FieldOfView : MonoBehaviour
    {
        [SerializeField]
        private Camera _camera;

        private Setting<float> _setting;

        private void Awake()
        {
            BIMOSSettings.TryGetSetting("Video_FieldOfView", out var setting);
            _setting = (Setting<float>)setting;
            SettingUpdated();
        }

        private void OnEnable() => _setting.OnValueChanged += SettingUpdated;

        private void OnDisable() => _setting.OnValueChanged -= SettingUpdated;

        private void SettingUpdated() => _camera.fieldOfView = _setting.Value;
    }
}
