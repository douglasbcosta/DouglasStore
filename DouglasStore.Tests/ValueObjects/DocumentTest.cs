using DouglasStore.Domain.StoreContext.Entities;
using DouglasStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DouglasStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTest
    {
        private Document validDocument;
        private Document invalidDocument;
        public DocumentTest()
        {
            invalidDocument = new Document("12345678911");
            validDocument = new Document("28659170377");
        }
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, invalidDocument.Valid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }
        [TestMethod]
        public void ShouldNotReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.Valid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}