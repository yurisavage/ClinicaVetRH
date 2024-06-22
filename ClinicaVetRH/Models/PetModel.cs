using System.ComponentModel.DataAnnotations;

namespace ClinicaVetRH.Models
{
    public class PetModel
    {
        [Key]
        public long IdAnimal { get; set; }
        public virtual string? NomeAnimal { get; set; }
        public virtual int? Especie { get; set; }
        public virtual string? Raca { get; set; }
        public virtual int? SexoDoAnimal { get; set; }


        public ClienteModel ClienteModel { get; set; }
        public long IdCliente { get; set; }
    }
}
