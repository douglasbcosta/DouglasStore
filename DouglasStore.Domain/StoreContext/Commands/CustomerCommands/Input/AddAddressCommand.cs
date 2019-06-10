

using System;
using DouglasStore.Domain.StoreContext.Enums;
using DouglasStore.Shared.Commands;
using FluentValidator;

namespace DouglasStore.Domain.StoreContext.CustomerCommands.Inputs{

    public class AddAddressCommand : Notifiable, ICommand{
        public Guid Id { get; set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
        public EAddressType Type { get; set; }

        public bool IsValid()
        {
            return Valid;
        }
    }
}