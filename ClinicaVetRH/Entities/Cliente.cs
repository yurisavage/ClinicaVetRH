using ClinicaVetRH.Entities.Enums;

namespace ClinicaVetRH.Entities
{
    public class Cliente
    {
        public long Id { get; set; }
        public virtual string? Nome { get; set; }
        public virtual int? TipoCliente { get; set; }
        public TipoCliente TipoClienteEnum { get; set; }
        public virtual int? SexoCliente { get; set; }
        public SexoCliente SexoClienteEnum { get; set; }
        public virtual long? CpfCnpj { get; set; }
        public virtual string? Endereco { get; set; }
        public virtual string? Cidade { get; set; }
        public virtual string? Estado { get; set; }
        public virtual int? Telefone { get; set; }
        public virtual int? Whatsapp { get; set; }
        public virtual string? Email { get; set; }
        public virtual int? Situacao { get; set; }
        public Situacao SituacaoEnum { get; set; }
        public virtual string? NomeAnimal { get; set; }
        public virtual int? Especie { get; set; }
        public Especie EspecieEnum { get; set; }
        public virtual string? Raca { get; set; }
        public virtual int? SexoDoAnimal { get; set; }
        public SexoDoAnimal SexoDoAnimalEnum { get; set; }

    }
}
