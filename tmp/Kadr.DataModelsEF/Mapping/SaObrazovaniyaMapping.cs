using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_OBRAZOVANIYA table
    /// </summary>
    public class SaObrazovaniyaMapping : EntityTypeConfiguration<SaObrazovaniya>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaObrazovaniyaMapping()
        {
            //table
ToTable("SA_OBRAZOVANIYA");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(350);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(350);
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
