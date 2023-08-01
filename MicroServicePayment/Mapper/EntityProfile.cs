using AutoMapper;
using MicroServicePayment.Models;
using MicroServicePayment.DTO;

public class EntityProfile : Profile
{
    public EntityProfile()
    {
        CreateMap<Entity, EntityDTO>();
    }
}
