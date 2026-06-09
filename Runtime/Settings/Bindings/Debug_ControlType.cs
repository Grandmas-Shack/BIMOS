using System.Collections;
using UnityEngine.XR.Management;

namespace KadenZombie8.BIMOS.Settings.Bindings
{
    public class Debug_ControlType : SettingBinding<int>
    {
        private void Start()
        {
            if (Setting.Value == 0)
                StartCoroutine(StartXR());
        }

        protected override void SettingSaved(int value)
        {
            if (value == 0)
                StartCoroutine(StartXR());
            else
                StartCoroutine(StopXR());
        }

        private IEnumerator StartXR()
        {
            var manager = XRGeneralSettings.Instance.Manager;
            if (!manager) yield break;
            if (manager.activeLoader) yield break;
            if (manager.isInitializationComplete) yield break;
            manager.InitializeLoaderSync();
            while (!manager.isInitializationComplete) yield return null;
            manager.StartSubsystems();
        }

        private IEnumerator StopXR()
        {
            var manager = XRGeneralSettings.Instance.Manager;
            if (!manager) yield break;
            if (!manager.activeLoader) yield break;
            if (!manager.isInitializationComplete) yield break;
            manager.StopSubsystems();
            manager.DeinitializeLoader();
            yield return null;
        }
    }
}
