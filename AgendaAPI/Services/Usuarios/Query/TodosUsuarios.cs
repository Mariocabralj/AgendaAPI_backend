using AgendaAPI.Data;
using AgendaAPI.Models.Pessoas;
using AgendaAPI.Profiles;
using AutoMapper;

namespace AgendaAPI.Services.Usuarios.Query;

public class TodosUsuarios
{
    private readonly AgendaContext _context;
    private readonly IMapper _mapper;
    public TodosUsuarios(AgendaContext agendaContext, IMapper mapper)
    {
        _context = agendaContext;  
        _mapper = mapper;
    }
    public IEnumerable<AgendaInfos> Usuarios(int skip = 0, int take = 50)
    {
        return _mapper.Map<List<AgendaInfos>>(
        _context.Agenda.Skip(skip).Take(take).ToList()
    );
    }
}
