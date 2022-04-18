using InteliWords_API.Contexts;
using InteliWords_API.Domains;
using InteliWords_API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InteliWords_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        InteliWordsContext ctx = new InteliWordsContext();
        public void Atualizar(Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(usuarioAtualizado.IdUsuario);

            if (usuarioAtualizado.Nome != null)
            {
                usuarioBuscado.Nome = usuarioAtualizado.Nome;
            }

            if (usuarioAtualizado.Foto != null)
            {
                usuarioBuscado.Foto = usuarioAtualizado.Foto;
            }


            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        public void Desativar(int idUsuario)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            usuarioBuscado.Ativado = false;

            ctx.Usuarios.Update(usuarioBuscado);

            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        public Usuario Login(string email, string userId)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.UserId == userId);
        }
    }
}
