using AgendaAPI.Models.Pessoas;

namespace AgendaAPI.Services
{
    public interface IAgendaService
    {
        IEnumerable<AgendaInfos> GetAllAgendas();
        void AddAgenda(AgendaInfos agenda);
        AgendaInfos? GetAgendaById(Guid id);
        void UpdateAgenda(AgendaInfos agenda);
        void DeleteAgenda(Guid id);
    }
}