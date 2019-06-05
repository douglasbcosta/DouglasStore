using DouglasStore.Domain.StoreContext.Entities;

namespace DouglasStore.Domain.StoreContext.Repositories{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer Customer);
    }
}