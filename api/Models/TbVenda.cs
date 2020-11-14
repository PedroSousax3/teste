using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_venda")]
    public partial class TbVenda
    {
        public TbVenda()
        {
            TbVendaLivro = new HashSet<TbVendaLivro>();
            TbVendaStatus = new HashSet<TbVendaStatus>();
        }

        [Key]
        [Column("id_venda")]
        public int IdVenda { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("id_endereco")]
        public int IdEndereco { get; set; }
        [Required]
        [Column("tp_pagamento", TypeName = "varchar(50)")]
        public string TpPagamento { get; set; }
        [Column("nr_parcela")]
        public int? NrParcela { get; set; }
        [Required]
        [Column("ds_status_pagamento", TypeName = "varchar(100)")]
        public string DsStatusPagamento { get; set; }
        [Column("dt_venda", TypeName = "datetime")]
        public DateTime? DtVenda { get; set; }
        [Column("vl_frete", TypeName = "decimal(10,5)")]
        public decimal? VlFrete { get; set; }
        [Column("ds_codigo_rastreio", TypeName = "varchar(40)")]
        public string DsCodigoRastreio { get; set; }
        [Column("dt_prevista_entrega", TypeName = "datetime")]
        public DateTime? DtPrevistaEntrega { get; set; }
        [Column("bt_confirmacao_entrega")]
        public sbyte? BtConfirmacaoEntrega { get; set; }
        [Required]
        [Column("ds_nf", TypeName = "varchar(150)")]
        public string DsNf { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbVenda))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdEndereco))]
        [InverseProperty(nameof(TbEndereco.TbVenda))]
        public virtual TbEndereco IdEnderecoNavigation { get; set; }
        [InverseProperty("IdVendaNavigation")]
        public virtual ICollection<TbVendaLivro> TbVendaLivro { get; set; }
        [InverseProperty("IdVendaNavigation")]
        public virtual ICollection<TbVendaStatus> TbVendaStatus { get; set; }
    }
}
