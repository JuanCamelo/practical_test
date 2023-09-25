using Microsoft.EntityFrameworkCore;
using POO.Infraestructure.Entities;

namespace POO.Infraestructure.Context;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
    public virtual DbSet<VistaCantidadProyectosDepartamento> VistaCantidadProyectosDepartamentos { get; set; }

    public virtual DbSet<VistaDepartamentosProyecto> VistaDepartamentosProyectos { get; set; }

    public virtual DbSet<VistaEmpleadoAsignadosProyecto> VistaEmpleadoAsignadosProyectos { get; set; }

    public virtual DbSet<VistaInformacionProyectosDepartamento> VistaInformacionProyectosDepartamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        modelBuilder.Entity<VistaCantidadProyectosDepartamento>(entity =>
        {
            entity.HasNoKey()
                .ToTable("vista_cantidadProyectosDepartamento");

            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VistaDepartamentosProyecto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vista_departamentosProyecto");

            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VistaEmpleadoAsignadosProyecto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vista_empleadoAsignadosProyecto");

            entity.Property(e => e.EmployeeName)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Project)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VistaInformacionProyectosDepartamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vista_informacionProyectosDepartamento");

            entity.Property(e => e.Budget).HasColumnName("budget");
            entity.Property(e => e.Department)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EndDate)
                .HasColumnType("date")
                .HasColumnName("end_date");
            entity.Property(e => e.Project)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StartDate)
                .HasColumnType("date")
                .HasColumnName("start_date");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
