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
            .ForMember(desenvolvedoresDto => desenvolvedoresDto.Projeto,
            opt => opt.MapFrom(desenvolvedores => desenvolvedores.Projeto));
        CreateMap<UpdateDesenvolvedorDto, Desenvolvedor>();
    }
}
