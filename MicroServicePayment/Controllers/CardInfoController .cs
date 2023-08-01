using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MicroServicePayment.Models;
using MicroServicePayment.DTO; // Add the reference to the DTO namespace
using MicroServicePayment.Interfaces; // Add the reference to the Interfaces namespace

namespace MicroServicePayment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardInfoController : ControllerBase
    {
        private readonly ICardInfoRepository _cardInfoRepository;

        public CardInfoController(ICardInfoRepository cardInfoRepository)
        {
            _cardInfoRepository = cardInfoRepository;
        }

        [HttpGet("{cardNumber}")]
        public IActionResult GetCardInfo(string cardNumber)
        {
            var card = _cardInfoRepository.GetCardInfoByCardNumber(cardNumber);

            if (card == null)
            {
                return NotFound($"Card with Cardnumber '{cardNumber}' not found.");
            }

            return Ok(card);
        }
    }
}
