using AgendaAPI.Data;
using AgendaAPI.Models.Pessoas;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Services.Usuarios.Comandos;

public class AtualizarUsuario
{
    private readonly AgendaContext _context;
    private readonly IMapper _mapper;

    public AtualizarUsuario(AgendaContext agendaContext, IMapper mapper)
    {
        _context = agendaContext;
        _mapper = mapper;
    }

    public IActionResult Atualizar(Guid Id, AgendaDTO agendaDTO)
    {
        var usuario = _context.Agenda.FirstOrDefault(c => c.PessoaId == Id);
        if (usuario == null) return new NotFoundResult();

        _mapper.Map(agendaDTO, usuario);
        _context.SaveChanges();
        return new NoContentResult();
    }
}