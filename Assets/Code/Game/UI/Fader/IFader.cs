using System;
using UnityEngine.UI;

namespace Game.UI.Fader
{
    internal interface IFader
    {
        public void Fade(Image image, float endValue, float duration, Action action = null);
    }
}