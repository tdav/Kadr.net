using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBGOSNAGRADI table
    /// </summary>
    public class TbgosnagradiMapping : EntityTypeConfiguration<Tbgosnagradi>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbgosnagradiMapping()
        {
            //table
ToTable("TBGOSNAGRADI");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.DateGn).HasColumnName("DATE_GN").HasMaxLength(4);
            Property(x => x.Nazvanie).HasColumnName("NAZVANIE").HasMaxLength(400);
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            Property(x => x.NazvanieRu).HasColumnName("NAZVANIE_RU").HasMaxLength(400);
            HasOptional(x => x.Main).WithMany(c => c.Tbgosnagradis).Map(m => m.MapKey("MAINID"));
            // Navigation properties
        }
    }
}
