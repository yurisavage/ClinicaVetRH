using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClinicaVetRH.Context;
using ClinicaVetRH.Models;
using ClinicaVetRH.Models.ModelRequest;
using Microsoft.IdentityModel.Tokens;
using ClinicaVetRH.Entities;
using ClinicaVetRH.Models.ModelResponse;
using System.Collections;

namespace ClinicaVetRH.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteModelsController : ControllerBase
    {
        private readonly DbContexto _context;

        public ClienteModelsController(DbContexto context)
        {
            _context = context;

        }

        // GET: api/ClienteModels
        [HttpGet]
        [Route("listaclientes")]
        public async Task<ActionResult<IList<ClienteConsultaModelResponse>>> GetclienteModels()
        {
            IList<ClienteModel> clienteModels = await _context.clienteModels.ToListAsync();
            IList<ClienteConsultaModelResponse> listaClientes = new List<ClienteConsultaModelResponse>();

            if (clienteModels == null)
            {
              return NotFound();
            }
            else
            {
                foreach(var item in clienteModels)
                {
                    ClienteConsultaModelResponse clienteConsultaModelResponse = new ClienteConsultaModelResponse();
                    clienteConsultaModelResponse.CriarCliente(item);
                    listaClientes.Add(clienteConsultaModelResponse);
                }
            }

            return listaClientes.ToList();
        }

        // GET: api/ClienteModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteConsultaModelResponse>> GetClienteModel(long id)
        {
          if (_context.clienteModels == null)
          {
              return NotFound();
          }
            ClienteModel clienteModel = await _context.clienteModels.FindAsync(id);
            ClienteConsultaModelResponse clienteConsultaModelResponse = new ClienteConsultaModelResponse();

            if (clienteModel == null)
            {
                return NotFound();
            }
            else
            {
                clienteConsultaModelResponse.CriarCliente(clienteModel);
            }
            return clienteConsultaModelResponse;
        }

        // [HttpGet("{nome}/{nomeAnimal}/{especie}")]
        [HttpPost]
        [Route("consultacliente")]
        public async Task<ActionResult<IList<ClienteModel>>> GetClienteCamposModel(ClienteModelRequest clienteModelRequest)
        {
            if (_context.clienteModels == null)
            {
                return NotFound();
            }

            IList<ClienteModel> clienteModel = await _context.clienteModels.ToListAsync();
            IList<PetModel> petModel = await _context.petModels.ToListAsync();
            
            if (!string.IsNullOrEmpty(clienteModelRequest.nome)) clienteModel = clienteModel.Where(c => c.Nome.ToUpper().Contains(clienteModelRequest.nome.Trim().ToUpper())).ToList();
            if (!string.IsNullOrEmpty(clienteModelRequest.nomeAnimal)) {
                IList<ClienteModel> query = (from p in petModel
                                     join c in clienteModel
                                     on p.IdCliente equals c.Id
                                        where (p.NomeAnimal.ToUpper().Trim().Contains(clienteModelRequest.nomeAnimal.ToUpper().Trim()))
                                        select c).ToList();

                clienteModel = clienteModel.Intersect(query).ToList();
            }
            /*clienteModel = clienteModel.Where(c => c.PetModel.NomeAnimal.ToUpper().Contains(clienteModelRequest.nomeAnimal.Trim().ToUpper())).ToList();*/

            if (clienteModelRequest.especie != null && clienteModelRequest.especie != 0) {
                IList<ClienteModel> query = (from p in petModel
                                             join c in clienteModel
                                             on p.IdCliente equals c.Id
                                             where (p.Especie == clienteModelRequest.especie)
                                             select c).ToList();

                clienteModel = clienteModel.Intersect(query).ToList();
            }
            /*clienteModel = clienteModel.Where(c => c.Especie == clienteModelRequest.especie).ToList();*/

            if (clienteModel == null)
            {
                return NotFound();
            }

            return clienteModel.ToList();
            //return null;
        }

        // PUT: api/ClienteModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClienteModel(int id, ClienteModel clienteModel)
        {
            if (id != clienteModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(clienteModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ClienteModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("cadastrocliente")]
        public async Task<ActionResult<ClienteModel>> PostClienteModel(ClienteCadastroModelRequest clienteCadastroModelRequest)
        {
          if (_context.clienteModels == null)
          {
              return Problem("Entity set 'DbContexto.clienteModels'  is null.");
          }
          ClienteModel cliente = new ClienteModel();
            cliente.Nome = clienteCadastroModelRequest.Nome;
            cliente.TipoCliente = clienteCadastroModelRequest.TipoCliente;
            cliente.SexoCliente = clienteCadastroModelRequest.SexoCliente;
            cliente.CpfCnpj = clienteCadastroModelRequest.CpfCnpj;
            cliente.Endereco = clienteCadastroModelRequest.Endereco;
            cliente.Cidade = clienteCadastroModelRequest.Cidade;
            cliente.Estado = clienteCadastroModelRequest.Estado;
            cliente.Telefone = clienteCadastroModelRequest.Telefone;
            cliente.Whatsapp = clienteCadastroModelRequest.Whatsapp;
            cliente.Email = clienteCadastroModelRequest.Email;
            cliente.Situacao = clienteCadastroModelRequest.Situacao;

            _context.clienteModels.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostClienteModel), new { id = cliente.Id }, cliente);
        }

        // DELETE: api/ClienteModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClienteModel(int id)
        {
            if (_context.clienteModels == null)
            {
                return NotFound();
            }
            var clienteModel = await _context.clienteModels.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            _context.clienteModels.Remove(clienteModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteModelExists(int id)
        {
            return (_context.clienteModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
