using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_SEX table
    /// </summary>
    public class SaSexMapping : EntityTypeConfiguration<SaSex>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaSexMapping()
        {
            //table
ToTable("SA_SEX");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(10);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(10);
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
