using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.Enums;
using DouglasStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouglasStore.Tests.ValueObjects
{
    [TestClass]
    public class OrderTests 
    {
        private Customer _customer;
        private Order _order;
        private Product _mouse;
        private Product _keyboard;
        private Product _chair;
        private Product _monitor;
        public OrderTests()
        {
            Name name = new Name("Douglas","Costa");
            Document document = new Document("28659170377");
            Email email = new Email("teste@teste.com");
            _customer = new Customer(name, document,email, "24578913");
            _order = new Order(_customer);
            _mouse = new Product("Mouse gamer","Mouse gamer", "mouse.jpg", 99M, 10);
            _keyboard = new Product("Teclado","Mouse gamer", "mouse.jpg", 99M, 10);
            _chair = new Product("Cadeira","Mouse gamer", "mouse.jpg", 99M, 10);
            _monitor = new Product("Monitor","Mouse gamer", "mouse.jpg", 99M, 10);
           
        }
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Order Order = new Order(_customer);
            Assert.AreEqual(true, _order.Valid);
        }

        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated(){
            
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems(){
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItems(){
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced (){
            _order.Place();
            Assert.AreNotEqual("",_order.Number);
        }
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid (){
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
            
        }
        [TestMethod]
        public void ShouldReturnTwoWhenPurchasedTenProducts (){
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            Assert.AreEqual(2, _order.Deliveries.Count);
        }
        [TestMethod]
        public void ShouldCancelWhenOrderCanceled (){
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            _order.Cancel();
            foreach(var x in _order.Deliveries){
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }
    }
}