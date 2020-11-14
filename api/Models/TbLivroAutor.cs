using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_livro_autor")]
    public partial class TbLivroAutor
    {
        [Key]
        [Column("id_livro_autor")]
        public int IdLivroAutor { get; set; }
        [Column("id_livro")]
        public int IdLivro { get; set; }
        [Column("id_autor")]
        public int IdAutor { get; set; }

        [ForeignKey(nameof(IdAutor))]
        [InverseProperty(nameof(TbAutor.TbLivroAutor))]
        public virtual TbAutor IdAutorNavigation { get; set; }
        [ForeignKey(nameof(IdLivro))]
        [InverseProperty(nameof(TbLivro.TbLivroAutor))]
        public virtual TbLivro IdLivroNavigation { get; set; }
    }
}
