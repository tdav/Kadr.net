using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_PEDOBRAZOVANIE table
    /// </summary>
    public class SaPedobrazovanieMapping : EntityTypeConfiguration<SaPedobrazovanie>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaPedobrazovanieMapping()
        {
            //table
ToTable("SA_PEDOBRAZOVANIE");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Nameru).HasColumnName("NAMERU").HasMaxLength(100);
            Property(x => x.Nameuz).HasColumnName("NAMEUZ").HasMaxLength(100);
            Property(x => x.State).HasColumnName("STATE");
            // Navigation properties
        }
    }
}
