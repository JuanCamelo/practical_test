using AutoMapper;
using POO.Application.DTOs.Request;
using POO.Application.DTOs.Response;
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

            CreateMap<AccountWithdrawal, ViewAccountTransaction>()
            .ForMember(c => c.Ammount, opt => opt.MapFrom(src => src.Amount))
            .ForMember(c => c.DateTransaction, opt => opt.MapFrom(src => src.RetirementDate.ToString("dd/mm/yyyy")));
        }
    }
}
