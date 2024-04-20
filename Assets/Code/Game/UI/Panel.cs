using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class Panel : MonoBehaviour, ITransformable
    {
        [field: SerializeField] public Button Button { get; private set; }
        public Transform Transform { get; private set; }

        private void Awake()
        {
            Transform = GetComponent<RectTransform>();
        }
}
    }
