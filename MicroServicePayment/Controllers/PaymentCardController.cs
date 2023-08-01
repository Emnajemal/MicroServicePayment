using Microsoft.AspNetCore.Mvc;
using MicroServicePayment.DTO;

using MicroServicePayment.Interfaces;
using AutoMapper;

namespace MicroServicePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentCardController : ControllerBase
    {
        private readonly IPaymentCardRepository _paymentCardRepository;
        private readonly IMapper _mapper;

        public PaymentCardController(IPaymentCardRepository paymentCardRepository, IMapper mapper)
        {
            _paymentCardRepository = paymentCardRepository;
            _mapper = mapper;
        }

        [HttpGet("{entityIdentifier}")]
        public IActionResult GetPaymentCardsForEntity(string entityIdentifier)
        {
            // Appel du repository pour obtenir les cartes de paiement associées à l'entité
            var paymentCards = _paymentCardRepository.GetPaymentCardsForEntity(entityIdentifier);

            // Mapper les entités vers les DTOs

            var paymentCardDTOs = _mapper.Map<List<PaymentcardDTO>>(paymentCards);


            // Retourner les DTOs en tant que réponse de l'API
            return Ok(paymentCardDTOs);
        }
    }
}