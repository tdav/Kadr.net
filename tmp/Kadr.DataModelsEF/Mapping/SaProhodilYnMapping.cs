using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_PROHODIL_YN table
    /// </summary>
    public class SaProhodilYnMapping : EntityTypeConfiguration<SaProhodilYn>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaProhodilYnMapping()
        {
            //table
ToTable("SA_PROHODIL_YN");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(50);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(50);
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
