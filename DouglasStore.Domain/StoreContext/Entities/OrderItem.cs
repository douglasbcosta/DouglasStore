using System.Collections.Generic;
using FluentValidator;

namespace DouglasStore.Domain.StoreContext.Entities
{
    public class OrderItem : Notifiable{
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;
            if(Product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Produto fora de estoque");
        }

        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price{ get; private set; }
    }
}