using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_MARRIED table
    /// </summary>
    public class SaMarriedMapping : EntityTypeConfiguration<SaMarried>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaMarriedMapping()
        {
            //table
ToTable("SA_MARRIED");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(1000);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(1000);
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
