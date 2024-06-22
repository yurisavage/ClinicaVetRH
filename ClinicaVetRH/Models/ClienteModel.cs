using ClinicaVetRH.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVetRH.Models
{
    public class ClienteModel
    {
        [Key]
        public long Id { get; set; }
        public virtual string? Nome { get; set; }
        public virtual int TipoCliente { get; set; }
        public virtual int SexoCliente { get; set; }
        public virtual long CpfCnpj { get; set; }
        public virtual string? Endereco { get; set; }
        public virtual string? Cidade { get; set; }
        public virtual string? Estado { get; set; }
        public virtual int? Telefone { get; set; }
        public virtual int Whatsapp { get; set; }
        public virtual string? Email { get; set; }
        public virtual int Situacao { get; set; }


        public virtual IList<PetModel>? PetModel { get; set; }
        public virtual IList<AgendamentoModel>? AgendamentoModel { get; set; }

    }
}
