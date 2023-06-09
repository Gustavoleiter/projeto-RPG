using Microsoft.AspNetCore.Mvc;
using RpgApi.Controllers;
using RpgApi.Data;
using RpgApi.Models;
using RpgApi.Models.Enuns;
using Microsoft.EntityFrameworkCore;
using System;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class PersonagensController : ControllerBase
    {

        private readonly DataContext _context;

        public PersonagensController(DataContext context)
        {
            _context = context;
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingle(int id)
    {
        try
        {
            Personagem p = await _context.Personagens.FirstOrDefaultAsync(pBusca => pBusca.Id == id);

            return Ok(p);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> Get()
    {
        try
        {
            List<Personagem> lista = await _context.Personagens.ToListAsync();
            return Ok(lista);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<IActionResult> Add(Personagem novoPersonagem)
    {
        try
        {
            if(novoPersonagem.PontosVida > 100)
            {
                throw new Exception("Pontos de vida não podem ser maior que 100");

            }
            await _context.Personagens.AddAsync(novoPersonagem);
            await _context.SaveChangesAsync();

            return Ok(novoPersonagem.Id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Personagem novoPersonagem)
    {
        try
        {
            if(novoPersonagem.PontosVida > 100)
            {
                throw new Exception("Pontos de vida não podem ser maior que 100");
            }
            _context.Personagens.Update(novoPersonagem);
            int linhasAfetedas = await _context.SaveChangesAsync();

            return Ok(linhasAfetedas);
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
            Personagem pRemove = await _context.Personagens.FirstOrDefaultAsync(p => p.Id == id);

            _context.Personagens.Remove(pRemove);
            int linhasAfetedas = await _context.SaveChangesAsync();
            return Ok(linhasAfetedas);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

     [HttpDelete("{id}")]
    public async Task<IActionResult> Delete1(int id)
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