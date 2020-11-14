using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_login")]
    public partial class TbLogin
    {
        public TbLogin()
        {
            TbCliente = new HashSet<TbCliente>();
            TbFuncionario = new HashSet<TbFuncionario>();
        }

        [Key]
        [Column("id_login")]
        public int IdLogin { get; set; }
        [Required]
        [Column("nm_usuario", TypeName = "varchar(50)")]
        public string NmUsuario { get; set; }
        [Required]
        [Column("ds_senha", TypeName = "varchar(64)")]
        public string DsSenha { get; set; }
        [Column("dt_ultimo_login", TypeName = "datetime")]
        public DateTime DtUltimoLogin { get; set; }
        [Column("ds_codigo_verificacao", TypeName = "varchar(15)")]
        public string DsCodigoVerificacao { get; set; }
        [Column("dt_codigo_verificacao", TypeName = "datetime")]
        public DateTime? DtCodigoVerificacao { get; set; }

        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbCliente> TbCliente { get; set; }
        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbFuncionario> TbFuncionario { get; set; }
    }
}
