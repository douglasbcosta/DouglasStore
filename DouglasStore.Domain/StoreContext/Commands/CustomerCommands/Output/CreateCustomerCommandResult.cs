using System;
using DouglasStore.Domain.StoreContext.ValueObjects;
using DouglasStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DouglasStore.Domain.StoreContext.CustomerCommands.Inputs{

    public class CreateCustomerCommandResult : ICommandResult {
        public CreateCustomerCommandResult(Guid id, string name, string document, string email, string phone)
        {
            Id = id;
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
        }

        public CreateCustomerCommandResult()
        {
            
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        
    }
}