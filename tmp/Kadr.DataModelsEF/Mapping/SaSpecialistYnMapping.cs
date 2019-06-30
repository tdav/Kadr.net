using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_SPECIALIST_YN table
    /// </summary>
    public class SaSpecialistYnMapping : EntityTypeConfiguration<SaSpecialistYn>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaSpecialistYnMapping()
        {
            //table
ToTable("SA_SPECIALIST_YN");
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
