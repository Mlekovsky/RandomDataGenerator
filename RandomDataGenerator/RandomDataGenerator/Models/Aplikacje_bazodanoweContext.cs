using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RandomDataGenerator.Models
{
    public partial class Aplikacje_bazodanoweContext : DbContext
    {
        public Aplikacje_bazodanoweContext()
        {
        }

        public Aplikacje_bazodanoweContext(DbContextOptions<Aplikacje_bazodanoweContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbookelement> Tbookelement { get; set; }
        public virtual DbSet<Tbooking> Tbooking { get; set; }
        public virtual DbSet<Tbookingpax> Tbookingpax { get; set; }
        public virtual DbSet<Tbookstate> Tbookstate { get; set; }
        public virtual DbSet<Tcountry> Tcountry { get; set; }
        public virtual DbSet<Tcustomer> Tcustomer { get; set; }
        public virtual DbSet<Tflight> Tflight { get; set; }
        public virtual DbSet<Tgroup> Tgroup { get; set; }
        public virtual DbSet<Thotel> Thotel { get; set; }
        public virtual DbSet<Thotelinfo> Thotelinfo { get; set; }
        public virtual DbSet<Tlanguage> Tlanguage { get; set; }
        public virtual DbSet<Tregion> Tregion { get; set; }
        public virtual DbSet<Tuser> Tuser { get; set; }
        public virtual DbSet<Tusergroup> Tusergroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=MLEKOMASZINA\\SQLEXPRESS;Database=Aplikacje_bazodanowe;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbookelement>(entity =>
            {
                entity.ToTable("TBOOKELEMENT");

                entity.HasIndex(e => e.TbookeltypeId)
                    .HasName("IFK_TBOOKELEMENT_TBOOKELTYPE");

                entity.HasIndex(e => e.TbookingId)
                    .HasName("IFK_TBOOKELEMENT_TBOOKING");

                entity.HasIndex(e => e.TflightId)
                    .HasName("IFK_TBOOKELEMENT_TFLIGHT");

                entity.HasIndex(e => e.ThotelId)
                    .HasName("IFK_TBOOKELEMENT_THOTEL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.TbookeltypeId).HasColumnName("TBOOKELTYPE_ID");

                entity.Property(e => e.TbookingId).HasColumnName("TBOOKING_ID");

                entity.Property(e => e.TflightId).HasColumnName("TFLIGHT_ID");

                entity.Property(e => e.ThotelId).HasColumnName("THOTEL_ID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Tbooking)
                    .WithMany(p => p.Tbookelement)
                    .HasForeignKey(d => d.TbookingId)
                    .HasConstraintName("FK_TBOOKELEMENT_TBOOKING");

                entity.HasOne(d => d.Tflight)
                    .WithMany(p => p.Tbookelement)
                    .HasForeignKey(d => d.TflightId)
                    .HasConstraintName("FK_TBOOKELEMENT_TFLIGHT");

                entity.HasOne(d => d.Thotel)
                    .WithMany(p => p.Tbookelement)
                    .HasForeignKey(d => d.ThotelId)
                    .HasConstraintName("FK_TBOOKELEMENT_THOTEL");
            });

            modelBuilder.Entity<Tbooking>(entity =>
            {
                entity.ToTable("TBOOKING");

                entity.HasIndex(e => e.Bookno)
                    .HasName("UNQ_TBOOKING")
                    .IsUnique();

                entity.HasIndex(e => e.TbookstateId)
                    .HasName("IFK_TBOOKING_TBOOKSTATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Booked)
                    .HasColumnName("BOOKED")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Bookno)
                    .HasColumnName("BOOKNO")
                    .HasDefaultValueSql("(NEXT VALUE FOR [SEQ_TBOOKING_BOOKNO])");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.TbookstateId).HasColumnName("TBOOKSTATE_ID");

                entity.Property(e => e.TcustomerId).HasColumnName("TCUSTOMER_ID");

                entity.Property(e => e.TotalPrice)
                    .HasColumnName("TOTAL_PRICE")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Tbookstate)
                    .WithMany(p => p.Tbooking)
                    .HasForeignKey(d => d.TbookstateId)
                    .HasConstraintName("FK_TBOOKING_TBOOKSTATE");

                entity.HasOne(d => d.Tcustomer)
                    .WithMany(p => p.Tbooking)
                    .HasForeignKey(d => d.TcustomerId)
                    .HasConstraintName("FK_TBOOKING_TCUSTOMER");
            });

            modelBuilder.Entity<Tbookingpax>(entity =>
            {
                entity.ToTable("TBOOKINGPAX");

                entity.HasIndex(e => e.Pesel)
                    .HasName("UNQ_TBOOKINGPAX")
                    .IsUnique();

                entity.HasIndex(e => e.TbookingId)
                    .HasName("IFK_TBOOKINGPAX_TBOOKING");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.IsCustomer)
                    .HasColumnName("IS_CUSTOMER")
                    .HasColumnType("decimal(38, 0)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Pesel)
                    .HasColumnName("PESEL")
                    .HasMaxLength(11);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.TbookingId).HasColumnName("TBOOKING_ID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Tbooking)
                    .WithMany(p => p.Tbookingpax)
                    .HasForeignKey(d => d.TbookingId)
                    .HasConstraintName("FK_TBOOKINGPAX_TBOOKING");
            });

            modelBuilder.Entity<Tbookstate>(entity =>
            {
                entity.ToTable("TBOOKSTATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tcountry>(entity =>
            {
                entity.ToTable("TCOUNTRY");

                entity.HasIndex(e => new { e.Name, e.Code })
                    .HasName("UNQ_TCOUNTRY")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(10);

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tcustomer>(entity =>
            {
                entity.ToTable("TCUSTOMER");

                entity.HasIndex(e => e.Email)
                    .HasName("UNQ_TCUSTOMER_EMAIL")
                    .IsUnique();

                entity.HasIndex(e => e.Pesel)
                    .HasName("UNQ_TCUSTOMER_PESEL")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150);

                entity.Property(e => e.Firstname)
                    .HasColumnName("FIRSTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Lastname)
                    .HasColumnName("LASTNAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Pesel)
                    .HasColumnName("PESEL")
                    .HasMaxLength(11);

                entity.Property(e => e.Phone)
                    .HasColumnName("PHONE")
                    .HasMaxLength(20);

                entity.Property(e => e.Points)
                    .HasColumnName("POINTS")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tflight>(entity =>
            {
                entity.ToTable("TFLIGHT");

                entity.HasIndex(e => new { e.Code, e.DepartureDate, e.ArrivalDate })
                    .HasName("UNQ_TFLIGHT")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ArrivalDate)
                    .HasColumnName("ARRIVAL_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(20);

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.DepartureDate)
                    .HasColumnName("DEPARTURE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.Handbag)
                    .HasColumnName("HANDBAG")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Handbagnum)
                    .HasColumnName("HANDBAGNUM")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Regbag)
                    .HasColumnName("REGBAG")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Regbagnum)
                    .HasColumnName("REGBAGNUM")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tgroup>(entity =>
            {
                entity.ToTable("TGROUP");

                entity.HasIndex(e => e.Name)
                    .HasName("UNQ_TGROUP")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Deleted)
                    .HasColumnName("DELETED")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.System)
                    .HasColumnName("SYSTEM")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Thotel>(entity =>
            {
                entity.ToTable("THOTEL");

                entity.HasIndex(e => e.TregionId)
                    .HasName("IFK_THOTEL_TREGION");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(200);

                entity.Property(e => e.Price)
                    .HasColumnName("PRICE")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Roomsamountleft)
                    .HasColumnName("ROOMSAMOUNTLEFT")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Roomsamounttotal)
                    .HasColumnName("ROOMSAMOUNTTOTAL")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.TregionId).HasColumnName("TREGION_ID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Tregion)
                    .WithMany(p => p.Thotel)
                    .HasForeignKey(d => d.TregionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THOTEL_TREGION");
            });

            modelBuilder.Entity<Thotelinfo>(entity =>
            {
                entity.ToTable("THOTELINFO");

                entity.HasIndex(e => e.ThotelId)
                    .HasName("IFK_THOTELINFO_THOTEL");

                entity.HasIndex(e => e.TlanguageId)
                    .HasName("IFK_THOTELINFO_TLANGUAGE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasColumnName("DESCRIPTION")
                    .HasMaxLength(1000);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.ThotelId).HasColumnName("THOTEL_ID");

                entity.Property(e => e.TlanguageId).HasColumnName("TLANGUAGE_ID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Thotel)
                    .WithMany(p => p.Thotelinfo)
                    .HasForeignKey(d => d.ThotelId)
                    .HasConstraintName("FK_THOTELINFO_THOTEL");

                entity.HasOne(d => d.Tlanguage)
                    .WithMany(p => p.Thotelinfo)
                    .HasForeignKey(d => d.TlanguageId)
                    .HasConstraintName("FK_THOTELINFO_TLANGUAGE");
            });

            modelBuilder.Entity<Tlanguage>(entity =>
            {
                entity.ToTable("TLANGUAGE");

                entity.HasIndex(e => new { e.Code, e.Name })
                    .HasName("UNQ_TLANGUAGE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("CODE")
                    .HasMaxLength(50);

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(50);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tregion>(entity =>
            {
                entity.ToTable("TREGION");

                entity.HasIndex(e => e.Name)
                    .HasName("UNQ_TREGION")
                    .IsUnique();

                entity.HasIndex(e => e.TcountryId)
                    .HasName("IFK_TREGION_TCOUNTRY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.TcountryId).HasColumnName("TCOUNTRY_ID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Tcountry)
                    .WithMany(p => p.Tregion)
                    .HasForeignKey(d => d.TcountryId)
                    .HasConstraintName("FK_TREGION_TCOUNTRY");
            });

            modelBuilder.Entity<Tuser>(entity =>
            {
                entity.ToTable("TUSER");

                entity.HasIndex(e => new { e.Name, e.Email })
                    .HasName("UNQ_TUSER")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreateUser)
                    .HasColumnName("CREATE_USER")
                    .HasMaxLength(100);

                entity.Property(e => e.Deleted)
                    .HasColumnName("DELETED")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("NAME")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Tusergroup>(entity =>
            {
                entity.ToTable("TUSERGROUP");

                entity.HasIndex(e => e.TgroupId)
                    .HasName("IFK_TUSERGROUP_TGROUP");

                entity.HasIndex(e => e.TuserId)
                    .HasName("IFK_TUSERGROUP_TUSER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Rowversion)
                    .HasColumnName("ROWVERSION")
                    .HasColumnType("decimal(38, 0)");

                entity.Property(e => e.TgroupId).HasColumnName("TGROUP_ID");

                entity.Property(e => e.TuserId).HasColumnName("TUSER_ID");

                entity.Property(e => e.UpdateDate)
                    .HasColumnName("UPDATE_DATE")
                    .HasColumnType("datetime2(2)");

                entity.Property(e => e.UpdateUser)
                    .HasColumnName("UPDATE_USER")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Tgroup)
                    .WithMany(p => p.Tusergroup)
                    .HasForeignKey(d => d.TgroupId)
                    .HasConstraintName("FK_TUSERGROUP_TGROUP");

                entity.HasOne(d => d.Tuser)
                    .WithMany(p => p.Tusergroup)
                    .HasForeignKey(d => d.TuserId)
                    .HasConstraintName("FK_TUSERGROUP_TUSER");
            });

            modelBuilder.HasSequence("SEQ_TBOOKING_BOOKNO");

            modelBuilder.HasSequence("SEQ_TFLIGHT");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
