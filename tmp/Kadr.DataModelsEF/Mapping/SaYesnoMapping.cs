using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_YESNO table
    /// </summary>
    public class SaYesnoMapping : EntityTypeConfiguration<SaYesno>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaYesnoMapping()
        {
            //table
ToTable("SA_YESNO");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(300);
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(300);
            Property(x => x.Active).HasColumnName("ACTIVE");
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
