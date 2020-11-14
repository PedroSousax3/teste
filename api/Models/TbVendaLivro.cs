using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_venda_livro")]
    public partial class TbVendaLivro
    {
        public TbVendaLivro()
        {
            TbAvaliacaoLivro = new HashSet<TbAvaliacaoLivro>();
            TbDevolucao = new HashSet<TbDevolucao>();
        }

        [Key]
        [Column("id_venda_livro")]
        public int IdVendaLivro { get; set; }
        [Column("id_venda")]
        public int IdVenda { get; set; }
        [Column("id_livro")]
        public int IdLivro { get; set; }
        [Column("nr_livros")]
        public int NrLivros { get; set; }
        [Column("vl_venda_livro", TypeName = "decimal(10,5)")]
        public decimal VlVendaLivro { get; set; }
        [Column("bt_devolvido")]
        public sbyte? BtDevolvido { get; set; }

        [ForeignKey(nameof(IdLivro))]
        [InverseProperty(nameof(TbLivro.TbVendaLivro))]
        public virtual TbLivro IdLivroNavigation { get; set; }
        [ForeignKey(nameof(IdVenda))]
        [InverseProperty(nameof(TbVenda.TbVendaLivro))]
        public virtual TbVenda IdVendaNavigation { get; set; }
        [InverseProperty("IdVendaLivroNavigation")]
        public virtual ICollection<TbAvaliacaoLivro> TbAvaliacaoLivro { get; set; }
        [InverseProperty("IdVendaLivroNavigation")]
        public virtual ICollection<TbDevolucao> TbDevolucao { get; set; }
    }
}
