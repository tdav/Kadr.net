using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_NAGRADA table
    /// </summary>
    public class SaNagradaMapping : EntityTypeConfiguration<SaNagrada>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaNagradaMapping()
        {
            //table
ToTable("SA_NAGRADA");
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
