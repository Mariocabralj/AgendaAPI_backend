using AgendaAPI.Data;
using AgendaAPI.Models.Pessoas;
using AgendaAPI.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Services.Usuarios.Query;

public class UsuarioPoriId
{
    private readonly AgendaContext _context;
    private readonly IMapper _mapper;
    public UsuarioPoriId(AgendaContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public IActionResult UsuarioPorId(Guid id)
    {
        var usuario = _context.Agenda.FirstOrDefault(c => c.PessoaId == id);
        if (usuario == null) return new NotFoundResult();

        return new OkObjectResult(usuario);
    }
}
