using AutoMapper;
using MicroServicePayment.Models;
using MicroServicePayment.DTO;

public class AccountcontractProfile : Profile
{
    public AccountcontractProfile()
    {
      
        CreateMap<Accountcontract, AccountcontractDTO>();
    }
}
