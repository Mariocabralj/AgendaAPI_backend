using AgendaAPI.Models.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Data ;
public class AgendaContext : DbContext
{
    public AgendaContext(DbContextOptions<AgendaContext> opts) : base(opts) {}
    public DbSet<AgendaInfos> Agenda { get; set; }
}
