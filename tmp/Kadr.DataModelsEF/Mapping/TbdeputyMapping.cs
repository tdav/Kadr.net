using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBDEPUTY table
    /// </summary>
    public class TbdeputyMapping : EntityTypeConfiguration<Tbdeputy>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbdeputyMapping()
        {
            //table
ToTable("TBDEPUTY");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Deputy).HasColumnName("DEPUTY").HasMaxLength(600);
            Property(x => x.Date1).HasColumnName("DATE1").HasMaxLength(4);
            Property(x => x.Date2).HasColumnName("DATE2").HasMaxLength(4);
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            Property(x => x.DeputyRu).HasColumnName("DEPUTY_RU").HasMaxLength(600);
            HasOptional(x => x.Main).WithMany(c => c.Tbdeputies).Map(m => m.MapKey("MAINID"));
            // Navigation properties
        }
    }
}
