using Microsoft.AspNetCore.Mvc;
using RpgApi.Utils;
using RpgApi.Models;
using RpgApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RpgApi.Controllers

{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagemHabilidadesController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonagemHabilidadesController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddPersonagemHabilidadeAsync(PersonagemHabilidade novoPersonagemHabilidade)
        {
            try
            {
                Personagem personagem = await _context.Personagens
                .Include(p => p.Arma)
                .Include(p => p.PersonagemHabilidades).ThenInclude(ps => ps.Habilidade)
                .FirstOrDefaultAsync(p => p.Id == novoPersonagemHabilidade.PersonagemId);

                if (personagem == null)
                    throw new System.Exception("Personagem não encontrado para o Id informado");

                Habilidade habilidade = await _context.Habilidades
                                    .FirstOrDefaultAsync(h => h.Id == novoPersonagemHabilidade.HabilidadeId);

                if (habilidade == null)
                    throw new System.Exception("Habilidade não encontrada.");

                PersonagemHabilidade ph = new PersonagemHabilidade();
                ph.Personagem = personagem;
                ph.Habilidade = habilidade;
                await _context.PersonagemHabilidades.AddAsync(ph);
                int linhasAfetedas = await _context.SaveChangesAsync();

                return Ok(linhasAfetedas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]// buscar pelo ID
        
        public async Task<IActionResult> GetSingle(int id)
        {
            try 
            {
            Personagem p = await _context.Personagens
            .Include(ar => ar.Arma)// inclui na propriedade arma    do objeto p 
            .Include(ph => ph.PersonagemHabilidades)
            .ThenInclude(h => h.Habilidade)// inclui na lista de personagemHabilidade de p
            .FirstOrDefaultAsync(pBusca => pBusca.Id == id);

              return Ok(p);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}