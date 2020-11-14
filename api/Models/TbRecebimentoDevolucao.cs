using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_recebimento_devolucao")]
    public partial class TbRecebimentoDevolucao
    {
        [Key]
        [Column("id_livro_devolvido")]
        public int IdLivroDevolvido { get; set; }
        [Column("id_devolucao")]
        public int IdDevolucao { get; set; }
        [Column("dt_recebimento_livro", TypeName = "datetime")]
        public DateTime DtRecebimentoLivro { get; set; }
        [Required]
        [Column("ds_status_livro", TypeName = "varchar(1000)")]
        public string DsStatusLivro { get; set; }

        [ForeignKey(nameof(IdDevolucao))]
        [InverseProperty(nameof(TbDevolucao.TbRecebimentoDevolucao))]
        public virtual TbDevolucao IdDevolucaoNavigation { get; set; }
    }
}
