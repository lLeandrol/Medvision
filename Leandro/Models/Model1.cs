using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Leandro.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=ModelMedVision")
        {
        }

        public virtual DbSet<Citas> Citas { get; set; }
        public virtual DbSet<MotivoDeCita> MotivoDeCita { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>()
                .Property(e => e.TipoCita)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .Property(e => e.NivelUrgencia)
                .IsUnicode(false);

            modelBuilder.Entity<Citas>()
                .HasMany(e => e.MotivoDeCita)
                .WithMany(e => e.Citas)
                .Map(m => m.ToTable("Motivos").MapLeftKey("IdCita").MapRightKey("IdMotivoCita"));

            modelBuilder.Entity<MotivoDeCita>()
                .Property(e => e.EstadoPaciente)
                .IsUnicode(false);

            modelBuilder.Entity<MotivoDeCita>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Pacientes>()
                .HasMany(e => e.Citas)
                .WithRequired(e => e.Pacientes)
                .HasForeignKey(e => e.IdPersona)
                .WillCascadeOnDelete(false);
        }
    }
}
