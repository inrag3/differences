using System;

namespace Code.Game.Differences
{
    public interface IPiece
    {
        public event Action Clicked;
        public void Activate();
    }
}