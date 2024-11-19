using AgendaAPI.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Services.Usuarios.Comandos;

public class ExcluirUsuario
{
    private readonly AgendaContext _context;
    private readonly IMapper _mapper;
    public ExcluirUsuario(AgendaContext agendaContext, IMapper mapper)
    {
        _context = agendaContext;
        _mapper = mapper;
    }
    public IActionResult Excluir(Guid Id) 
    {
        var usuario = _context.Agenda.FirstOrDefault(c => c.PessoaId == Id);
        if (usuario == null) return new NotFoundResult();

        _context.Agenda.Remove(usuario);
        _context.SaveChanges();
        return new NoContentResult();
    }
}
