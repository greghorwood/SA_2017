using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AsynchFoundation.Models
{
    public partial class SA_2017Context : DbContext
    {
        public virtual DbSet<StudentAddresses2017> StudentAddresses2017 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=shsqldev01;Integrated Security=SSPI;Database=SA_2017");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentAddresses2017>(entity =>
            {
                entity.HasKey(e => e.StudentDetailsIdX)
                    .HasName("PK_StudentAddresses_2017");

                entity.ToTable("StudentAddresses_2017");

                entity.Property(e => e.StudentDetailsIdX)
                    .HasColumnName("Student_Details_ID_X")
                    .HasColumnType("numeric");

                entity.Property(e => e.BoardingX)
                    .HasColumnName("Boarding_X")
                    .HasMaxLength(1);

                entity.Property(e => e.CampusNoX)
                    .HasColumnName("CampusNo_X")
                    .HasColumnType("numeric");

                entity.Property(e => e.ClientNumberX)
                    .HasColumnName("ClientNumber_X")
                    .HasColumnType("numeric");

                entity.Property(e => e.CommentsX)
                    .HasColumnName("Comments_X")
                    .HasMaxLength(250);

                entity.Property(e => e.HouseNoX)
                    .HasColumnName("HouseNo_X")
                    .HasMaxLength(25);

                entity.Property(e => e.LotNoX)
                    .HasColumnName("LotNo_X")
                    .HasMaxLength(25);

                entity.Property(e => e.PostCodeX)
                    .HasColumnName("PostCode_X")
                    .HasColumnType("numeric");

                entity.Property(e => e.PropertyNameX)
                    .HasColumnName("PropertyName_X")
                    .HasMaxLength(50);

                entity.Property(e => e.ShlTypeX)
                    .HasColumnName("ShlType_X")
                    .HasMaxLength(1);

                entity.Property(e => e.StateX)
                    .HasColumnName("State_X")
                    .HasMaxLength(25);

                entity.Property(e => e.StreetNameX)
                    .HasColumnName("StreetName_X")
                    .HasMaxLength(50);

                entity.Property(e => e.StreetTypeX)
                    .HasColumnName("StreetType_X")
                    .HasMaxLength(15);

                entity.Property(e => e.SuburbX)
                    .HasColumnName("Suburb_X")
                    .HasMaxLength(50);

                entity.Property(e => e.UnitNoX)
                    .HasColumnName("UnitNo_X")
                    .HasMaxLength(25);
            });
        }
    }
}