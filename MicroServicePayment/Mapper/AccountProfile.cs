using AutoMapper;
using MicroServicePayment.Models;
using MicroServicePayment.DTO;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountDTO>();
    }
}
