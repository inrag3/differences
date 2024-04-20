using System.Linq;
using Game.UI.Windows;

namespace Game.Services.UI
{
    public interface IUIService
    {
        public Window Get(WindowID id);
    }

    public enum WindowID
    {
        None,
        Loss,
        Win,
    }
}