using AutoMapper;
using POO.Application.DTOs.Response;
using POO.Domain.Model;

namespace POO.Application.Mappers
{
    public class MappingProfileHistoryMovements :Profile
    {
        public MappingProfileHistoryMovements()
        {
            CreateMap<LatestMovements, ViewHistoryMovements>();
        }
    }
}
