using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_PARTIYA table
    /// </summary>
    public class SaPartiyaMapping : EntityTypeConfiguration<SaPartiya>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaPartiyaMapping()
        {
            //table
ToTable("SA_PARTIYA");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(450);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(450);
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
