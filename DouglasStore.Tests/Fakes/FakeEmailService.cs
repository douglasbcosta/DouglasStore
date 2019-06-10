using DouglasStore.Domain.StoreContext.Services;

namespace DouglasStore.Tests{

    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body)
        {
            
        }
    }
}