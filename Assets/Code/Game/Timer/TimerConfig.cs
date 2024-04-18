using UnityEngine;

namespace Code.Game.Timer
{
    [CreateAssetMenu(menuName = "Create TimerConfig", fileName = "TimerConfig")]
    public class TimerConfig : ScriptableObject
    {
        [field: SerializeField, Range(0, 360)] public int Time { get; private set; }
    }
}