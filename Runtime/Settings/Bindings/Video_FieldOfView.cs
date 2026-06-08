using KadenZombie8.BIMOS.Settings;
using UnityEngine;

namespace KadenZombie8.BIMOS.Rig
{
    public class Video_FieldOfView : SettingBinding<float>
    {
        [SerializeField]
        private Camera _camera;

        protected override void SettingUpdated(float value) => _camera.fieldOfView = value;
    }
}
