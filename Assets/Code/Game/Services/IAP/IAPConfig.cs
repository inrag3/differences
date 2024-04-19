using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

namespace Code.Game.Services.IAP
{
    [CreateAssetMenu(menuName = "Create IAPConfig", fileName = "IAPConfig", order = 0)]
    public class IAPConfig : ScriptableObject
    {
        [field: SerializeField] public List<Product> Products { get; private set; } = new();
    }

    [System.Serializable]
    public class Product
    {
        [SerializeField] private string _id;
        [SerializeField] private ProductType _type;
        public string Id => _id;
        public ProductType Type => _type;
    }
}