namespace ClinicaVetRH.Models.ModelRequest
{
    public class PetCadastroModelRequest
    {
        public virtual string NomeAnimal { get; set; }
        public virtual int Especie { get; set; }
        public virtual string? Raca { get; set; }
        public virtual int SexoDoAnimal { get; set; }
        public long IdCliente { get; set; }
    }
}
