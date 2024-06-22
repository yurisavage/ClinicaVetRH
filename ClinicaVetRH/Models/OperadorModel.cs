using System.ComponentModel.DataAnnotations;

namespace ClinicaVetRH.Models
{
    public class OperadorModel
    {
        [Key]
        public long Id { get; set; }
        public virtual string NomeOperador { get; set; }
        public virtual int Cpf { get; set; }
        public virtual string Senha { get; set; }
        public virtual int NivelDeAcesso { get; set; }


        public virtual List<AgendamentoModel>? Agendamento { get; set; }
    }
}
