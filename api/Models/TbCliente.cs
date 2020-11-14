using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_cliente")]
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbCarrinho = new HashSet<TbCarrinho>();
            TbEndereco = new HashSet<TbEndereco>();
            TbFavoritos = new HashSet<TbFavoritos>();
            TbVenda = new HashSet<TbVenda>();
        }

        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("id_login")]
        public int IdLogin { get; set; }
        [Required]
        [Column("nm_cliente", TypeName = "varchar(100)")]
        public string NmCliente { get; set; }
        [Required]
        [Column("ds_cpf", TypeName = "varchar(20)")]
        public string DsCpf { get; set; }
        [Required]
        [Column("ds_email", TypeName = "varchar(45)")]
        public string DsEmail { get; set; }
        [Column("ds_celular", TypeName = "varchar(20)")]
        public string DsCelular { get; set; }
        [Column("ds_foto", TypeName = "varchar(150)")]
        public string DsFoto { get; set; }
        [Column("tp_genero", TypeName = "varchar(50)")]
        public string TpGenero { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime DtNascimento { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbCliente))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbCarrinho> TbCarrinho { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbEndereco> TbEndereco { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbFavoritos> TbFavoritos { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbVenda> TbVenda { get; set; }
    }
}
