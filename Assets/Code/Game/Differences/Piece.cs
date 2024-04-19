using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Game.Differences
{
    public class Piece : MonoBehaviour, IPiece, IPointerClickHandler
    {
        public event Action Clicked;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }

        public void Activate()
        {
            gameObject.SetActive(false);   
        }
    }
}