using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_favoritos")]
    public partial class TbFavoritos
    {
        [Key]
        [Column("id_favoritos")]
        public int IdFavoritos { get; set; }
        [Column("id_livro")]
        public int IdLivro { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("dt_inclusao", TypeName = "datetime")]
        public DateTime DtInclusao { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbFavoritos))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdLivro))]
        [InverseProperty(nameof(TbLivro.TbFavoritos))]
        public virtual TbLivro IdLivroNavigation { get; set; }
    }
}
