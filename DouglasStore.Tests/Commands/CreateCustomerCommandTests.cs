using DouglasStore.Domain.StoreContext.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouglasStore.Tests{
     [TestClass]
     public class CreateCustomerCommandTests
     {
         [TestMethod]
         public void ShouldValidateWhenCommandIsValid(){
             var command = new CreateCustomerCommand();
             command.FirstName = "Douglas";
             command.LastName = "Costa";
             command.Document = "28659170377";
             command.Email = "teste@teste.com";

             Assert.AreEqual(true, command.IsValid());
             Assert.AreEqual(0, command.Notifications.Count); 
         }
     }
 }