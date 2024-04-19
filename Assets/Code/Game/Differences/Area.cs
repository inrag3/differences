using System;
using System.Collections.Generic;
using System.Linq;
using Code.Game.Factories;
using Code.Game.Factories.Difference;
using UnityEngine;
using Zenject;

namespace Code.Game.Differences
{
    public class Area : MonoBehaviour, IArea
    {
        [SerializeField] private List<Piece> _pieces;

        private readonly IList<IDifference> _differences = new List<IDifference>();
        private DifferenceFactory _factory;
        public event Action Cleared;
        private bool IsCleared => _differences.Count == 0;

        [Inject]
        private void Construct(DifferenceFactory factory)
        {
            _factory = factory;
        }

        private void OnValidate()
        {
            _pieces = GetComponentsInChildren<Piece>().ToList();
        }

        private void Awake()
        {
            var groups = _pieces.GroupBy(x => x.name);
            foreach (var group in groups)
            {
                var difference = _factory.Create(group.First(), group.Last());
                difference.Activated += OnDifferenceActivated;
                _differences.Add(difference);
            }
        }

        private void OnDifferenceActivated(IDifference difference)
        {
            difference.Activated -= OnDifferenceActivated;
            _differences.Remove(difference);
            if (IsCleared)
            {
                Cleared?.Invoke();
            }
        }
    }
}