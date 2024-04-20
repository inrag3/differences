using System.Collections.Generic;
using Game.UI.Windows;

namespace Game.Services.UI
{
    public class UIService : IUIService
    {
        private readonly IDictionary<WindowID, Window> _windows;

        public UIService(IDictionary<WindowID, Window> windows)
        {
            _windows = windows;
        }
        public Window Get(WindowID id) => _windows[id];
    }
}