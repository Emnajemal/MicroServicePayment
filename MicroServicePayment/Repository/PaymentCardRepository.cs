using System.Collections.Generic;
using System.Linq;
using MicroServicePayment.Interfaces;
using MicroServicePayment.Models;

public class PaymentCardRepository : IPaymentCardRepository
{
    private readonly PayDbContext _dbContext;

    public PaymentCardRepository(PayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Paymentcard> GetPaymentCardsForEntity(string entityIdentifier)
    {
        var targetEntityIdentifier = entityIdentifier;

        var paymentCards = _dbContext.Entities
            .Where(e => e.Identifier == targetEntityIdentifier)
            .Join(_dbContext.Nternalaccounts,
                e => e.Pk,
                ntr => ntr.Ownerpk,
                (e, ntr) => ntr)
            .Join(_dbContext.Accounts,
                ntr => ntr.Internalaccountspk,
                ac => ac.Pk,
                (ntr, ac) => ac)
            .Join(_dbContext.Accountcontracts,
                ac => ac.Pk,
                acc => acc.Accountpk,
                (ac, acc) => acc)
            .Join(_dbContext.Paymentcards,
                acc => acc.Accountcode,
                pc => pc.Accountcode,
                (acc, pc) => pc)
            .ToList();

        return paymentCards;
    }
}
