namespace DouglasStore.Domain.StoreContext.Entities
{
    public class Product 
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Price { get; private set; }
        public int QuantityOnHand { get; private set; }
    }
}