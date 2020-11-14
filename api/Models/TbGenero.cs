using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_genero")]
    public partial class TbGenero
    {
        public TbGenero()
        {
            TbLivroGenero = new HashSet<TbLivroGenero>();
        }

        [Key]
        [Column("id_genero")]
        public int IdGenero { get; set; }
        [Required]
        [Column("nm_genero", TypeName = "varchar(70)")]
        public string NmGenero { get; set; }
        [Column("ds_genero", TypeName = "varchar(200)")]
        public string DsGenero { get; set; }
        [Column("ds_foto", TypeName = "varchar(150)")]
        public string DsFoto { get; set; }

        [InverseProperty("IdGeneroNavigation")]
        public virtual ICollection<TbLivroGenero> TbLivroGenero { get; set; }
    }
}
