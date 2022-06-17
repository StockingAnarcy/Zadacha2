using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Zadacha2
{
    public partial class goslingreestrContext : DbContext
    {
        public goslingreestrContext()
        {
        }

        public goslingreestrContext(DbContextOptions<goslingreestrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Datum> Data { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=E:\\VSProjects\\Zadacha2\\goslingreestr.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datum>(entity =>
            {
                entity.ToTable("data");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AccNum).HasColumnName("Acc_num");

                entity.Property(e => e.SoderzhOper).HasColumnName("Soderzh_oper");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
