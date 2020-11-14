using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_medida")]
    public partial class TbMedida
    {
        public TbMedida()
        {
            TbLivro = new HashSet<TbLivro>();
        }

        [Key]
        [Column("id_medida")]
        public int IdMedida { get; set; }
        [Column("vl_altura", TypeName = "decimal(10,5)")]
        public decimal VlAltura { get; set; }
        [Column("vl_largura", TypeName = "decimal(10,5)")]
        public decimal VlLargura { get; set; }
        [Column("vl_profundidades", TypeName = "decimal(10,5)")]
        public decimal VlProfundidades { get; set; }
        [Column("vl_peso", TypeName = "decimal(10,5)")]
        public decimal VlPeso { get; set; }

        [InverseProperty("IdMedidaNavigation")]
        public virtual ICollection<TbLivro> TbLivro { get; set; }
    }
}
