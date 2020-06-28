using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apifilmes.Models
{
    public partial class apidbContext : DbContext
    {
        public apidbContext()
        {
        }

        public apidbContext(DbContextOptions<apidbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbFilme> TbFilme { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=apidb", x => x.ServerVersion("5.6.6-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbFilme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsGenero)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmFilme)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
