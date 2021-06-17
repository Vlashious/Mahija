using CommonEnums;
using Zenject;

namespace Windows
{
    public class WindowManager
    {
        private readonly DiContainer _container;

        [Inject]
        public WindowManager(DiContainer container)
        {
            _container = container;
        }

        public void OpenWindow(WindowType type)
        {
            var window = _container.ResolveId<BaseWindow>(type);
            window.gameObject.SetActive(true);
        }

        public void CloseWindow(WindowType type)
        {
            var window = _container.ResolveId<BaseWindow>(type);
            window.gameObject.SetActive(false);
        }
    }
}