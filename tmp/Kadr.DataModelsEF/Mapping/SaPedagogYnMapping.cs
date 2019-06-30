using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_PEDAGOG_YN table
    /// </summary>
    public class SaPedagogYnMapping : EntityTypeConfiguration<SaPedagogYn>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaPedagogYnMapping()
        {
            //table
ToTable("SA_PEDAGOG_YN");
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
