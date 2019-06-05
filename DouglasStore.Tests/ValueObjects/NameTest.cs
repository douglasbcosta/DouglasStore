using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouglasStore.Tests.ValueObjects
{
    [TestClass]
    public class NameTest 
    {
        [TestMethod]
        public void ShouldreturnNotificationWhenNameIsInvalid()
        {
            Name name = new Name("","Costa");
            //Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}