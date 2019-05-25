using System;
using System.Collections.Generic;

namespace DouglasStore.Domain.StoreContext.Entities
{
    public class Order{
        public Customer Costumer { get; private set; }
        public int Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Status { get; private set; }
        public IList<OrderItem> Items { get; private set; }
        public void Place(){}
    }
}