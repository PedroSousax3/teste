using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class db_next_gen_booksContext : DbContext
    {
        public db_next_gen_booksContext()
        {
        }

        public db_next_gen_booksContext(DbContextOptions<db_next_gen_booksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAutor> TbAutor { get; set; }
        public virtual DbSet<TbAvaliacaoLivro> TbAvaliacaoLivro { get; set; }
        public virtual DbSet<TbCarrinho> TbCarrinho { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbDevolucao> TbDevolucao { get; set; }
        public virtual DbSet<TbEditora> TbEditora { get; set; }
        public virtual DbSet<TbEndereco> TbEndereco { get; set; }
        public virtual DbSet<TbEstoque> TbEstoque { get; set; }
        public virtual DbSet<TbFavoritos> TbFavoritos { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionario { get; set; }
        public virtual DbSet<TbGenero> TbGenero { get; set; }
        public virtual DbSet<TbLivro> TbLivro { get; set; }
        public virtual DbSet<TbLivroAutor> TbLivroAutor { get; set; }
        public virtual DbSet<TbLivroGenero> TbLivroGenero { get; set; }
        public virtual DbSet<TbLogin> TbLogin { get; set; }
        public virtual DbSet<TbMedida> TbMedida { get; set; }
        public virtual DbSet<TbRecebimentoDevolucao> TbRecebimentoDevolucao { get; set; }
        public virtual DbSet<TbVenda> TbVenda { get; set; }
        public virtual DbSet<TbVendaLivro> TbVendaLivro { get; set; }
        public virtual DbSet<TbVendaStatus> TbVendaStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=localhost;user id=root;password=45923617xx;database=db_next_gen_books", x => x.ServerVersion("8.0.22-mysql"));
                //optionsBuilder.UseMySql("server=localhost;user id=administrador;password=5J9yGqxqt&37L97y;database=db_next_gen_books", x => x.ServerVersion("8.0.22-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAutor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsAutor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsFoto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmAutor)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbAvaliacaoLivro>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacaoLivro)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdVendaLivro)
                    .HasName("id_venda_livro_idx");

                entity.Property(e => e.DsComentario)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdVendaLivroNavigation)
                    .WithMany(p => p.TbAvaliacaoLivro)
                    .HasForeignKey(d => d.IdVendaLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_avaliacao_livro_ibfk_1");
            });

            modelBuilder.Entity<TbCarrinho>(entity =>
            {
                entity.HasKey(e => e.IdCarrinho)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente_idx");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("id_livro_idx");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbCarrinho)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_carrinho_ibfk_1");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.TbCarrinho)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_carrinho_ibfk_2");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.DsFoto)
                    .HasName("ds_foto_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdLogin)
                    .HasName("id_login_idx");

                entity.Property(e => e.DsCelular)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsFoto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCliente)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TpGenero)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbCliente)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_cliente_ibfk_1");
            });

            modelBuilder.Entity<TbDevolucao>(entity =>
            {
                entity.HasKey(e => e.IdDevolucao)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdVendaLivro)
                    .HasName("id_venda_livro");

                entity.Property(e => e.DsCodigoRastreio)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsComprovante)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsMotivo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdVendaLivroNavigation)
                    .WithMany(p => p.TbDevolucao)
                    .HasForeignKey(d => d.IdVendaLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_devolucao_ibfk_1");
            });

            modelBuilder.Entity<TbEditora>(entity =>
            {
                entity.HasKey(e => e.IdEditora)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsLogo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSigla)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmEditora)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbEndereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente_idx");

                entity.Property(e => e.DsCelular)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCep)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsComplemento)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEndereco)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmCidade)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmEndereco)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmEstado)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbEndereco)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_endereco_ibfk_1");
            });

            modelBuilder.Entity<TbEstoque>(entity =>
            {
                entity.HasKey(e => e.IdEstoque)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("id_livro_idx");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.TbEstoque)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_estoque_ibfk_1");
            });

            modelBuilder.Entity<TbFavoritos>(entity =>
            {
                entity.HasKey(e => e.IdFavoritos)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente_idx");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("id_livro");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbFavoritos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_favoritos_ibfk_1");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.TbFavoritos)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_favoritos_ibfk_2");
            });

            modelBuilder.Entity<TbFuncionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("fk_tb_funcionario_tb_login1_idx");

                entity.Property(e => e.DsCargo)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCarteiraTrabalho)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCep)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsComplemento)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsEndereco)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmFuncionario)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbFuncionario)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_funcionario_ibfk_1");
            });

            modelBuilder.Entity<TbGenero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsFoto)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsGenero)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmGenero)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbLivro>(entity =>
            {
                entity.HasKey(e => e.IdLivro)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.DsCapa)
                    .HasName("ds_capa_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdEditora)
                    .HasName("id_editora_idx");

                entity.HasIndex(e => e.IdMedida)
                    .HasName("fk_tb_livro_tb_medidas1_idx");

                entity.Property(e => e.DsCapa)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsIdioma)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsIsbn)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsLivro)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmLivro)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TpAcabamento)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdEditoraNavigation)
                    .WithMany(p => p.TbLivro)
                    .HasForeignKey(d => d.IdEditora)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_livro_ibfk_1");

                entity.HasOne(d => d.IdMedidaNavigation)
                    .WithMany(p => p.TbLivro)
                    .HasForeignKey(d => d.IdMedida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_livro_ibfk_2");
            });

            modelBuilder.Entity<TbLivroAutor>(entity =>
            {
                entity.HasKey(e => e.IdLivroAutor)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdAutor)
                    .HasName("id_autor_idx");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("id_livro_idx");

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.TbLivroAutor)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_livro_autor_ibfk_2");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.TbLivroAutor)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_livro_autor_ibfk_1");
            });

            modelBuilder.Entity<TbLivroGenero>(entity =>
            {
                entity.HasKey(e => e.IdLivroGenero)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdGenero)
                    .HasName("id_genero_idx");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("id_livro_idx");

                entity.HasOne(d => d.IdGeneroNavigation)
                    .WithMany(p => p.TbLivroGenero)
                    .HasForeignKey(d => d.IdGenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_livro_genero_ibfk_2");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.TbLivroGenero)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_livro_genero_ibfk_1");
            });

            modelBuilder.Entity<TbLogin>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsCodigoVerificacao)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsSenha)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmUsuario)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<TbMedida>(entity =>
            {
                entity.HasKey(e => e.IdMedida)
                    .HasName("PRIMARY");
            });

            modelBuilder.Entity<TbRecebimentoDevolucao>(entity =>
            {
                entity.HasKey(e => e.IdLivroDevolvido)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdDevolucao)
                    .HasName("id_devolucao_idx");

                entity.Property(e => e.DsStatusLivro)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdDevolucaoNavigation)
                    .WithMany(p => p.TbRecebimentoDevolucao)
                    .HasForeignKey(d => d.IdDevolucao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_recebimento_devolucao_ibfk_1");
            });

            modelBuilder.Entity<TbVenda>(entity =>
            {
                entity.HasKey(e => e.IdVenda)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente_idx");

                entity.HasIndex(e => e.IdEndereco)
                    .HasName("id_endereco_idx");

                entity.Property(e => e.DsCodigoRastreio)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsNf)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DsStatusPagamento)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.TpPagamento)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbVenda)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_venda_ibfk_1");

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.TbVenda)
                    .HasForeignKey(d => d.IdEndereco)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_venda_ibfk_2");
            });

            modelBuilder.Entity<TbVendaLivro>(entity =>
            {
                entity.HasKey(e => e.IdVendaLivro)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLivro)
                    .HasName("id_livro_idx");

                entity.HasIndex(e => e.IdVenda)
                    .HasName("id_venda_idx");

                entity.HasOne(d => d.IdLivroNavigation)
                    .WithMany(p => p.TbVendaLivro)
                    .HasForeignKey(d => d.IdLivro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_venda_livro_ibfk_2");

                entity.HasOne(d => d.IdVendaNavigation)
                    .WithMany(p => p.TbVendaLivro)
                    .HasForeignKey(d => d.IdVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_venda_livro_ibfk_1");
            });

            modelBuilder.Entity<TbVendaStatus>(entity =>
            {
                entity.HasKey(e => e.IdVendaStatus)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdVenda)
                    .HasName("id_venda_idx");

                entity.Property(e => e.DsVendaStatus)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.NmStatus)
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.IdVendaNavigation)
                    .WithMany(p => p.TbVendaStatus)
                    .HasForeignKey(d => d.IdVenda)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("tb_venda_status_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
