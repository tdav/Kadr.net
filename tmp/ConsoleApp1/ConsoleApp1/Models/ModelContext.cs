using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kadr.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SaAtestaciyaRes> SaAtestaciyaRes { get; set; }
        public virtual DbSet<SaAtestaciyaYn> SaAtestaciyaYn { get; set; }
        public virtual DbSet<SaCountry> SaCountry { get; set; }
        public virtual DbSet<SaDoljnost> SaDoljnost { get; set; }
        public virtual DbSet<SaHarbiyUnvon> SaHarbiyUnvon { get; set; }
        public virtual DbSet<SaKollej> SaKollej { get; set; }
        public virtual DbSet<SaLangs> SaLangs { get; set; }
        public virtual DbSet<SaLicey> SaLicey { get; set; }
        public virtual DbSet<SaMarried> SaMarried { get; set; }
        public virtual DbSet<SaMasterKategoriya> SaMasterKategoriya { get; set; }
        public virtual DbSet<SaNagrada> SaNagrada { get; set; }
        public virtual DbSet<SaNat> SaNat { get; set; }
        public virtual DbSet<SaObjlang> SaObjlang { get; set; }
        public virtual DbSet<SaOblast> SaOblast { get; set; }
        public virtual DbSet<SaObrazovaniya> SaObrazovaniya { get; set; }
        public virtual DbSet<SaPartiya> SaPartiya { get; set; }
        public virtual DbSet<SaPedagogYn> SaPedagogYn { get; set; }
        public virtual DbSet<SaPedobrazovanie> SaPedobrazovanie { get; set; }
        public virtual DbSet<SaPedperepod> SaPedperepod { get; set; }
        public virtual DbSet<SaPinyatNaRabotu> SaPinyatNaRabotu { get; set; }
        public virtual DbSet<SaPoShatatu> SaPoShatatu { get; set; }
        public virtual DbSet<SaPredmet> SaPredmet { get; set; }
        public virtual DbSet<SaProhodilYn> SaProhodilYn { get; set; }
        public virtual DbSet<SaRabotaetYn> SaRabotaetYn { get; set; }
        public virtual DbSet<SaRayon> SaRayon { get; set; }
        public virtual DbSet<SaRodstvennik> SaRodstvennik { get; set; }
        public virtual DbSet<SaScstatus> SaScstatus { get; set; }
        public virtual DbSet<SaSex> SaSex { get; set; }
        public virtual DbSet<SaSpecialistYn> SaSpecialistYn { get; set; }
        public virtual DbSet<SaSpeciality> SaSpeciality { get; set; }
        public virtual DbSet<SaUcheniyStepen> SaUcheniyStepen { get; set; }
        public virtual DbSet<SaVidObucheniya> SaVidObucheniya { get; set; }
        public virtual DbSet<SaVidPredmeta> SaVidPredmeta { get; set; }
        public virtual DbSet<SaVidUcherejdeni> SaVidUcherejdeni { get; set; }
        public virtual DbSet<SaVidUcherejdeniDiplom> SaVidUcherejdeniDiplom { get; set; }
        public virtual DbSet<SaVuz> SaVuz { get; set; }
        public virtual DbSet<SaYesno> SaYesno { get; set; }
        public virtual DbSet<TbUsers> Scusers { get; set; }
        public virtual DbSet<TbAtestatiya> Tbatestatiya { get; set; }
        public virtual DbSet<TbDeputy> Tbdeputy { get; set; }
        public virtual DbSet<TbFoto> Tbfoto { get; set; }
        public virtual DbSet<TbQosnagradi> Tbgosnagradi { get; set; }
        public virtual DbSet<TbMain> Tbmain { get; set; }
        public virtual DbSet<TbMestorab> Tbmestorab { get; set; }
        public virtual DbSet<TbPovishkval> Tbpovishkval { get; set; }
        public virtual DbSet<TbQarindosh> Tbqarindosh { get; set; }
        public virtual DbSet<TbShat> Tbshat { get; set; }
        public virtual DbSet<TbUniver> Tbuniver { get; set; }

        // Unable to generate entity type for table 'DBSTRUCT                       '. Please see the warning messages.
        // Unable to generate entity type for table 'SETUP                          '. Please see the warning messages.
        // Unable to generate entity type for table 'DBOPERATOR                     '. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseFirebird("User=sysdba;Password=masterkey;Database=c:\\Kadr\\REFERENCE.FDB;Dialect=3;Charset=UTF8;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<TbAtestatiya>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBATESTATIYA");

                entity.HasIndex(e => e.Mainid)
                    .HasName("FK_TBATESTATIYA_1")
                    .IsUnique();

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });

            modelBuilder.Entity<TbDeputy>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBDEPUTY");

                entity.HasIndex(e => e.Mainid)
                    .HasName("FK_TBDEPUTY_1")
                    .IsUnique();

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });

            modelBuilder.Entity<TbFoto>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBFOTO");

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });

            modelBuilder.Entity<TbQosnagradi>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBGOSNAGRADI");

                entity.HasIndex(e => e.Mainid)
                    .HasName("FK_TBGOSNAGRADI_1")
                    .IsUnique();

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });

            modelBuilder.Entity<TbMain>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBMAIN");

                entity.Property(e => e.Active).HasDefaultValueSql("DEFAULT 1");

                entity.Property(e => e.Createdate).HasDefaultValueSql("DEFAULT current_date");

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });

            modelBuilder.Entity<TbMestorab>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBMESTORAB");

                entity.HasIndex(e => e.Mainid)
                    .HasName("FK_TBMESTORAB_1")
                    .IsUnique();

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });

            modelBuilder.Entity<TbPovishkval>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBPOVISHKVAL");

                entity.HasIndex(e => e.Mainid)
                    .HasName("FK_TBPOVISHKVAL_1")
                    .IsUnique();

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });

            modelBuilder.Entity<TbQarindosh>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBQARINDOSH");

                entity.HasIndex(e => e.Mainid)
                    .HasName("FK_TBQARINDOSH_1")
                    .IsUnique();

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });

            modelBuilder.Entity<TbShat>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBSHAT");
            });

            modelBuilder.Entity<TbUniver>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("PK_TBUNIVER");

                entity.HasIndex(e => e.Mainid)
                    .HasName("FK_TBUNIVER_1")
                    .IsUnique();

                entity.Property(e => e.Editdate).HasDefaultValueSql("DEFAULT current_date");
            });
        }
    }
}
