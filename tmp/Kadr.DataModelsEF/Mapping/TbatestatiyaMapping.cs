using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBATESTATIYA table
    /// </summary>
    public class TbatestatiyaMapping : EntityTypeConfiguration<Tbatestatiya>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbatestatiyaMapping()
        {
            //table
ToTable("TBATESTATIYA");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.PrivlichenYn).HasColumnName("PRIVLICHEN_YN");
            Property(x => x.DateAt).HasColumnName("DATE_AT");
            Property(x => x.ResultAa).HasColumnName("RESULT_AA");
            Property(x => x.DoljnostPosle).HasColumnName("DOLJNOST_POSLE");
            Property(x => x.PichinaNePrivlicheniya).HasColumnName("PICHINA_NE_PRIVLICHENIYA").HasMaxLength(500);
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            Property(x => x.PichinaNePrivlicheniyaRu).HasColumnName("PICHINA_NE_PRIVLICHENIYA_RU").HasMaxLength(500);
            HasOptional(x => x.Main).WithMany(c => c.Tbatestatiyas).Map(m => m.MapKey("MAINID"));
            // Navigation properties
        }
    }
}
