using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBFOTO table
    /// </summary>
    public class TbfotoMapping : EntityTypeConfiguration<Tbfoto>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbfotoMapping()
        {
            //table
ToTable("TBFOTO");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Mainid).HasColumnName("MAINID").HasMaxLength(50);
            Property(x => x.Foto).HasColumnName("FOTO");
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            Property(x => x.Active).HasColumnName("ACTIVE");
            // Navigation properties
        }
    }
}
