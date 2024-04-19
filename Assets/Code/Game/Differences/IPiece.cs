using System;

namespace Game.Differences
{
    public interface IPiece
    {
        public event Action Clicked;
        public void Hide();
    }
}