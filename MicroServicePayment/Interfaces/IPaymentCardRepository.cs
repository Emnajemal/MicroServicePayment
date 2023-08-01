using MicroServicePayment.Models;

namespace MicroServicePayment.Interfaces
{
    public interface IPaymentCardRepository
    {
        List<Paymentcard> GetPaymentCardsForEntity(string entityIdentifier);
    }
}

