using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_RABOTAET_YN table
    /// </summary>
    public class SaRabotaetYnMapping : EntityTypeConfiguration<SaRabotaetYn>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaRabotaetYnMapping()
        {
            //table
ToTable("SA_RABOTAET_YN");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(500);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(500);
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
