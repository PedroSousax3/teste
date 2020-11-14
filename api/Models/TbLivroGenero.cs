using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_livro_genero")]
    public partial class TbLivroGenero
    {
        [Key]
        [Column("id_livro_genero")]
        public int IdLivroGenero { get; set; }
        [Column("id_livro")]
        public int IdLivro { get; set; }
        [Column("id_genero")]
        public int IdGenero { get; set; }

        [ForeignKey(nameof(IdGenero))]
        [InverseProperty(nameof(TbGenero.TbLivroGenero))]
        public virtual TbGenero IdGeneroNavigation { get; set; }
        [ForeignKey(nameof(IdLivro))]
        [InverseProperty(nameof(TbLivro.TbLivroGenero))]
        public virtual TbLivro IdLivroNavigation { get; set; }
    }
}
