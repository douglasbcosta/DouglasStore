using System;
using DouglasStore.Domain.StoreContext.CustomerCommands.Inputs;
using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.Repositories;
using DouglasStore.Domain.StoreContext.Services;
using DouglasStore.Domain.StoreContext.ValueObjects;
using DouglasStore.Shared.Commands;
using FluentValidator;

namespace DouglasStore.Domain.StoreContext.Handlers{
    public class CustomerHandler : Notifiable,
     ICommandHandler<CreateCustomerCommand>, 
     ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if(_repository.CheckDocument(command.Document))
                AddNotification("Document","Este CPF já está em uso");

            if(_repository.CheckDocument(command.Email))
                AddNotification("Email","Este Email já está em uso");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, document, email, command.Phone);
            
            AddNotifications(name, document, email, customer);

            if(Invalid)
                return new CreateCustomerCommandResult(false, "Por favor, corrija os campos abaixo", Notifications);

            _repository.Save(customer);
            _emailService.Send(email.Address, "hello@teste.com","Bem vindo", "Seja bem vindo(a) ao DouglasStore");

            return new CreateCustomerCommandResult(true, "Bem vindo ao Douglas Store", new {
                Id = customer.Id, 
                Name = customer.Name, 
                Email = customer.Email, 
                Phone = customer.Phone
            });
        }

        public ICommandResult Handle(UpdateCustomerCommand command)
        {
            if(_repository.CheckEmailUpdate(command.Email))
                AddNotification("Email","Este Email já está em uso");

            var currentCustomer = _repository.GetById(command.Id);                 
            var name = new Name(currentCustomer.FirstName, currentCustomer.LastName);
            var email = new Email(currentCustomer.Email);

            var customer = new Customer(_repository.GetById(command.Id), command.Id);
            customer.Update(name, email, command.Phone);

            AddNotifications(name,  email, customer);

            if(Invalid)
                return new UpdateCustomerCommandResult(false, "Por favor, corrija os campos abaixo", Notifications);

            _repository.Update(customer);
            _emailService.Send(email.Address, "hello@teste.com","Bem vindo", "Alteração de cadastro realizada com sucesso");

            return new UpdateCustomerCommandResult(true, "Alteração de cadastro realizada com sucesso", new {
                Id = customer.Id, 
                Name = customer.Name, 
                Email = customer.Email, 
                Phone = customer.Phone
            });
        }

        public ICommandResult Handle(DeleteCustomerCommand command)
        {
            if(_repository.CheckId(command.Id))
                AddNotification("Id","Usuário não encontrado");

            if(Invalid)
                return new DeleteCustomerCommandResult(false, "Erro ao deletar o cadastro", Notifications);

            _repository.Delete(command.Id);

            return new DeleteCustomerCommandResult(true, "Cadastro removido com sucesso", null);
        }
        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}