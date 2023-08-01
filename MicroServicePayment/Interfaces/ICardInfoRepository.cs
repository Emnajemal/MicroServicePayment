using MicroServicePayment.DTO;

namespace MicroServicePayment.Interfaces
{
        public interface ICardInfoRepository
        {
            CardInfoDto GetCardInfoByCardNumber(string cardNumber);
        }


}

