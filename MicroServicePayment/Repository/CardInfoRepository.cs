using MicroServicePayment.DTO;
using MicroServicePayment.Interfaces;
using MicroServicePayment.Models;
using Microsoft.EntityFrameworkCore;

public class CardInfoRepository : ICardInfoRepository  
{
    private readonly PayDbContext _dbContext;

    public CardInfoRepository(PayDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public CardInfoDto GetCardInfoByCardNumber(string cardNumber)
    {
        var card = _dbContext.Paymentcards
            .AsNoTracking()
            .Where(c => c.Cardnumber == cardNumber)
            .Select(c => new CardInfoDto
            {
                Pk = c.Pk,
                Status = c.Status,
                Deliverydate = c.Deliverydate,
                Expirydate = c.Expirydate,
                Cardnumber = c.Cardnumber,
                Maxgab = c.Maxgab,
                Maxtpe = c.Maxtpe,
                // Add other required properties from Paymentcard entity if needed...
            })
            .SingleOrDefault();

        return card;
    }
}
