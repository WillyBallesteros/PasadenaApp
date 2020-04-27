using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Persistencia
{
    public partial class PasadenaAppContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public PasadenaAppContext()
        {
        }

        public PasadenaAppContext(DbContextOptions<PasadenaAppContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        public virtual DbSet<Anuncios> Anuncios { get; set; }
        public virtual DbSet<Ciudades> Ciudades { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<PuntosDeVentas> PuntosDeVentas { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesDeUsuarios> RolesDeUsuarios { get; set; }
        public virtual DbSet<TiposDeAnuncios> TiposDeAnuncios { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anuncios>(entity =>
            {
                entity.HasKey(e => e.AnuncioId)
                    .HasName("PK_Anuncio");

                entity.ToTable("Anuncios", "cart");

                entity.Property(e => e.Descripcion).HasMaxLength(1000);

                entity.Property(e => e.FechaCreacion).HasMaxLength(10);

                entity.Property(e => e.FechaFin).HasMaxLength(10);

                entity.Property(e => e.FechaInicio).HasMaxLength(10);

                entity.Property(e => e.ImagenNombre).HasMaxLength(50);

                entity.Property(e => e.Titulo).HasMaxLength(100);

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.ProductoId)
                    .HasConstraintName("FK_Anuncio_Producto");

                entity.HasOne(d => d.PuntoVenta)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.PuntoVentaId)
                    .HasConstraintName("FK_Anuncio_PuntoVenta");

                entity.HasOne(d => d.TipoAnuncio)
                    .WithMany(p => p.Anuncios)
                    .HasForeignKey(d => d.TipoAnuncioId)
                    .HasConstraintName("FK_Anuncio_TipoAnuncio");
            });

            modelBuilder.Entity<Ciudades>(entity =>
            {
                entity.HasKey(e => e.CiudadId)
                    .HasName("PK_Ciudad");

                entity.ToTable("Ciudades", "loc");

                entity.Property(e => e.CiudadNombre).HasMaxLength(100);

                entity.HasOne(d => d.Departamento)
                    .WithMany(p => p.Ciudades)
                    .HasForeignKey(d => d.DepartamentoId)
                    .HasConstraintName("FK_Ciudad_Departamento");
            });

            modelBuilder.Entity<Departamentos>(entity =>
            {
                entity.HasKey(e => e.DepartamentoId)
                    .HasName("PK_Departamento");

                entity.ToTable("Departamentos", "loc");

                entity.Property(e => e.DepartamentoNombre).HasMaxLength(100);
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.GrupoId)
                    .HasName("PK_Grupo");

                entity.ToTable("Grupos", "cart");

                entity.Property(e => e.GrupoNombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Marcas>(entity =>
            {
                entity.HasKey(e => e.MarcaId)
                    .HasName("PK_Marca");

                entity.ToTable("Marcas", "cart");

                entity.Property(e => e.MarcaNombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProductoId)
                    .HasName("PK_Producto");

                entity.ToTable("Productos", "cart");

                entity.Property(e => e.ImagenNombre).HasMaxLength(50);

                entity.Property(e => e.Plu).HasMaxLength(20);

                entity.Property(e => e.ProductoNombre).HasMaxLength(100);

                entity.HasOne(d => d.Grupo)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.GrupoId)
                    .HasConstraintName("FK_Producto_Grupo");

                entity.HasOne(d => d.Marca)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.MarcaId)
                    .HasConstraintName("FK_Producto_Marca");

                entity.HasOne(d => d.PuntoVenta)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.PuntoVentaId)
                    .HasConstraintName("FK_Producto_PuntoVenta");
            });

            modelBuilder.Entity<PuntosDeVentas>(entity =>
            {
                entity.HasKey(e => e.PuntoVentaId)
                    .HasName("PK_PuntoVenta");

                entity.ToTable("PuntosDeVentas", "loc");

                entity.HasIndex(e => e.Nit)
                    .HasName("UQ__PuntosDe__C7D1D6DA0CBAE877")
                    .IsUnique();

                entity.Property(e => e.Celular).HasMaxLength(50);

                entity.Property(e => e.Contacto).HasMaxLength(100);

                entity.Property(e => e.Direccion).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Lat).HasMaxLength(50);

                entity.Property(e => e.Logo).HasMaxLength(150);

                entity.Property(e => e.Lon).HasMaxLength(50);

                entity.Property(e => e.Nit).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.Property(e => e.Web).HasMaxLength(200);

                entity.HasOne(d => d.Ciudad)
                    .WithMany(p => p.PuntosDeVentas)
                    .HasForeignKey(d => d.CiudadId)
                    .HasConstraintName("FK_PuntoVenta_Ciudad");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RolId)
                    .HasName("PK_Rol");

                entity.ToTable("Roles", "auth");

                entity.Property(e => e.RolNombre).HasMaxLength(50);
            });

            modelBuilder.Entity<RolesDeUsuarios>(entity =>
            {
                entity.HasKey(e => new { e.UsuarioId, e.RolId })
                    .HasName("PK_UsuarioRol");

                entity.ToTable("RolesDeUsuarios", "auth");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.RolesDeUsuarios)
                    .HasForeignKey(d => d.RolId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioRol_Rol");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.RolesDeUsuarios)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuarioRol_Usuario");
            });

            modelBuilder.Entity<TiposDeAnuncios>(entity =>
            {
                entity.HasKey(e => e.TipoAnuncioId)
                    .HasName("PK_TipoAnuncio");

                entity.ToTable("TiposDeAnuncios", "cart");

                entity.Property(e => e.TipoAnuncioNombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId)
                    .HasName("PK_Usuario");

                entity.ToTable("Usuarios", "auth");

                entity.Property(e => e.Apellidos).HasMaxLength(100);

                entity.Property(e => e.Contraseña).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(80);

                entity.Property(e => e.Nombres).HasMaxLength(100);

                entity.Property(e => e.NumeroCedula).HasMaxLength(20);

                entity.Property(e => e.Telefono).HasMaxLength(50);

                entity.HasOne(d => d.Ciudad)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CiudadId)
                    .HasConstraintName("FK_Usuario_Ciudad");

                entity.HasOne(d => d.PuntoVenta)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PuntoVentaId)
                    .HasConstraintName("FK_Usuario_PuntoVenta");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}