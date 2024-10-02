using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChurrascoController : ControllerBase
    {
        private readonly IChurrascoRepository _churrascoRepository;

        public ChurrascoController(IChurrascoRepository churrascoRepository)
        {
            _churrascoRepository = churrascoRepository;
        }

        [HttpPost]
        public IActionResult AdicionarParticipante([FromBody] Participante participante)
        {

            if (string.IsNullOrWhiteSpace(participante.Nome) || participante.Nome.Length < 3 || participante.Nome.Length > 255)
            {
                return BadRequest("Seu nome esta inválido.");
            }

            if (string.IsNullOrWhiteSpace(participante.Carne))
            {
                return BadRequest("Descrição da carne é obrigatória.");
            }

            if (participante.Idade >= 18)
            {
                return BadRequest("Não serão permitidos maiores de 18 anos.");
            }

            if (string.IsNullOrWhiteSpace(participante.Bebida))
            {
                return BadRequest("Descreva sua bebida que ira tomar");
            }

            _churrascoRepository.AdicionarParticipante(participante);
            return Ok("Participante adicionado parabens.");
        }

        [HttpGet]
        public IActionResult ListarParticipantes()
        {
            var participantes = _churrascoRepository.ListarParticipantes();
            return Ok(participantes);
        }
    }
}