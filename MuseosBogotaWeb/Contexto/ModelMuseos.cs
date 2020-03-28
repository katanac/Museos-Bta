namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelMuseos : DbContext
    {
        public ModelMuseos()
            : base("name=ModelMuseos")
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Boleta> Boleta { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Museo> Museo { get; set; }
        public virtual DbSet<Reservas> Reservas { get; set; }
        public virtual DbSet<TipoBoleta> TipoBoleta { get; set; }
        public virtual DbSet<TipoEvento> TipoEvento { get; set; }
        public virtual DbSet<TipoPago> TipoPago { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>()
                .Property(e => e.NombreAddministrador)
                .IsUnicode(false);

            modelBuilder.Entity<Boleta>()
                .Property(e => e.NombreBoleta)
                .IsUnicode(false);

            modelBuilder.Entity<Detalle>()
                .Property(e => e.DescripcionCompra)
                .IsUnicode(false);

            modelBuilder.Entity<Evento>()
                .Property(e => e.NombreEvento)
                .IsUnicode(false);

            modelBuilder.Entity<Museo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Museo>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoBoleta>()
                .Property(e => e.NombreTipoEvento)
                .IsUnicode(false);

            modelBuilder.Entity<TipoEvento>()
                .Property(e => e.NombreTipoEvento)
                .IsUnicode(false);

            modelBuilder.Entity<TipoEvento>()
                .HasMany(e => e.Reservas)
                .WithOptional(e => e.TipoEvento)
                .HasForeignKey(e => e.IdEvento);

            modelBuilder.Entity<TipoPago>()
                .Property(e => e.NombreTipoPago)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.contraseña)
                .IsUnicode(false);

    
        }
    }
}
