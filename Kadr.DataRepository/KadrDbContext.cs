using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Kadr.Models
{
    public partial class KadrDbContext : System.Data.Entity.DbContext
    {
        public KadrDbContext() : base("name=KadrConnectionString")
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<AptDbContext, Apteka.DataModels.Migrations.Configuration>());

          //  Database.SetInitializer<KadrDbContext>(new CreateDatabaseIfNotExists<KadrDbContext>());
           

            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbContextTransaction transaction;

        #region Vars
        public virtual DbSet<SaAtestaciyaRes> spAtestaciyaRess { get; set; }
        public virtual DbSet<SaAtestaciyaYn> spAtestaciyaYns { get; set; }
        public virtual DbSet<SaCountry> spCountrys { get; set; }
        public virtual DbSet<SaDoljnost> spDoljnosts { get; set; }
        public virtual DbSet<SaHarbiyUnvon> spHarbiyUnvons { get; set; }
        public virtual DbSet<SaKollej> spKollejs { get; set; }
        public virtual DbSet<SaLang> spLangs { get; set; }
        public virtual DbSet<SaLicey> spLiceys { get; set; }
        public virtual DbSet<SaMarried> spMarrieds { get; set; }
        public virtual DbSet<SaMasterKategoriya> spMasterKategoriyas { get; set; }
        public virtual DbSet<SaNagrada> spNagradas { get; set; }
        public virtual DbSet<spNationality> spNats { get; set; }
        public virtual DbSet<SaObjlang> spObjlangs { get; set; }
        public virtual DbSet<SaOblast> spOblasts { get; set; }
        public virtual DbSet<SaObrazovaniya> spObrazovaniyas { get; set; }
        public virtual DbSet<SaPartiya> spPartiyas { get; set; }
        public virtual DbSet<SaPedagogYn> spPedagogYns { get; set; }
        public virtual DbSet<SaPedobrazovanie> spPedobrazovanies { get; set; }
        public virtual DbSet<SaPedperepod> spPedperepods { get; set; }
        public virtual DbSet<SaPinyatNaRabotu> spPinyatNaRabotus { get; set; }
        public virtual DbSet<SaPoShatatu> spPoShatatus { get; set; }
        public virtual DbSet<SaPredmet> spPredmets { get; set; }
        public virtual DbSet<SaProhodilYn> spProhodilYns { get; set; }
        public virtual DbSet<SaRabotaetYn> spRabotaetYns { get; set; }
        public virtual DbSet<SaRayon> spRayons { get; set; }
        public virtual DbSet<SaRodstvennik> spRodstvenniks { get; set; }
        public virtual DbSet<spScStatus> spScstatuss { get; set; }
        public virtual DbSet<spSex> spSexs { get; set; }
        public virtual DbSet<SaSpecialistYn> spSpecialistYns { get; set; }
        public virtual DbSet<SaSpeciality> spSpecialitys { get; set; }
        public virtual DbSet<SaUcheniyStepen> spUcheniyStepens { get; set; }
        public virtual DbSet<SaVidObucheniya> spVidObucheniyas { get; set; }
        public virtual DbSet<SaVidPredmeta> spVidPredmetas { get; set; }
        public virtual DbSet<SaVidUcherejdeni> spVidUcherejdenis { get; set; }
        public virtual DbSet<SaVidUcherejdeniDiplom> spVidUcherejdeniDiploms { get; set; }
        public virtual DbSet<SaVuz> spVuzs { get; set; }
        public virtual DbSet<spAccessList> spAccessLists { get; set; }
        public virtual DbSet<SaYesno> spYesNos { get; set; }
        public virtual DbSet<spStatus> Status { get; set; }
        public virtual DbSet<spRole> Role { get; set; }
        public virtual DbSet<tbUser> tbUsers { get; set; }
        public virtual DbSet<tbAtestatiya> tbAtestatiyas { get; set; }
        public virtual DbSet<tbDeputy> tbDeputys { get; set; }
        public virtual DbSet<tbPhoto> tbFotos { get; set; }
        public virtual DbSet<tbGosnagradi> tbGosnagradis { get; set; }
        public virtual DbSet<tbMain> tbMains { get; set; }
        public virtual DbSet<tbMestorab> tbMestorabs { get; set; }
        public virtual DbSet<tbPovishkval> tbPovishkvals { get; set; }
        public virtual DbSet<tbQarindosh> tbQarindoshs { get; set; }
        public virtual DbSet<tbShat> tbShats { get; set; }
        public virtual DbSet<tbUniver> tbUnives { get; set; }
        public virtual DbSet<tbDbstruct> tbDbstructs { get; set; }
        public virtual DbSet<tbSetup> tbSetups { get; set; }
        public virtual DbSet<tbOperator> tbOperators { get; set; }


        #endregion



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
