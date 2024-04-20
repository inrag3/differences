using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

namespace Game.Services.IAP
{
    public class IAPProvider : IDetailedStoreListener
    {
        private IStoreController _controller;
        private IExtensionProvider _extensions;

        public IAPProvider(IAPConfig config)
        {
            var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
            foreach (var product in config.Products)
            {
                builder.AddProduct(product.Id, product.Type);
            }
            
            UnityPurchasing.Initialize(this, builder);
        }
        
        public void StartPurchase(string productId) => 
            _controller.InitiatePurchase(productId);


        public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
        {
            _extensions = extensions;
            _controller = controller;
            Debug.Log("Initialize successfully!");
        }

        public void OnInitializeFailed(InitializationFailureReason error)
        {
            Debug.LogError($"Initialize failed: {error}");
        }

        public void OnInitializeFailed(InitializationFailureReason error, string message)
        {
            Debug.LogError($"Initialize failed: {error}");
        }

        public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
        {
            Debug.Log($"Process purchase: {purchaseEvent.purchasedProduct.definition.id}");
            return PurchaseProcessingResult.Complete;
        }

        public void OnPurchaseFailed(UnityEngine.Purchasing.Product product, PurchaseFailureDescription failureDescription) { }

        [Obsolete]
        public void OnPurchaseFailed(UnityEngine.Purchasing.Product product, PurchaseFailureReason failureReason) { }
    }
}