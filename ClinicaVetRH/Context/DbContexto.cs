using ClinicaVetRH.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVetRH.Context
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> db)
            :base(db)
        {
        }

        public DbSet<ClienteModel> clienteModels { get; set; }
        public DbSet<PetModel> petModels { get; set; }
        public DbSet<OperadorModel> operadorModels { get; set; }
        public DbSet<AgendamentoModel> agendamentoModels { get; set; }
        public DbSet<ServicoModel> servicoModels { get; set; }


    }
}
