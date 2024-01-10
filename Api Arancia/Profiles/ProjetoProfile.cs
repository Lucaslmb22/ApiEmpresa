using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;

namespace Api_Arancia.Profiles;

public class ProjetoProfile: Profile   
{
    public ProjetoProfile()
    {
        CreateMap<CreateProjetoDto, Projeto>();
        CreateMap<Projeto, ReadProjetoDto>();
        CreateMap<UpdateProjetoDto, Projeto>();
    }
}
