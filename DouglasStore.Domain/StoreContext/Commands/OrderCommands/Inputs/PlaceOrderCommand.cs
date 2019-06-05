using System;
using System.Collections.Generic;

namespace DouglasStore.Domain.StoreContext.OrderCommands.Inputs{

    public class PlaceOrderCommand{
        
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }


    }
}