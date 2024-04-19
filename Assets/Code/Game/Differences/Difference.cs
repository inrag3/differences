using System;

namespace Game.Differences
{
    public class Difference : IDifference, IDisposable
    {
        private readonly IPiece _first;
        private readonly IPiece _second;

        public event Action<IDifference> Activated;

        public Difference(IPiece first, IPiece second)
        {
            _first = first;
            _second = second;
            _first.Clicked += OnClicked;
            _second.Clicked += OnClicked;
        }
        
        public void Dispose()
        {
            _first.Clicked -= OnClicked;
            _second.Clicked -= OnClicked;
        }

        private void OnClicked()
        {
            Activated?.Invoke(this);
            _first.Hide();
            _second.Hide();
        }
    }
}