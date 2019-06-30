using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBQARINDOSH table
    /// </summary>
    public class TbqarindoshMapping : EntityTypeConfiguration<Tbqarindosh>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbqarindoshMapping()
        {
            //table
ToTable("TBQARINDOSH");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Lastname).HasColumnName("LASTNAME").HasMaxLength(50);
            Property(x => x.Firstname).HasColumnName("FIRSTNAME").HasMaxLength(50);
            Property(x => x.Patronymic).HasColumnName("PATRONYMIC").HasMaxLength(50);
            Property(x => x.Qarindoshligi).HasColumnName("QARINDOSHLIGI");
            Property(x => x.Dataroj).HasColumnName("DATAROJ").HasMaxLength(4);
            Property(x => x.Birthcountry).HasColumnName("BIRTHCOUNTRY").HasMaxLength(300);
            Property(x => x.Country).HasColumnName("COUNTRY");
            Property(x => x.Region).HasColumnName("REGION");
            Property(x => x.Rayon).HasColumnName("RAYON");
            Property(x => x.Yashashjoyi).HasColumnName("YASHASHJOYI").HasMaxLength(400);
            Property(x => x.Ishjoyi).HasColumnName("ISHJOYI").HasMaxLength(400);
            Property(x => x.Death).HasColumnName("DEATH").HasMaxLength(4);
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            Property(x => x.YashashjoyiRu).HasColumnName("YASHASHJOYI_RU").HasMaxLength(400);
            Property(x => x.IshjoyiRu).HasColumnName("ISHJOYI_RU").HasMaxLength(400);
            HasOptional(x => x.Main).WithMany(c => c.Tbqarindoshs).Map(m => m.MapKey("MAINID"));
            // Navigation properties
        }
    }
}
