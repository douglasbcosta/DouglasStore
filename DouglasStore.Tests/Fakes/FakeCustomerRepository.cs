using System;
using System.Collections.Generic;
using DouglasStore.Domain.StoreContext.CustomerCommands.Inputs;
using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.Handlers;
using DouglasStore.Domain.StoreContext.Queries;
using DouglasStore.Domain.StoreContext.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouglasStore.Tests{

    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            throw new System.NotImplementedException();
        }

        public GetCustomerQueryResult GetByDocument(string document)
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer Customer)
        {
            
        }
    }
}