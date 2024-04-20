using System;
using DG.Tweening;
using UnityEngine.UI;

namespace Game.UI.Fader
{
    public class Fader : IFader
    {
        public void Fade(Image image, float endValue, float duration, Action action = null)
        {
            image
                .DOFade(endValue, duration)
                .OnComplete(() => action?.Invoke());
        }
    }
}