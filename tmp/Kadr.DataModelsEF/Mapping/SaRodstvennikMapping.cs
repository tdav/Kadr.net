using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_RODSTVENNIK table
    /// </summary>
    public class SaRodstvennikMapping : EntityTypeConfiguration<SaRodstvennik>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaRodstvennikMapping()
        {
            //table
ToTable("SA_RODSTVENNIK");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(200);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(200);
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.State).HasColumnName("STATE");
            Property(x => x.Orderindex).HasColumnName("ORDERINDEX");
            Property(x => x.Rdsign).HasColumnName("RDSIGN");
            // Navigation properties
        }
    }
}
