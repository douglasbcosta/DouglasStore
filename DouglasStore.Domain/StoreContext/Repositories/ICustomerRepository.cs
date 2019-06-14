using System;
using System.Collections.Generic;
using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.Queries;

namespace DouglasStore.Domain.StoreContext.Repositories{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        bool CheckEmailUpdate(string email);
        bool CheckId(Guid id);
        void Save(Customer Customer);
        void Update(Customer Customer);
        void Delete(Guid id);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);   
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult GetById(Guid Id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid Id);
        GetCustomerQueryResult GetByDocument(string document);
        void CreateCustomerAddresses(Customer Customer);
    }
}