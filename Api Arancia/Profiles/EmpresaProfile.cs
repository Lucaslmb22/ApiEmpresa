using Api_Arancia.Data.Dtos;
using Api_Arancia.Modelos;
using AutoMapper;

namespace Api_Arancia.Profiles;

public class EmpresaProfile : Profile
{
    public EmpresaProfile()
    {
        CreateMap<CreateEmpresaDto, Empresa>();
        CreateMap<UpdateEmpresaDto, Empresa>();
        CreateMap<Empresa, ReadEmpresaDto>()
            .ForMember(empresaDto => empresaDto.Projeto,
            opt => opt.MapFrom(empresa => empresa.Projeto));
    }
}
