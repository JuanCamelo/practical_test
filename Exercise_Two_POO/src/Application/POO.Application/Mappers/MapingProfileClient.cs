using AutoMapper;
using POO.Application.DTOs.Request;
using POO.Application.DTOs.Response;
using POO.Infraestructure.Entities;

namespace POO.Application.Mappers
{
    public class MapingProfileClient : Profile
    {
        public MapingProfileClient() 
        {
            CreateMap<ModelAccountClient, Client>()
            .ForMember(c => c.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.Status, opt => opt.MapFrom(src => true))
            .ForMember(c => c.DocumentNumber, opt => opt.MapFrom(src => src.Document))
            .ForMember(c => c.Name, opt => opt.MapFrom(src => src.Client))
            .ForMember(c => c.LastName, opt => opt.MapFrom(src => src.Client))
            .ForMember(c => c.CreationDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(c => c.Update, opt => opt.MapFrom(src => DateTime.Now));

            CreateMap<Client, ViewClient>();
        }
    }
}
