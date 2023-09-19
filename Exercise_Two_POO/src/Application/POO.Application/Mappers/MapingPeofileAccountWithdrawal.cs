using AutoMapper;
using POO.Application.DTOs.Request;
using POO.Infraestructure.Entities;

namespace POO.Application.Mappers
{
    public class MapingPeofileAccountWithdrawal : Profile
    {
        public MapingPeofileAccountWithdrawal()
        {

            CreateMap<ModelAccountWithdrawal, AccountWithdrawal>()
            .ForMember(c => c.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
            .ForMember(c => c.RetirementDate, opt => opt.MapFrom(src => DateTime.Now));
        }
    }
}
