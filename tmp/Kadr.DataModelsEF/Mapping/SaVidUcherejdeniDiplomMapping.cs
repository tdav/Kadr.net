using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SA_VID_UCHEREJDENI_DIPLOM table
    /// </summary>
    public class SaVidUcherejdeniDiplomMapping : EntityTypeConfiguration<SaVidUcherejdeniDiplom>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public SaVidUcherejdeniDiplomMapping()
        {
            //table
ToTable("SA_VID_UCHEREJDENI_DIPLOM");
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
