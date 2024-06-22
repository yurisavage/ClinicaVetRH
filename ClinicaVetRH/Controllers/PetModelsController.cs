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

namespace ClinicaVetRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetModelsController : ControllerBase
    {
        private readonly DbContexto _context;

        public PetModelsController(DbContexto context)
        {
            _context = context;
        }

        // GET: api/PetModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetModel>>> GetpetModels()
        {
          if (_context.petModels == null)
          {
              return NotFound();
          }
            return await _context.petModels.ToListAsync();
        }

        // GET: api/PetModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PetModel>> GetPetModel(long id)
        {
          if (_context.petModels == null)
          {
              return NotFound();
          }
            var petModel = await _context.petModels.FindAsync(id);

            if (petModel == null)
            {
                return NotFound();
            }

            return petModel;
        }

        // PUT: api/PetModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPetModel(long id, PetModel petModel)
        {
            if (id != petModel.IdAnimal)
            {
                return BadRequest();
            }

            _context.Entry(petModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetModelExists(id))
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

        // POST: api/PetModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("cadastropet")]
        public async Task<ActionResult<PetModel>> PostPetModel(PetCadastroModelRequest petCadastroModelRequest)
        {
          if (_context.petModels == null)
          {
              return Problem("Entity set 'DbContexto.petModels'  is null.");
          }
          PetModel petModel = new PetModel();
            petModel.NomeAnimal = petCadastroModelRequest.NomeAnimal;
            petModel.Especie = petCadastroModelRequest.Especie;
            petModel.Raca = petCadastroModelRequest.Raca;
            petModel.SexoDoAnimal = petCadastroModelRequest.SexoDoAnimal;
            petModel.IdCliente = petCadastroModelRequest.IdCliente;            

            _context.petModels.Add(petModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostPetModel), new { id = petModel.IdAnimal }, petModel);
        }

        // DELETE: api/PetModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetModel(long id)
        {
            if (_context.petModels == null)
            {
                return NotFound();
            }
            var petModel = await _context.petModels.FindAsync(id);
            if (petModel == null)
            {
                return NotFound();
            }

            _context.petModels.Remove(petModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PetModelExists(long id)
        {
            return (_context.petModels?.Any(e => e.IdAnimal == id)).GetValueOrDefault();
        }
    }
}
