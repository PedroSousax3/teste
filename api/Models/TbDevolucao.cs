using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_devolucao")]
    public partial class TbDevolucao
    {
        public TbDevolucao()
        {
            TbRecebimentoDevolucao = new HashSet<TbRecebimentoDevolucao>();
        }

        [Key]
        [Column("id_devolucao")]
        public int IdDevolucao { get; set; }
        [Column("id_venda_livro")]
        public int IdVendaLivro { get; set; }
        [Required]
        [Column("ds_motivo", TypeName = "varchar(1000)")]
        public string DsMotivo { get; set; }
        [Column("vl_devolvido", TypeName = "decimal(10,5)")]
        public decimal VlDevolvido { get; set; }
        [Column("dt_devolucao", TypeName = "datetime")]
        public DateTime DtDevolucao { get; set; }
        [Column("ds_codigo_rastreio", TypeName = "varchar(50)")]
        public string DsCodigoRastreio { get; set; }
        [Column("ds_comprovante", TypeName = "varchar(150)")]
        public string DsComprovante { get; set; }
        [Column("dt_previsao_entrega", TypeName = "datetime")]
        public DateTime? DtPrevisaoEntrega { get; set; }
        [Column("bt_devolvido")]
        public sbyte? BtDevolvido { get; set; }

        [ForeignKey(nameof(IdVendaLivro))]
        [InverseProperty(nameof(TbVendaLivro.TbDevolucao))]
        public virtual TbVendaLivro IdVendaLivroNavigation { get; set; }
        [InverseProperty("IdDevolucaoNavigation")]
        public virtual ICollection<TbRecebimentoDevolucao> TbRecebimentoDevolucao { get; set; }
    }
}
