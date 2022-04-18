using InteliWords_API.Domains;
using System.Collections.Generic;

namespace InteliWords_API.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Login(string email, string userId);
        Usuario BuscarPorId(int idUsuario);
        void Cadastrar(Usuario novoUsuario);
        List<Usuario> Listar();
        void Atualizar(Usuario usuarioAtualizado);
        void Desativar(int idUsuario);
    }
}
