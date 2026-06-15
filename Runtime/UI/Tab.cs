using UnityEngine;
using UnityEngine.UI;

namespace KadenZombie8.BIMOS.UI
{
    [RequireComponent(typeof(Toggle))]
    public class Tab : MonoBehaviour
    {
        public GameObject Page;

        private Toggle _toggle;
        private TabMenu _tabMenu;

        private void Awake()
        {
            _toggle = GetComponent<Toggle>();
            var toggleGroup = _toggle.group;
            _tabMenu = toggleGroup.GetComponent<TabMenu>();
        }

        private void OnEnable() => _tabMenu.Register(this, _toggle);

        private void OnDisable() => _tabMenu.Unregister(_toggle);
    }
}
