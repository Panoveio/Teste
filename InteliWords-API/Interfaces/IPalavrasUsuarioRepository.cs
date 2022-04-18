using InteliWords_API.Domains;
using System.Collections.Generic;

namespace InteliWords_API.Interfaces
{
    public interface IPalavrasUsuarioRepository
    {
        List<PalavrasUsuario> ListarTodos();

        PalavrasUsuario BuscarPorId(int id);

        void Cadastrar(PalavrasUsuario palavraUsuario);

        void Atualizar(int id, PalavrasUsuario palavrasUsuarioAtualizada);

        void AtualizarStatus(int idPalavraUsuario, bool status);

        void Deletar(int id);

    }
}
