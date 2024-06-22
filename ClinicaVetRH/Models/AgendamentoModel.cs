using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.ComponentModel.DataAnnotations;

namespace ClinicaVetRH.Models
{
    public class AgendamentoModel
    {
        [Key]
        public long Id { get; set; }
        public virtual string? HoraInicial { get; set; }
        public virtual string? HoraFinal { get; set; }


        public virtual OperadorModel OperadorModel { get; set; }
        public virtual int? IdOperador { get; set; }

        public virtual ServicoModel ServicoModel { get; set; }
        public virtual int? IdServico { get; set; }

        public virtual ClienteModel ClienteModel { get; set; }
        public virtual long? IdCliente { get; set; }

        public virtual PetModel PetModel { get; set; }
        public virtual long? IdPet { get; set; }
    }
}
