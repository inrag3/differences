using System;

namespace Code.Game.Differences
{
    public interface IDifference
    {
        public event Action<IDifference> Activated;
    }
}