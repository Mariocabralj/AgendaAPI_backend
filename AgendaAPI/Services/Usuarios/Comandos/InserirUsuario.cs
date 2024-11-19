using AgendaAPI.Data;
using AgendaAPI.Models.Pessoas;
using AgendaAPI.Profiles;
using AgendaAPI.Services.Usuarios.Query;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Services.Usuarios.Comandos;

public class InserirUsuario
{
    private readonly AgendaContext _context;

    public InserirUsuario(AgendaContext context)
    {
        _context = context;
    }

    public IActionResult Inserir(AgendaDTO agendaDto, IUrlHelper urlHelper)
    {
        var usuario = new AgendaInfos()
        {
            Nome = agendaDto.Nome,
            Email = agendaDto.Email,
            Telefone = agendaDto.Telefone
        };

        _context.Agenda.Add(usuario);
        _context.SaveChanges();

        var url = urlHelper.Action("BuscarPorId", "Agenda", new { Id = usuario.PessoaId }, "https");
        return new CreatedResult(url, usuario);
    }
}
