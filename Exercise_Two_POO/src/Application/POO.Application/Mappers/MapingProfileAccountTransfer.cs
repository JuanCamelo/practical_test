using AutoMapper;
using POO.Application.DTOs.Request;
using POO.Application.DTOs.Response;
using POO.Infraestructure.Entities;

namespace POO.Application.Mappers
{
    public class MapingProfileAccountTransfer :Profile
    {
        public MapingProfileAccountTransfer()
        {
            CreateMap<ModelAccountTransfer, AccountTransfer>()
                .ForMember(c => c.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(c => c.DateTransfer, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(c => c.Status, opt => opt.MapFrom(src => "PENDING"));

            CreateMap<AccountTransfer, ViewAccountTransaction>()
           .ForMember(c => c.Ammount, opt => opt.MapFrom(src => src.Amount))
           .ForMember(c => c.DateTransaction, opt => opt.MapFrom(src => src.DateTransfer.ToString("dd/mm/yyyy")));
        }
    }
}
