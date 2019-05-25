namespace DouglasStore.Domain.StoreContext.Entities
{
    public class Customer{
        public Customer(string name, string lastName, string document, string email, string phone, string address)
        {
            Name = name;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
    }
}