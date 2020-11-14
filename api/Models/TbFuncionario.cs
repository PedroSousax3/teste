using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_funcionario")]
    public partial class TbFuncionario
    {
        [Key]
        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }
        [Column("id_login")]
        public int IdLogin { get; set; }
        [Required]
        [Column("nm_funcionario", TypeName = "varchar(100)")]
        public string NmFuncionario { get; set; }
        [Required]
        [Column("ds_carteira_trabalho", TypeName = "varchar(20)")]
        public string DsCarteiraTrabalho { get; set; }
        [Required]
        [Column("ds_cpf", TypeName = "varchar(20)")]
        public string DsCpf { get; set; }
        [Required]
        [Column("ds_email", TypeName = "varchar(100)")]
        public string DsEmail { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime DtNascimento { get; set; }
        [Column("dt_admissao", TypeName = "datetime")]
        public DateTime DtAdmissao { get; set; }
        [Required]
        [Column("ds_cargo", TypeName = "varchar(50)")]
        public string DsCargo { get; set; }
        [Required]
        [Column("ds_endereco", TypeName = "varchar(50)")]
        public string DsEndereco { get; set; }
        [Required]
        [Column("ds_cep", TypeName = "varchar(10)")]
        public string DsCep { get; set; }
        [Column("nr_residencial")]
        public int NrResidencial { get; set; }
        [Column("ds_complemento", TypeName = "varchar(25)")]
        public string DsComplemento { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbFuncionario))]
        public virtual TbLogin IdLoginNavigation { get; set; }
    }
}
