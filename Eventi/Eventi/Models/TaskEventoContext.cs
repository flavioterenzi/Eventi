using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Eventi.Models;

public partial class TaskEventoContext : DbContext
{
    public TaskEventoContext()
    {
    }

    public TaskEventoContext(DbContextOptions<TaskEventoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contiene> Contienes { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<Partecipante> Partecipantes { get; set; }

    public virtual DbSet<Risorsa> Risorsas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ACADEMY2024-07\\SQLEXPRESS;Database=Task_Evento;User Id=accademy;Password=accademy!;MultipleActiveResultSets=true;Encrypt=false;TrustServerCertificate=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contiene>(entity =>
        {
            entity.HasKey(e => e.ContieneId).HasName("PK__Contiene__9BD6A3737D62725B");

            entity.ToTable("Contiene");

            entity.Property(e => e.ContieneId).HasColumnName("contieneId");
            entity.Property(e => e.EventiRif).HasColumnName("eventiRIf");
            entity.Property(e => e.PartecipanteRif).HasColumnName("partecipanteRif");

            entity.HasOne(d => d.EventiRifNavigation).WithMany(p => p.Contienes)
                .HasForeignKey(d => d.EventiRif)
                .HasConstraintName("FK__Contiene__eventi__3D5E1FD2");

            entity.HasOne(d => d.PartecipanteRifNavigation).WithMany(p => p.Contienes)
                .HasForeignKey(d => d.PartecipanteRif)
                .HasConstraintName("FK__Contiene__partec__3C69FB99");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EventiId).HasName("PK__Evento__27D94A050A17B396");

            entity.ToTable("Evento");

            entity.Property(e => e.EventiId).HasColumnName("eventiID");
            entity.Property(e => e.CapacitaMassima).HasColumnName("capacita_Massima");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Descrizione)
                .HasColumnType("text")
                .HasColumnName("descrizione");
            entity.Property(e => e.Luogo)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("luogo");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Partecipante>(entity =>
        {
            entity.HasKey(e => e.PartecipanteId).HasName("PK__Partecip__59BAFC6EB12F68F5");

            entity.ToTable("Partecipante");

            entity.HasIndex(e => e.Contatto, "UQ__Partecip__83808B603F6FBFEE").IsUnique();

            entity.Property(e => e.PartecipanteId).HasColumnName("partecipanteId");
            entity.Property(e => e.Contatto)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("contatto");
            entity.Property(e => e.Nome)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("nome");
        });

        modelBuilder.Entity<Risorsa>(entity =>
        {
            entity.HasKey(e => e.RisorsaId).HasName("PK__Risorsa__31473CB941B2DE1C");

            entity.ToTable("Risorsa");

            entity.Property(e => e.RisorsaId).HasColumnName("risorsaId");
            entity.Property(e => e.Costo).HasColumnName("costo");
            entity.Property(e => e.EventoRif).HasColumnName("eventoRif");
            entity.Property(e => e.Fornitore)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("fornitore");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EventoRifNavigation).WithMany(p => p.Risorsas)
                .HasForeignKey(d => d.EventoRif)
                .HasConstraintName("FK__Risorsa__eventoR__412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
