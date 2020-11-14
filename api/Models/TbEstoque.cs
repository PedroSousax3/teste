using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_estoque")]
    public partial class TbEstoque
    {
        [Key]
        [Column("id_estoque")]
        public int IdEstoque { get; set; }
        [Column("id_livro")]
        public int IdLivro { get; set; }
        [Column("nr_quantidade")]
        public int NrQuantidade { get; set; }
        [Column("dt_atualizacao", TypeName = "datetime")]
        public DateTime DtAtualizacao { get; set; }

        [ForeignKey(nameof(IdLivro))]
        [InverseProperty(nameof(TbLivro.TbEstoque))]
        public virtual TbLivro IdLivroNavigation { get; set; }
    }
}
