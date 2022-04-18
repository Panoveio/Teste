using InteliWords_API.Contexts;
using InteliWords_API.Domains;
using InteliWords_API.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InteliWords_API.Repositories
{
    public class PalavrasUsuarioRepository : IPalavrasUsuarioRepository
    {
        InteliWordsContext ctx = new InteliWordsContext();

        public void Atualizar(int id, PalavrasUsuario palavrasUsuarioAtualizada)
        {
            PalavrasUsuario palavraUsuario = BuscarPorId(id);

            if (palavrasUsuarioAtualizada.IdCategoria != null && palavrasUsuarioAtualizada.TituloPalavra != null)
            {
                palavraUsuario.IdCategoria = palavrasUsuarioAtualizada.IdCategoria;
                palavraUsuario.TituloPalavra = palavrasUsuarioAtualizada.TituloPalavra;
                palavraUsuario.Definicao = palavrasUsuarioAtualizada.Definicao;
                palavraUsuario.Descricao = palavrasUsuarioAtualizada.Descricao;
            }

            ctx.PalavrasUsuarios.Update(palavraUsuario);

            ctx.SaveChanges();
        }

        public void AtualizarStatus(int idPalavraUsuario, bool status)
        {
            PalavrasUsuario palavraUsuario = BuscarPorId(idPalavraUsuario);

            if (palavraUsuario != null)
            {
                switch (status)
                {
                    case true:
                        palavraUsuario.Aprendido = true;
                        break;

                    case false:
                        palavraUsuario.Aprendido = false;
                        break;
                }

                ctx.PalavrasUsuarios.Update(palavraUsuario);

                ctx.SaveChanges();
            }
        }

        public PalavrasUsuario BuscarPorId(int id)
        {
            return ctx.PalavrasUsuarios.Find(id);
        }

        public void Cadastrar(PalavrasUsuario palavraUsuario)
        {
            ctx.PalavrasUsuarios.Add(palavraUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            PalavrasUsuario palavraUsuario = BuscarPorId(id);

            ctx.PalavrasUsuarios.Remove(palavraUsuario);

            ctx.SaveChanges();
        }

        public List<PalavrasUsuario> ListarTodos()
        {
            return ctx.PalavrasUsuarios.ToList();
        }
    }
}
