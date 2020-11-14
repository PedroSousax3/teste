using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_venda_status")]
    public partial class TbVendaStatus
    {
        [Key]
        [Column("id_venda_status")]
        public int IdVendaStatus { get; set; }
        [Column("id_venda")]
        public int IdVenda { get; set; }
        [Required]
        [Column("nm_status", TypeName = "varchar(70)")]
        public string NmStatus { get; set; }
        [Column("ds_venda_status", TypeName = "varchar(200)")]
        public string DsVendaStatus { get; set; }
        [Column("dt_atualizacao", TypeName = "datetime")]
        public DateTime DtAtualizacao { get; set; }

        [ForeignKey(nameof(IdVenda))]
        [InverseProperty(nameof(TbVenda.TbVendaStatus))]
        public virtual TbVenda IdVendaNavigation { get; set; }
    }
}
