using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_VUZ table
    /// </summary>
    public class SaVuzMapping : EntityTypeConfiguration<SaVuz>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaVuzMapping()
        {
            //table
ToTable("SA_VUZ");
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
