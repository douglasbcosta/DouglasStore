using System;
using System.Collections.Generic;
using DouglasStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DouglasStore.Domain.StoreContext.OrderCommands.Inputs{

    public class PlaceOrderCommand: Notifiable, ICommand{
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool IsValid(){

            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(),36,"Customer","Identificador do cliente inválido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
            );
            return Valid;
        }
    }
}