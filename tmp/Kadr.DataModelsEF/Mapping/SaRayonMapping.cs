using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_RAYON table
    /// </summary>
    public class SaRayonMapping : EntityTypeConfiguration<SaRayon>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaRayonMapping()
        {
            //table
ToTable("SA_RAYON");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Obl).HasColumnName("OBL");
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(400);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(400);
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
