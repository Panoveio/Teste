using InteliWords_API.Domains;
using InteliWords_API.Interfaces;
using InteliWords_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InteliWords_API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PalavrasUsuariosController : ControllerBase
    {
        private IPalavrasUsuarioRepository _PalavrasUsuarioRepository { get; set; }

        public PalavrasUsuariosController()
        {
            _PalavrasUsuarioRepository = new PalavrasUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                // Retorna um status code Ok(200) e uma lista de Usuarios
                return Ok(_PalavrasUsuarioRepository.ListarTodos());
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(PalavrasUsuario palavraUsuario)
        {
            try
            {
                if (palavraUsuario.DataCriacao == null && palavraUsuario.Aprendido == null)
                {
                    palavraUsuario.DataCriacao = System.DateTime.Now;
                    palavraUsuario.Aprendido = false;
                }

                // Cadastra um novo Usuario
                _PalavrasUsuarioRepository.Cadastrar(palavraUsuario);

                // Retorna um status code Created(201)
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                // Cadastra um novo Usuario
                _PalavrasUsuarioRepository.Deletar(id);

                // Retorna um status code NoContent(204)
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }

        [HttpPut("{idPalavrasUsuario}")]
        public IActionResult Atualizar(int idPalavrasUsuario, PalavrasUsuario palavraUsuario)
        {
            try
            {
                _PalavrasUsuarioRepository.Atualizar(idPalavrasUsuario, palavraUsuario);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }

        [HttpPatch("{idConsulta}/{status}")]
        public IActionResult AtualizarStatus(int idConsulta, bool status)
        {
            try
            {
                // Atualiza a situação de uma consulta
                _PalavrasUsuarioRepository.AtualizarStatus(idConsulta, status);

                // Retorna um status code NoContent(204)
                return Ok(201);
            }
            catch (Exception erro)
            {
                // Retorna um status code BadRequest(400)
                return BadRequest(erro);
            }
        }
    }
}
