using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InteliWords_API.Domains;

#nullable disable

namespace InteliWords_API.Contexts
{
    public partial class InteliWordsContext : DbContext
    {
        public InteliWordsContext()
        {
        }

        public InteliWordsContext(DbContextOptions<InteliWordsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<PalavrasUsuario> PalavrasUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=inteliwords.database.windows.net; initial catalog=inteliwordsDB; user Id=UserAdmin; pwd=oP09%8yw#t;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240CEB16FF9A");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.TituloCategoria)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tituloCategoria");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Categoria)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Categoria__idUsu__60A75C0F");
            });

            modelBuilder.Entity<PalavrasUsuario>(entity =>
            {
                entity.HasKey(e => e.IdPalavrasUsuario)
                    .HasName("PK__Palavras__319692E7F4992873");

                entity.ToTable("PalavrasUsuario");

                entity.Property(e => e.IdPalavrasUsuario).HasColumnName("idPalavrasUsuario");

                entity.Property(e => e.Aprendido)
                    .HasColumnName("aprendido")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.Definicao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("definicao");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.TituloPalavra)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("tituloPalavra");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.PalavrasUsuarios)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__PalavrasU__idCat__6754599E");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__645723A616C1C8E6");

                entity.ToTable("Usuario");

                entity.HasIndex(e => e.Email, "UQ__Usuario__AB6E61646EE5A1C5")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "UQ__Usuario__CB9A1CFEC45E2AF2")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Ativado).HasColumnName("ativado");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Foto)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("foto");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
