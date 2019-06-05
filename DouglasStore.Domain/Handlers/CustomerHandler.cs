using System;
using DouglasStore.Domain.StoreContext.CustomerCommands.Inputs;
using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.ValueObjects;
using DouglasStore.Shared.Commands;
using FluentValidator;

namespace DouglasStore.Domain.StoreContext.Handlers{
    public class CustomerHandler : Notifiable,
     ICommandHandler<CreateCustomerCommand>, 
     ICommandHandler<AddAddressCommand>
    {
        public ICommandResult Handle(CreateCustomerCommand command)
        {

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);
            
            AddNotifications(name, document, email, customer);

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), document.ToString(), email.ToString(), command.Phone);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}