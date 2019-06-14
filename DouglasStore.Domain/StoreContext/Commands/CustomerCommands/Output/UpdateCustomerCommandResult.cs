using System;
using DouglasStore.Domain.StoreContext.ValueObjects;
using DouglasStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DouglasStore.Domain.StoreContext.CustomerCommands.Inputs{

    public class UpdateCustomerCommandResult : ICommandResult {
        public UpdateCustomerCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}