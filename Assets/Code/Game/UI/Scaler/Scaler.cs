using DG.Tweening;

namespace Game.UI.Scaler
{
    public class Scaler : IScaler
    {
        public void Scale(ITransformable transformable, float endValue, float duration)
        {
            transformable.Transform.DOScale(endValue, duration);
        }
    }
}