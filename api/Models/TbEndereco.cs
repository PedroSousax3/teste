using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_endereco")]
    public partial class TbEndereco
    {
        public TbEndereco()
        {
            TbVenda = new HashSet<TbVenda>();
        }

        [Key]
        [Column("id_endereco")]
        public int IdEndereco { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Required]
        [Column("nm_endereco", TypeName = "varchar(50)")]
        public string NmEndereco { get; set; }
        [Required]
        [Column("ds_endereco", TypeName = "varchar(70)")]
        public string DsEndereco { get; set; }
        [Required]
        [Column("ds_cep", TypeName = "varchar(10)")]
        public string DsCep { get; set; }
        [Required]
        [Column("nm_cidade", TypeName = "varchar(50)")]
        public string NmCidade { get; set; }
        [Required]
        [Column("nm_estado", TypeName = "varchar(45)")]
        public string NmEstado { get; set; }
        [Column("nr_endereco")]
        public int NrEndereco { get; set; }
        [Column("ds_complemento", TypeName = "varchar(35)")]
        public string DsComplemento { get; set; }
        [Column("ds_celular", TypeName = "varchar(20)")]
        public string DsCelular { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbEndereco))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [InverseProperty("IdEnderecoNavigation")]
        public virtual ICollection<TbVenda> TbVenda { get; set; }
    }
}
