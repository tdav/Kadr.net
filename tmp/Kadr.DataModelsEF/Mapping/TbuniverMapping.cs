using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to TBUNIVER table
    /// </summary>
    public class TbuniverMapping : EntityTypeConfiguration<Tbuniver>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public TbuniverMapping()
        {
            //table
ToTable("TBUNIVER");
            // Properties
            //  Id is primary key
            Property(x => x.Id).HasColumnName("ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.GodVipuska).HasColumnName("GOD_VIPUSKA").HasMaxLength(4);
            Property(x => x.ObrazovatelniyUcherj).HasColumnName("OBRAZOVATELNIY_UCHERJ");
            Property(x => x.SpecialnostPodiplomu).HasColumnName("SPECIALNOST_PODIPLOMU").HasMaxLength(400);
            Property(x => x.VidObucheniya).HasColumnName("VID_OBUCHENIYA");
            Property(x => x.ProfesianalObraz).HasColumnName("PROFESIANAL_OBRAZ");
            Property(x => x.ObType).HasColumnName("OB_TYPE");
            Property(x => x.Seriya).HasColumnName("SERIYA").HasMaxLength(5);
            Property(x => x.Num).HasColumnName("NUM");
            Property(x => x.Editdate).HasColumnName("EDITDATE");
            Property(x => x.Edituser).HasColumnName("EDITUSER");
            Property(x => x.SpecialnostPodiplomuRu).HasColumnName("SPECIALNOST_PODIPLOMU_RU").HasMaxLength(400);
            HasOptional(x => x.Main).WithMany(c => c.Tbunivers).Map(m => m.MapKey("MAINID"));
            // Navigation properties
        }
    }
}
