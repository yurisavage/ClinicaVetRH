namespace ClinicaVetRH.ArquivosJson
{
    public class ClienteModelJson
    {
        public virtual string? nome { get; set; }
        public virtual int tipoCliente { get; set; }
        public virtual int sexoCliente { get; set; }
        public virtual long cpfCnpj { get; set; }
        public virtual string? endereco { get; set; }
        public virtual string? cidade { get; set; }
        public virtual string? estado { get; set; }
        public virtual int? telefone { get; set; }
        public virtual int whatsapp { get; set; }
        public virtual string? email { get; set; }
        public virtual int situacao { get; set; }
        public virtual string? nomeAnimal { get; set; }
        public virtual int especie { get; set; }
        public virtual string? raca { get; set; }
        public virtual int sexoDoAnimal { get; set; }
    }
}
