using AutoMapper;

namespace Proposta.Api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Proposta, Domain.Dto.PropostaDto> ().ReverseMap();
        }
    }
}