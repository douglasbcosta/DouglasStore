using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.Queries;

namespace DouglasStore.Domain.StoreContext.Repositories{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer Customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);   
    }
}