using InteliWords_API.Contexts;
using InteliWords_API.Domains;
using InteliWords_API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InteliWords_API.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {

        private readonly InteliWordsContext ctx;

        public CategoriaRepository(InteliWordsContext appContext)
        {
            ctx = appContext;
        }

        public void Atualizar(Categoria categoriaAtualizada)
        {
           
        }

        public void Atualizar(int IdCategoria, Categoria categoriaAtualizada)
        {
            Categoria categoriaBuscada = BuscarPorID(IdCategoria);

            if (categoriaBuscada.IdCategoria != 0)
            {
                categoriaBuscada.TituloCategoria = categoriaAtualizada.TituloCategoria;

                ctx.Categoria.Update(categoriaBuscada);

                ctx.SaveChanges();
            }
        }

        public Categoria BuscarPorID(int idCategoria)
        {
            return ctx.Categoria.Find(idCategoria);
        }

        public void Cadastrar(Categoria novaCategoria)
        {
            ctx.Categoria.Add(novaCategoria);
            ctx.SaveChangesAsync();
        }

        public void Deletar(Categoria categoria)
        {
            ctx.Categoria.Remove(categoria);
            ctx.SaveChangesAsync();
        }

        public List<Categoria> ListarTodos()
        {
            return ctx.Categoria.ToList();
        }
    }
}
