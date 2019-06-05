using System;
using System.Collections.Generic;

namespace DouglasStore.Domain.StoreContext.OrderCommands.Inputs{

    public class OrderItemCommand{
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}