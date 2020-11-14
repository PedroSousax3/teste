using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_autor")]
    public partial class TbAutor
    {
        public TbAutor()
        {
            TbLivroAutor = new HashSet<TbLivroAutor>();
        }

        [Key]
        [Column("id_autor")]
        public int IdAutor { get; set; }
        [Required]
        [Column("nm_autor", TypeName = "varchar(100)")]
        public string NmAutor { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime DtNascimento { get; set; }
        [Column("ds_autor", TypeName = "varchar(500)")]
        public string DsAutor { get; set; }
        [Column("ds_foto", TypeName = "varchar(150)")]
        public string DsFoto { get; set; }

        [InverseProperty("IdAutorNavigation")]
        public virtual ICollection<TbLivroAutor> TbLivroAutor { get; set; }
    }
}
