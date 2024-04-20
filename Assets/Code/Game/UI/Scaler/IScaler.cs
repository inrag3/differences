namespace Game.UI.Scaler
{
    internal interface IScaler
    {
        public void Scale(ITransformable transform, float endValue, float duration);
    }
}