using System;

namespace KadenZombie8.BIMOS.UI.Options
{
    public interface IAppliable
    {
        bool IsSavedValue { get; }
        event Action OnValueChanged;
    }
}
