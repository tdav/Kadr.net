using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBMESTORAB table
    /// </summary>
    public class TbmestorabMapping : EntityTypeConfiguration<Tbmestorab>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbmestorabMapping()
        {
            //table
ToTable("TBMESTORAB");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Date1).HasColumnName("DATE1").HasMaxLength(4);
            Property(x => x.Date2).HasColumnName("DATE2").HasMaxLength(4);
            Property(x => x.Ishjoyi).HasColumnName("ISHJOYI").HasMaxLength(150);
            Property(x => x.Workplace).HasColumnName("WORKPLACE");
            Property(x => x.Lavozim).HasColumnName("LAVOZIM").HasMaxLength(500);
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            Property(x => x.IshjoyiRu).HasColumnName("ISHJOYI_RU").HasMaxLength(150);
            Property(x => x.LavozimRu).HasColumnName("LAVOZIM_RU").HasMaxLength(500);
            HasOptional(x => x.Main).WithMany(c => c.Tbmestorabs).Map(m => m.MapKey("MAINID"));
            // Navigation properties
        }
    }
}
