using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Differences
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Piece : MonoBehaviour, IPiece, IPointerClickHandler
    {
        private SpriteRenderer _sprite;
        public event Action Clicked;
        private bool IsActive => _sprite.enabled;
        private void Awake()
        {
            _sprite = GetComponent<SpriteRenderer>();
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }

        public void Hide()
        {
            if (IsActive)
            {
                Animate();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void Animate()
        {
            _sprite.DOFade(0f, 0.15f).OnComplete(() => gameObject.SetActive(false));
        }
    }
}