using System;
using DouglasStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DouglasStore.Domain.StoreContext.CustomerCommands.Inputs{

    public class DeleteCustomerCommand : Notifiable, ICommand {
        public Guid Id { get; set; }
        public bool IsValid(){

            return Valid;
        }
    }
}