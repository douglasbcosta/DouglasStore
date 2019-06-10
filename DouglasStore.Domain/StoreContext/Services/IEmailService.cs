using DouglasStore.Domain.StoreContext.Entities;

namespace DouglasStore.Domain.StoreContext.Services{
    public interface IEmailService
    {
        void Send(string to, string from, string subject, string body);
    }
}