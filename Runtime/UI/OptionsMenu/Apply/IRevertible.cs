using System;

namespace KadenZombie8.BIMOS.UI.Options
{
    public interface IRevertible
    {
        bool IsDefaultValue { get; }
        event Action OnValueChanged;
        void Revert();
    }
}
