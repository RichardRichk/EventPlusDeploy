using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.ContentModerator;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using webapi.event_.Domains;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {

        ComentariosEventoRepository Comentario = new ComentariosEventoRepository();

        //Armazena dados do servico da API externa(IA - Azure)
        private readonly ContentModeratorClient _contentModeratorClient;

        /// <summary>
        /// Construtor que recebe os dados necessarios para acesso ao servico externo
        /// </summary>
        /// <param name="contentModeratorClient">objeto do tipo ContentModeratorClient</param>
        public ComentariosEventoController(ContentModeratorClient contentModeratorClient)
        {
            _contentModeratorClient = contentModeratorClient;
        }


        [HttpPost("ComentarioIA")]
        public async Task<IActionResult> PostIA(ComentariosEvento novoComentario)
        {
            try
            {
                if (string.IsNullOrEmpty(novoComentario.Descricao))
                {
                    return BadRequest("A descricao do comentario nao deve estar vazia");
                }

                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(novoComentario.Descricao));

                var moderationResult = await _contentModeratorClient.TextModeration
                    .ScreenTextAsync("text/plain", stream, "por", false, false, null, true);

                if (moderationResult.Terms != null)
                {
                    novoComentario.Exibe = false;

                    Comentario.Cadastrar(novoComentario);
                }
                else
                {
                    novoComentario.Exibe = true;

                    Comentario.Cadastrar(novoComentario);
                }

                return StatusCode(201, novoComentario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("ListarSomenteExibe")]
        public IActionResult GetShow()
        {
            try
            {
                return Ok(Comentario.ListarSomenteExibe());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(Comentario.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByIdUser(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(Comentario.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }


        }

        [HttpPost]
        public IActionResult Post(ComentariosEvento Newcomentario)
        {
            try
            {
                Comentario.Cadastrar(Newcomentario);

                return StatusCode(201);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult delete(Guid id)
        {
            try
            {
                Comentario.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

    }
}
