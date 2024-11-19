using AgendaAPI.Data;
using AgendaAPI.Models.Pessoas;

namespace AgendaAPI.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly AgendaContext _context;

        public AgendaService(AgendaContext context)
        {
            _context = context;
        }

        public IEnumerable<AgendaInfos> GetAllAgendas()
        {
            return _context.Agenda.ToList();
        }

        public void AddAgenda(AgendaInfos agenda)
        {
            _context.Agenda.Add(agenda);
            _context.SaveChanges();
        }

        public AgendaInfos? GetAgendaById(Guid id)
        {
            return _context.Agenda.FirstOrDefault(a => a.PessoaId == id);
        }

        public void UpdateAgenda(AgendaInfos agenda)
        {
            _context.Agenda.Update(agenda);
            _context.SaveChanges();
        }

        public void DeleteAgenda(Guid id)
        {
            var agenda = _context.Agenda.FirstOrDefault(a => a.PessoaId == id);
            if (agenda != null)
            {
                _context.Agenda.Remove(agenda);
                _context.SaveChanges();
            }
        }
    }
}