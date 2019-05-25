using System;
using DouglasStore.Domain.StoreContext.Enums;

namespace DouglasStore.Domain.StoreContext.Entities
{
    public class Delivery 
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            EstimatedDeliveryDate = estimatedDeliveryDate;
            CreateDate = DateTime.Now;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; } 
        public DateTime EstimatedDeliveryDate { get; set; }
        public EDeliveryStatus Status{get; set;}

        public void Ship(){
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel(){
            if(Status != EDeliveryStatus.Delivered)
                Status = EDeliveryStatus.Canceled;
        }
    }
}