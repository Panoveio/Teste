using System;
using Microsoft.AspNetCore.Mvc;
using InteliWords_API.Domains;
using InteliWords_API.Interfaces;
using InteliWords_API.Repositories;
using Microsoft.AspNetCore.Http;
using InteliWords_API.Utils;

namespace InteliWords_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber todos os métodos definidos na interface
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto para que haja referência às implementações feitas no repositório
        /// </summary>
        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista todos o usuários
        /// </summary>
        /// <returns>Uma lista de usuários</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        /// <summary>
        /// Busca um usuário pelo seu id
        /// </summary>
        /// <param name="id">id do usuário a ser buscado</param>
        /// <returns>Um objeto usuário</returns>
        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        /// <summary>
        /// Atualiza os dados de um usuário
        /// </summary>
        /// <param name="usuario">Usuário a ser atualizado</param>
        /// <param name="arquivo">Arquivo de foto a ser upado</param>
        /// <returns>Um status code 204</returns>
        [HttpPut]
        public IActionResult Atualizar([FromForm] Usuario usuario, IFormFile arquivo)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(usuario.IdUsuario);
                if (usuarioBuscado != null)
                {
                    if (usuario != null)
                    {

                    //Upload da Imagem com extensões permitidas apenas
                    string[] p = { "jpg", "png", "jpeg" };
                    string[] extensoesPermitidas = p;
                    string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas);

                    if (uploadResultado == "")
                    {
                        return BadRequest("Arquivo não encontrado");
                    }

                    if (uploadResultado == "Extensão não permitida")
                    {
                        return BadRequest("Extensão de arquivo não permitida");
                    }

                    usuario.Foto = uploadResultado;


                    _usuarioRepository.Atualizar(usuario);
                    }

                }
                else
                {
                    return BadRequest(new { mensagem = "O usuário informado não existe" });
                }
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Torna um usuário inativo
        /// </summary>
        /// <param name="id">id do usuário a ser inativado</param>
        /// <returns>Um ok e a mensagem de usuário inativado</returns>
        [HttpPatch("desativar/{id}")]
        public IActionResult Desativar(int id)
        {
            var usuario = _usuarioRepository.BuscarPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }
            _usuarioRepository.Desativar(id);
            return Ok(new { mensagem = "Usuario desativado" });
        }

        /// <summary>
        /// Cadastra um usuário
        /// </summary>
        /// <param name="usuario">usuario a ser cadastrado</param>
        /// <returns>Um status code 201</returns>
        [HttpPost]
        public IActionResult Cadastrar(Usuario usuario)
        {
            _usuarioRepository.Cadastrar(usuario);

            return Created("Usuario", usuario);
        }
    }
}
