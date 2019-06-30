using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Domain.Mapping;

namespace Domain
{

    public class DomainContext : DbContext
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public DomainContext()
        {
            //default ctor uses app.config connection named DomainContext
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public DomainContext(DbConnection connection) : base(connection,true)
        {
            //ctor for tracing
        }

        public IDbSet<SaAtestaciyaRe> SaAtestaciyaRes
        {
            get { return Set<SaAtestaciyaRe>(); }
        }

        public IDbSet<SaAtestaciyaYn> SaAtestaciyaYns
        {
            get { return Set<SaAtestaciyaYn>(); }
        }

        public IDbSet<SaCountry> SaCountries
        {
            get { return Set<SaCountry>(); }
        }

        public IDbSet<SaDoljnost> SaDoljnosts
        {
            get { return Set<SaDoljnost>(); }
        }

        public IDbSet<SaHarbiyUnvon> SaHarbiyUnvons
        {
            get { return Set<SaHarbiyUnvon>(); }
        }

        public IDbSet<SaKollej> SaKollejs
        {
            get { return Set<SaKollej>(); }
        }

        public IDbSet<SaLang> SaLangs
        {
            get { return Set<SaLang>(); }
        }

        public IDbSet<SaLicey> SaLiceies
        {
            get { return Set<SaLicey>(); }
        }

        public IDbSet<SaMarried> SaMarrieds
        {
            get { return Set<SaMarried>(); }
        }

        public IDbSet<SaMasterKategoriya> SaMasterKategoriyas
        {
            get { return Set<SaMasterKategoriya>(); }
        }

        public IDbSet<SaNagrada> SaNagradas
        {
            get { return Set<SaNagrada>(); }
        }

        public IDbSet<SaNat> SaNats
        {
            get { return Set<SaNat>(); }
        }

        public IDbSet<SaObjlang> SaObjlangs
        {
            get { return Set<SaObjlang>(); }
        }

        public IDbSet<SaOblast> SaOblasts
        {
            get { return Set<SaOblast>(); }
        }

        public IDbSet<SaObrazovaniya> SaObrazovaniyas
        {
            get { return Set<SaObrazovaniya>(); }
        }

        public IDbSet<SaPartiya> SaPartiyas
        {
            get { return Set<SaPartiya>(); }
        }

        public IDbSet<SaPedagogYn> SaPedagogYns
        {
            get { return Set<SaPedagogYn>(); }
        }

        public IDbSet<SaPedobrazovanie> SaPedobrazovanies
        {
            get { return Set<SaPedobrazovanie>(); }
        }

        public IDbSet<SaPedperepod> SaPedperepods
        {
            get { return Set<SaPedperepod>(); }
        }

        public IDbSet<SaPinyatNaRabotu> SaPinyatNaRabotus
        {
            get { return Set<SaPinyatNaRabotu>(); }
        }

        public IDbSet<SaPoShatatu> SaPoShatatus
        {
            get { return Set<SaPoShatatu>(); }
        }

        public IDbSet<SaPredmet> SaPredmets
        {
            get { return Set<SaPredmet>(); }
        }

        public IDbSet<SaProhodilYn> SaProhodilYns
        {
            get { return Set<SaProhodilYn>(); }
        }

        public IDbSet<SaRabotaetYn> SaRabotaetYns
        {
            get { return Set<SaRabotaetYn>(); }
        }

        public IDbSet<SaRayon> SaRayons
        {
            get { return Set<SaRayon>(); }
        }

        public IDbSet<SaRodstvennik> SaRodstvenniks
        {
            get { return Set<SaRodstvennik>(); }
        }

        public IDbSet<SaScstatus> SaScstatuss
        {
            get { return Set<SaScstatus>(); }
        }

        public IDbSet<SaSex> SaSexes
        {
            get { return Set<SaSex>(); }
        }

        public IDbSet<SaSpecialistYn> SaSpecialistYns
        {
            get { return Set<SaSpecialistYn>(); }
        }

        public IDbSet<SaSpeciality> SaSpecialities
        {
            get { return Set<SaSpeciality>(); }
        }

        public IDbSet<SaUcheniyStepen> SaUcheniyStepens
        {
            get { return Set<SaUcheniyStepen>(); }
        }

        public IDbSet<SaVidObucheniya> SaVidObucheniyas
        {
            get { return Set<SaVidObucheniya>(); }
        }

        public IDbSet<SaVidPredmeta> SaVidPredmetas
        {
            get { return Set<SaVidPredmeta>(); }
        }

        public IDbSet<SaVidUcherejdeni> SaVidUcherejdenis
        {
            get { return Set<SaVidUcherejdeni>(); }
        }

        public IDbSet<SaVidUcherejdeniDiplom> SaVidUcherejdeniDiploms
        {
            get { return Set<SaVidUcherejdeniDiplom>(); }
        }

        public IDbSet<SaVuz> SaVuzs
        {
            get { return Set<SaVuz>(); }
        }

        public IDbSet<SaYesno> SaYesnoes
        {
            get { return Set<SaYesno>(); }
        }

        public IDbSet<Scuser> Scusers
        {
            get { return Set<Scuser>(); }
        }

        public IDbSet<Tbatestatiya> Tbatestatiyas
        {
            get { return Set<Tbatestatiya>(); }
        }

        public IDbSet<Tbdeputy> Tbdeputies
        {
            get { return Set<Tbdeputy>(); }
        }

        public IDbSet<Tbfoto> Tbfotoes
        {
            get { return Set<Tbfoto>(); }
        }

        public IDbSet<Tbgosnagradi> Tbgosnagradis
        {
            get { return Set<Tbgosnagradi>(); }
        }

        public IDbSet<Tbmain> Tbmains
        {
            get { return Set<Tbmain>(); }
        }

        public IDbSet<Tbmestorab> Tbmestorabs
        {
            get { return Set<Tbmestorab>(); }
        }

        public IDbSet<Tbpovishkval> Tbpovishkvals
        {
            get { return Set<Tbpovishkval>(); }
        }

        public IDbSet<Tbqarindosh> Tbqarindoshs
        {
            get { return Set<Tbqarindosh>(); }
        }

        public IDbSet<Tbshat> Tbshats
        {
            get { return Set<Tbshat>(); }
        }

        public IDbSet<Tbuniver> Tbunivers
        {
            get { return Set<Tbuniver>(); }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DomainContext>(null);
            modelBuilder.Configurations.Add(new SaAtestaciyaReMapping());
            modelBuilder.Configurations.Add(new SaAtestaciyaYnMapping());
            modelBuilder.Configurations.Add(new SaCountryMapping());
            modelBuilder.Configurations.Add(new SaDoljnostMapping());
            modelBuilder.Configurations.Add(new SaHarbiyUnvonMapping());
            modelBuilder.Configurations.Add(new SaKollejMapping());
            modelBuilder.Configurations.Add(new SaLangMapping());
            modelBuilder.Configurations.Add(new SaLiceyMapping());
            modelBuilder.Configurations.Add(new SaMarriedMapping());
            modelBuilder.Configurations.Add(new SaMasterKategoriyaMapping());
            modelBuilder.Configurations.Add(new SaNagradaMapping());
            modelBuilder.Configurations.Add(new SaNatMapping());
            modelBuilder.Configurations.Add(new SaObjlangMapping());
            modelBuilder.Configurations.Add(new SaOblastMapping());
            modelBuilder.Configurations.Add(new SaObrazovaniyaMapping());
            modelBuilder.Configurations.Add(new SaPartiyaMapping());
            modelBuilder.Configurations.Add(new SaPedagogYnMapping());
            modelBuilder.Configurations.Add(new SaPedobrazovanieMapping());
            modelBuilder.Configurations.Add(new SaPedperepodMapping());
            modelBuilder.Configurations.Add(new SaPinyatNaRabotuMapping());
            modelBuilder.Configurations.Add(new SaPoShatatuMapping());
            modelBuilder.Configurations.Add(new SaPredmetMapping());
            modelBuilder.Configurations.Add(new SaProhodilYnMapping());
            modelBuilder.Configurations.Add(new SaRabotaetYnMapping());
            modelBuilder.Configurations.Add(new SaRayonMapping());
            modelBuilder.Configurations.Add(new SaRodstvennikMapping());
            modelBuilder.Configurations.Add(new SaScstatusMapping());
            modelBuilder.Configurations.Add(new SaSexMapping());
            modelBuilder.Configurations.Add(new SaSpecialistYnMapping());
            modelBuilder.Configurations.Add(new SaSpecialityMapping());
            modelBuilder.Configurations.Add(new SaUcheniyStepenMapping());
            modelBuilder.Configurations.Add(new SaVidObucheniyaMapping());
            modelBuilder.Configurations.Add(new SaVidPredmetaMapping());
            modelBuilder.Configurations.Add(new SaVidUcherejdeniMapping());
            modelBuilder.Configurations.Add(new SaVidUcherejdeniDiplomMapping());
            modelBuilder.Configurations.Add(new SaVuzMapping());
            modelBuilder.Configurations.Add(new SaYesnoMapping());
            modelBuilder.Configurations.Add(new ScuserMapping());
            modelBuilder.Configurations.Add(new TbatestatiyaMapping());
            modelBuilder.Configurations.Add(new TbdeputyMapping());
            modelBuilder.Configurations.Add(new TbfotoMapping());
            modelBuilder.Configurations.Add(new TbgosnagradiMapping());
            modelBuilder.Configurations.Add(new TbmainMapping());
            modelBuilder.Configurations.Add(new TbmestorabMapping());
            modelBuilder.Configurations.Add(new TbpovishkvalMapping());
            modelBuilder.Configurations.Add(new TbqarindoshMapping());
            modelBuilder.Configurations.Add(new TbshatMapping());
            modelBuilder.Configurations.Add(new TbuniverMapping());
        }
    }
}
