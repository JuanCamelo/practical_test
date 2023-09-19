using AutoMapper;
using POO.Application.DTOs.Request;
using POO.Infraestructure.Entities;

namespace POO.Application.Mappers
{
    public class MapingProfileAccount : Profile
    {
        public MapingProfileAccount()
        {
            CreateMap<ModelAccount, BankAccount>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => Guid.NewGuid()))

                .ForMember(c => c.OpeningDate, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<ModelAccountClient,ModelAccount>()
                .ForMember(c => c.Balance, opt => opt.MapFrom(src => src.Balance));
        }
    }
}
