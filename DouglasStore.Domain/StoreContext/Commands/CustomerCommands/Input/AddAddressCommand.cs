

using System;
using DouglasStore.Domain.StoreContext.Enums;

namespace DouglasStore.Domain.StoreContext.CustomerCommands.Inputs{

    public class AddAddressCommand{
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

    }
}