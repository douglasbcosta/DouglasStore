using System;
using System.Collections.Generic;
using System.Linq;
using DouglasStore.Domain.StoreContext.Enums;

namespace DouglasStore.Domain.StoreContext.Entities
{
    public class Order{
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer custumer)
        {
            Custumer = custumer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Custumer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();
        public void AddItem(OrderItem item){
            _items.Add(item);
        }
        public void AddDelivery(Delivery delivery){
            _deliveries.Add(delivery);
        }
        public void Place(){
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
        }

        public void Pay(){

            Status = EOrderStatus.Paid;
        }
        public void Ship(){
            int count = 1;
            var deliveries = new List<Delivery>();
            foreach(var item in _items){
                if(count == 5){
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count ++;
            }
            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        public void Cancel(){
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}