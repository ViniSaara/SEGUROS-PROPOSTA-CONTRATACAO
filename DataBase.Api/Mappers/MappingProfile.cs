using AutoMapper;
using DataBase.Api.Entities;
using DataBase.Api.ViewModel;

namespace DataBase.Api.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Proposta, PropostaViewModel>().ReverseMap();
            CreateMap<Contratacao, ContratacaoViewModel>().ReverseMap();
        }
    }
}