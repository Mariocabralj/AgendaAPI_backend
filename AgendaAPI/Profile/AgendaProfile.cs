using System.Runtime.InteropServices;
using AgendaAPI.Models.Pessoas;
using AutoMapper;

namespace AgendaAPI.Profiles;

public class AgendaProfile : Profile
{
    public AgendaProfile()
    {
        CreateMap<AgendaDTO, AgendaInfos>();
    }
}
