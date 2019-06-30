using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBSHAT table
    /// </summary>
    public class TbshatMapping : EntityTypeConfiguration<Tbshat>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbshatMapping()
        {
            //table
ToTable("TBSHAT");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Oblast).HasColumnName("OBLAST");
            Property(x => x.Rayon).HasColumnName("RAYON");
            Property(x => x.Kolej).HasColumnName("KOLEJ");
            Property(x => x.KolCha).HasColumnName("KOL_CHAS").HasPrecision(3, 2);
            Property(x => x.Doljnost).HasColumnName("DOLJNOST");
            Property(x => x.Predmet).HasColumnName("PREDMET");
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
