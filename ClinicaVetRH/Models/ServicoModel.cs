using System.ComponentModel.DataAnnotations;

namespace ClinicaVetRH.Models
{
    public class ServicoModel
    {
        [Key]
        public int Id { get; set; }
        public virtual string Servico { get; set; }
        public virtual decimal Valor { get; set; }


        public virtual IEnumerable<AgendamentoModel>? AgendamentoModel { get; set; }
    }
}
