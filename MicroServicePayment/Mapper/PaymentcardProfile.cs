using AutoMapper;
using MicroServicePayment.Models;
using MicroServicePayment.DTO;

public class PaymentcardProfile : Profile
{
    public PaymentcardProfile()
    {
        CreateMap<Paymentcard, PaymentcardDTO>();
    }
}
