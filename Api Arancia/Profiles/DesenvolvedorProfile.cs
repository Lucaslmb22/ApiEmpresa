using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;

namespace Api_Arancia.Profiles;

public class DesenvolvedorProfile : Profile
{
    public DesenvolvedorProfile()
    {
        CreateMap<CreateDesenvolvedorDto, Desenvolvedor>();
        CreateMap<Desenvolvedor, ReadDesenvolvedorDto>()
            .ForMember(desenvolvedoresDto => desenvolvedoresDto.Projetos,
            opt => opt.MapFrom(desenvolvedores => desenvolvedores.Projetos));
        CreateMap<UpdateDesenvolvedorDto, Desenvolvedor>();
    }
}
