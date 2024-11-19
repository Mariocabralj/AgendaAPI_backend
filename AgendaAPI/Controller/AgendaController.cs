using AgendaAPI.Models.Pessoas;
using AgendaAPI.Services.Usuarios.Comandos;
using AgendaAPI.Services.Usuarios.Query;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AgendaController : ControllerBase
{
    private readonly ExcluirUsuario _excluirUsuario;
    private readonly InserirUsuario _inserirUsuario;
    private readonly AtualizarUsuario _atualizarUsuario; 
    private readonly TodosUsuarios _todosUsuarios;
    private readonly UsuarioPoriId _usuarioPorId; 
    private readonly IMapper _mapper;

    public AgendaController(
        InserirUsuario inserirUsuario,
        ExcluirUsuario excluirUsuario,
        AtualizarUsuario atualizarUsuario, 
        TodosUsuarios todosUsuarios,
        UsuarioPoriId usuarioPorId, 
        IMapper mapper)
    {
        _inserirUsuario = inserirUsuario;
        _excluirUsuario = excluirUsuario;
        _atualizarUsuario = atualizarUsuario; 
        _todosUsuarios = todosUsuarios;
        _usuarioPorId = usuarioPorId; 
        _mapper = mapper;
    }

    #region EndPoints Usuarios

    [HttpPost]
    public IActionResult InserirUsuario([FromBody] AgendaDTO agendaDTO)
    {
        return _inserirUsuario.Inserir(agendaDTO, Url);
    }
    

    [HttpGet]
    public IEnumerable<AgendaInfos> TodosUsuarios(int skip = 0, int take = 50) 
    {
        return _todosUsuarios.Usuarios(skip, take);
    }

    [HttpGet("{Id}")]
    public IActionResult BuscarPorId(Guid Id) 
    {
        return _usuarioPorId.UsuarioPorId(Id);
    }

    [HttpDelete("{Id}")]
    public IActionResult Deletar(Guid Id)
    {
        return _excluirUsuario.Excluir(Id);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarUsuario(Guid id, [FromBody] AgendaDTO agendaDTO)
    {
        return _atualizarUsuario.Atualizar(id, agendaDTO);
    }

    #endregion
}