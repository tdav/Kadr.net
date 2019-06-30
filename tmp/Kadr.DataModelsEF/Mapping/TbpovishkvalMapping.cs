using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBPOVISHKVAL table
    /// </summary>
    public class TbpovishkvalMapping : EntityTypeConfiguration<Tbpovishkval>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbpovishkvalMapping()
        {
            //table
ToTable("TBPOVISHKVAL");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.DatePk).HasColumnName("DATE_PK");
            Property(x => x.MestoPk).HasColumnName("MESTO_PK");
            Property(x => x.PosledniyPk).HasColumnName("POSLEDNIY_PK");
            Property(x => x.NumSertificat).HasColumnName("NUM_SERTIFICAT").HasMaxLength(15);
            Property(x => x.SrokPalnPk).HasColumnName("SROK_PALN_PK");
            Property(x => x.Pedobrazovaniepk).HasColumnName("PEDOBRAZOVANIEPK");
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            HasOptional(x => x.Main).WithMany(c => c.Tbpovishkvals).Map(m => m.MapKey("MAINID"));
            // Navigation properties
        }
    }
}
