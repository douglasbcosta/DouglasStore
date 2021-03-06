using System;
using DouglasStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DouglasStore.Domain.StoreContext.CustomerCommands.Inputs{

    public class UpdateCustomerCommand : Notifiable, ICommand {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool IsValid(){

            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 30, "FirstName", "O nome deve conter pelo menos 30 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 30, "LastName", "O sobrenome deve conter pelo menos 30 caracteres")
                .IsEmail(Email, "Email", "O E-mail é inválido")
            );
            return Valid;
        }
    }
}