using ClinicaVetRH.Context;

namespace ClinicaVetRH.Models.ModelResponse
{
    public class ClienteConsultaModelResponse
    {
        public ClienteConsultaModelResponse(){ }

        public long Id { get; set; }
        public virtual string Nome { get; set; }
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

        IList<PetResponse>? PetResponse { get; set; }

        public void CriarCliente(ClienteModel clienteModel)
        {
            Id = clienteModel.Id;
            Nome = clienteModel.Nome;
            TipoCliente = clienteModel.TipoCliente;
            SexoCliente = clienteModel.SexoCliente;
            CpfCnpj = clienteModel.CpfCnpj;
            Endereco = clienteModel.Endereco;
            Cidade = clienteModel.Cidade;
            Estado = clienteModel.Estado;
            Telefone = clienteModel.Telefone;
            Whatsapp = clienteModel.Whatsapp;
            Email = clienteModel.Email;
            Situacao = clienteModel.Situacao;

        }

        /*public void ListarPets(long id)
        {
            var response = _context.petModels.Where(p => p.IdCliente == id).ToList();
            if (response.Any())
            {
                foreach(var item in response)
                {
                    PetResponse pet = new PetResponse();
                    pet.IdAnimal = item.IdAnimal;
                    pet.NomeAnimal = item.NomeAnimal;
                    pet.Especie = item.Especie;
                    pet.Raca = item.Raca;
                    pet.SexoDoAnimal = item.SexoDoAnimal;
                    pet.IdCliente = item.IdCliente;
                    PetResponse.Add(pet);
                }
            }
        }*/

    }

    public class PetResponse
    {
        public PetResponse()
        {
            IList<PetResponse> petResponse = new List<PetResponse>();
        }

        public long IdAnimal { get; set; }
        public virtual string NomeAnimal { get; set; }
        public virtual int? Especie { get; set; }
        public virtual string? Raca { get; set; }
        public virtual int? SexoDoAnimal { get; set; }
        public long IdCliente { get; set; }
    }
}
