using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouglasStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Douglas","Costa");
            var document = new Document("1234556");
            var email = new Email("teste@teste.com.br");
            var c = new Customer(name,document,email, "1235654");
            var order = new Order(c);
            var mouse = new Product("Mouse", "Rato","image.png",58.90M, 1.0M);
            var teclado = new Product("Teclado", "Teclado","image.png",158.90M, 1.0M);
            var impressora = new Product("Impressora", "Impressora","image.png",539.90M, 1.0M);
            var cadeira = new Product("Cadeira", "Cadeira","image.png",559.90M, 1.0M);

            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(impressora, 5));
            order.AddItem(new OrderItem(cadeira, 5));
            order.Place();
            
            order.Pay();

            order.Ship();

            order.Cancel();
        }
    }
}
