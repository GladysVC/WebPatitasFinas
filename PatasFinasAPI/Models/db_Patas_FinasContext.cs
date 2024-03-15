using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PatasFinasAPI.Models
{
    public partial class db_Patas_FinasContext : DbContext
    {
        public db_Patas_FinasContext()
        {
        }

        public db_Patas_FinasContext(DbContextOptions<db_Patas_FinasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         /*   if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-EH6UJG78\\SQLEXPRESS;Initial Catalog=db_Patas_Finas;Integrated Security=SSPI; User=sa;Password=123;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__02AA078553EEEC3C");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");

                entity.Property(e => e.NombreCategoria)
                    .HasMaxLength(50)
                    .HasColumnName("Nombre_Categoria");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__9B4120E2BE6DCF56");

                entity.Property(e => e.IdProducto).HasColumnName("ID_Producto");

                entity.Property(e => e.IdCategoria).HasColumnName("ID_Categoria");

                entity.Property(e => e.Imagen).HasColumnName("imagen");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(100)
                    .HasColumnName("Nombre_Producto");

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.objCategoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Productos__ID_Ca__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
