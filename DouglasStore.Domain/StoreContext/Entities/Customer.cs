using System;
using System.Collections.Generic;
using System.Linq;
using DouglasStore.Domain.StoreContext.Queries;
using DouglasStore.Domain.StoreContext.ValueObjects;
using DouglasStore.Shared.Entities;
using FluentValidator;

namespace DouglasStore.Domain.StoreContext.Entities
{
    public class Customer : Entity{
        private readonly IList<Address> _addresses;
        public Customer(Name name, Document document, Email email, string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }
        public Customer(GetCustomerQueryResult customer, Guid id) : base(id)
        {
            Name = new Name(customer.FirstName, customer.LastName);
            Document = new Document(customer.Document);
            Email = new Email(customer.Email);
            Phone = customer.Phone;
            _addresses = new List<Address>();
        }

        public void Update(Name name, Email email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address){
            _addresses.Add(address);
        }

        public override string ToString(){
            return Name.ToString();
        }
    }
}