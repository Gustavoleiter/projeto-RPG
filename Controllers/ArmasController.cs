using Microsoft.AspNetCore.Mvc;
using RpgApi.Controllers;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using Microsoft.EntityFrameworkCore;
using System;

namespace Armas.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ArmasController : ControllerBase
    {

        private readonly DataContext _context;

        public ArmasController(DataContext context)
        {
            _context = context;
        }



        [HttpGet("MostrarTodos")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Arma> lista = await _context.Armas.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> Add(Arma novaArma)
        {
            try
            {
                if (novaArma.Dano == 0)
                    throw new System.Exception("O dano da arma não pode ser 0");

                Personagem p = await _context.Personagens.FirstOrDefaultAsync(p => p.Id == novaArma.PersonagemId);

                if (p == null)
                   throw new System.Exception("Não existe personagem com Id informado");
                await _context.Armas.AddAsync(novaArma);
                await _context.SaveChangesAsync();
                return Ok(novaArma.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
    }



        [HttpPut]
        public async Task<IActionResult> Update(Arma novaArma)
        {
            try
            {

                _context.Armas.Update(novaArma);
                int linhasAfetedas = await _context.SaveChangesAsync();

                return Ok(linhasAfetedas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Arma a = await _context.Armas.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

                return Ok(a);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Arma aRemover = await _context.Armas.FirstOrDefaultAsync(a => a.Id == id);

                _context.Armas.Remove(aRemover);
                int linhasAfetedas = await _context.SaveChangesAsync();
                return Ok(linhasAfetedas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}