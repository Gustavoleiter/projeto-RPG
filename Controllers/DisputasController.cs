using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgApi.Models;
using RpgApi.Data;
using System.Text;

namespace RpgApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class DisputasController : ControllerBase
    {
        private readonly DataContext _context;
        public DisputasController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("Arma")]
        public async Task<IActionResult> AtaqueComArmaAsyc(Disputa d)
        {
        try
        {
           Personagem atacante = await _context.Personagens
            .Include(p => p.Arma)
            .FirstOrDefaultAsync(p => p.Id == d.AtacanteId);


           Personagem oponente = await _context.Personagens
            .FirstOrDefaultAsync(p => p.Id == d.OponenteId);


            int dano = atacante.Arma.Dano + (new Random().Next(atacante.Forca));
            dano = dano - new Random().Next(oponente.Defesa);

            if (dano > 0 )
                oponente.PontosVida = oponente.PontosVida - (int) dano;
            if (oponente.PontosVida <= 0 )
                d.Narracao = $"{oponente.Nome} foi derrotado!";
            
            _context.Personagens.Update(oponente);
            await _context.SaveChangesAsync();

            StringBuilder dados = new StringBuilder();
            dados.AppendFormat("Atacante: {0} .",atacante.Nome);
            dados.AppendFormat("Oponente: {0} .",oponente.Nome);
            dados.AppendFormat("Pontos de vida do atacante: {0} .",atacante.PontosVida);
            dados.AppendFormat("Pontos de vida do oponente: {0} .",oponente.PontosVida);
            dados.AppendFormat("Arma ultilizada: {0}",atacante.Arma.Nome);
            dados.AppendFormat("Dano: {0} .",dano);

            d.Narracao += dados.ToString();
            d.DataDisputa = DateTime.Now;
            _context.Disputas.Add(d);
            _context.SaveChangesAsync(); 
            return Ok(d);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        }



        [HttpPost("Habilidade")]
        public async Task<IActionResult> AtaqueComHabilidade(Disputa d)
        {
        try
        {
            

            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
        }
    
   
    }
}