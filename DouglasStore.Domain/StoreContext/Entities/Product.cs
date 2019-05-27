using FluentValidator;

namespace DouglasStore.Domain.StoreContext.Entities
{
    public class Product : Notifiable
    {
        public Product(string title, string description, string images, decimal price, decimal quantityOnHand)
        {
            Title = title;
            Description = description;
            Images = images;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Images { get; set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }
        

        public override string ToString(){
            return Title;
        }
    }
}