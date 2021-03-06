using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.Queries;
using DouglasStore.Domain.StoreContext.Repositories;
using DouglasStore.Infra.DataContexts;

namespace DouglasStore.Infra.Repositories{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DouglasDataContext _context;
        public CustomerRepository(DouglasDataContext context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            return _context.
                Connection.
                Query<bool>(
                    "spCheckDocument",new{ Document = document },
                    commandType : CommandType.StoredProcedure
            ).FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context.
                Connection.
                Query<bool>(
                    "spCheckEmail",new{ Email = email },
                    commandType : CommandType.StoredProcedure
            ).FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return
                _context.Connection.Query<ListCustomerQueryResult>(
                    "SELECT [Id], CONCAT([FirstName],' ',[LastName]) AS [Name], [Document], [Email], [Phone] FROM Customer",
                    new {}
                );
        }

        public GetCustomerQueryResult GetById(Guid Id)
        {
            return
                _context.Connection.Query<GetCustomerQueryResult>(
                    "SELECT [Id], [FirstName], [LastName], [Document], [Email], [Phone] FROM Customer Where [Id] = @Id",
                    new {Id = Id}
                ).FirstOrDefault();
        }

        public GetCustomerQueryResult GetByDocument(string document)
        {
            return
                _context.Connection.Query<GetCustomerQueryResult>(
                    "SELECT [Id], CONCAT([FirstName],' '[LastName]) AS [Name], [Document], [Email] FROM Customer Where [Document] = @Document",
                    new {Document = document}
                ).FirstOrDefault();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context.
                Connection.
                Query<CustomerOrdersCountResult>(
                    "spGetCustomerOrdersCount",new{ Document = document },
                    commandType : CommandType.StoredProcedure
            ).FirstOrDefault();
        
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid Id)
        {
            return
                _context.Connection.Query<ListCustomerOrdersQueryResult>(
                    "SELECT [Id], COUNT(Id) AS Total, CONCAT([FirstName],' ',[LastName]) AS [Name], [Document], [Email]"
                     + " FROM Customer Where [Id] = @Id",
                    new { Id = Id}
                );
        }

        public void Save(Customer Customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new {
                    Customer.Id,
                    Customer.Name.FirstName,
                    Customer.Name.LastName,
                    Document = Customer.Document.Number,
                    Email = Customer.Email.Address,
                    Customer.Phone
                 },
                    commandType : CommandType.StoredProcedure
            );

            CreateCustomerAddresses(Customer);

        }
        public void Update(Customer Customer)
        {
            _context.Connection.Execute("spUpdateCustomer",
                new
                {
                    Customer.Id,
                    Customer.Name.FirstName,
                    Customer.Name.LastName,
                    Email = Customer.Email.Address,
                    Customer.Phone
                },
                    commandType: CommandType.StoredProcedure
            );

            _context.Connection.Execute("spDeleteCustomerAddressess",
                new
                {
                    CustomerId = Customer.Id
                },
                commandType: CommandType.StoredProcedure
            );

            CreateCustomerAddresses(Customer);
        }

        public void CreateCustomerAddresses(Customer Customer)
        {
            foreach (var address in Customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                new
                {
                    Id = address.Id,
                    CustomerId = Customer.Id,
                    Number = address.Number,
                    Street = address.Street,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                },
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public bool CheckEmailUpdate(string email, Guid id)
        {
            return _context.
                Connection.
                Query<bool>(
                    "spCheckEmailUpdate", new { Email = email, Id = id },
                    commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }

        public void Delete(Guid id)
        {
            _context.Connection.Execute("spDeleteCustomer",
                new
                {
                    Id = id
                },
                commandType: CommandType.StoredProcedure
            );
        }

        public bool CheckId(Guid id)
        {
            return _context.
                Connection.
                Query<bool>(
                    "spCheckId", new { Id = id },
                    commandType: CommandType.StoredProcedure
            ).FirstOrDefault();
        }
    }
}