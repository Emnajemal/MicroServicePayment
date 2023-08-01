using AutoMapper;
using MicroServicePayment.Models;
using MicroServicePayment.DTO;

public class NternalaccountProfile : Profile
{
    public NternalaccountProfile()
    {
        CreateMap<Nternalaccount, NternalaccountDTO>();
    }
}
