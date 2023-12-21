using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;

namespace Api_Arancia.Profiles;

public class ProjetosProfile: Profile   
{
    public ProjetosProfile()
    {
        CreateMap<CreateProjetosDto, Projetos>();
        CreateMap<Projetos, ReadProjetosDto>();
        CreateMap<UpdateProjetosDto, Projetos>();
    }
}
