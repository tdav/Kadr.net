using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_KOLLEJ table
    /// </summary>
    public class SaKollejMapping : EntityTypeConfiguration<SaKollej>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaKollejMapping()
        {
            //table
ToTable("SA_KOLLEJ");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(100);
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(100);
            Property(x => x.State).HasColumnName("STATE");
            Property(x => x.Obl).HasColumnName("OBL");
            Property(x => x.Rayon).HasColumnName("RAYON").HasMaxLength(100);
            Property(x => x.Turi).HasColumnName("TURI").HasMaxLength(100);
            // Navigation properties
        }
    }
}
