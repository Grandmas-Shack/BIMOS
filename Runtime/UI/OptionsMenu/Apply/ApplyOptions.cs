using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KadenZombie8.BIMOS.UI.Options
{
    public class ApplyOptions : MonoBehaviour
    {
        private readonly HashSet<IAppliable> _appliables = new();

        public event Action OnOptionsChanged;

        public bool HasUnsavedChanges => _appliables.Count > 0;

        public void RegisterOption(IAppliable appliable)
        {
            _appliables.Add(appliable);
            OnOptionsChanged?.Invoke();
        }

        public void UnregisterOption(IAppliable appliable)
        {
            _appliables.Remove(appliable);
            OnOptionsChanged?.Invoke();
        }

        public void Apply()
        {
            foreach (var appliable in _appliables.ToArray())
                appliable.Apply();

            OnOptionsChanged?.Invoke();
        }

        public void Discard()
        {
            foreach (var appliable in _appliables.ToArray())
                appliable.Discard();

            OnOptionsChanged?.Invoke();
        }
    }
}
