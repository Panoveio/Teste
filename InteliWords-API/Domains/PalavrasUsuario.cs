using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace InteliWords_API.Domains
{
    public partial class PalavrasUsuario
    {
        public int IdPalavrasUsuario { get; set; }
        public int? IdCategoria { get; set; }
        [Required]
        public string TituloPalavra { get; set; }
        public string Definicao { get; set; }
        public string Descricao { get; set; }
        public bool? Aprendido { get; set; }
        public DateTime? DataCriacao { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
    }
}
