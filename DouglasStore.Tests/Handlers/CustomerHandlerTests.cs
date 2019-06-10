using DouglasStore.Domain.StoreContext.CustomerCommands.Inputs;
using DouglasStore.Domain.StoreContext.Handlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouglasStore.Tests{
     [TestClass]
     public class CustomerHandlerTests
     {
         [TestMethod]
         public void ShouldRegisterCustomerWhenCommandIsValid(){
             var command = new CreateCustomerCommand();
             command.FirstName = "Douglas";
             command.LastName = "Costa";
             command.Document = "28659170377";
             command.Email = "teste@teste.com";

             Assert.AreEqual(true, command.IsValid());
             Assert.AreEqual(0, command.Notifications.Count); 
             
             var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
             var result = handler.Handle(command);

             Assert.AreNotEqual(null, result);
             Assert.AreEqual(true, handler.Valid);
         }
     }
 }