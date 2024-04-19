using System;

namespace Game.Differences
{
    public interface IDifference
    {
        public event Action<IDifference> Activated;
    }
}