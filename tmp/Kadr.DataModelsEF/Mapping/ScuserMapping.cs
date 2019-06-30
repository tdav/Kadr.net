using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Mapping
{

    /// <summary>
    /// Class mapping to SCUSERS table
    /// </summary>
    public class ScuserMapping : EntityTypeConfiguration<Scuser>
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public ScuserMapping()
        {
            //table
ToTable("SCUSERS");
            // Primary key
            HasKey(x => x.Userid);
            // Properties
            //  Userid is primary key
            Property(x => x.Userid).HasColumnName("USERID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None).IsRequired();
            Property(x => x.Loginname).HasColumnName("LOGINNAME").HasMaxLength(50);
            Property(x => x.Fullname).HasColumnName("FULLNAME").HasMaxLength(50);
            Property(x => x.Password).HasColumnName("PASSWORD").HasMaxLength(50);
            Property(x => x.Lastaccess).HasColumnName("LASTACCESS");
            Property(x => x.Enabled).HasColumnName("ENABLED");
            Property(x => x.Createddate).HasColumnName("CREATEDDATE");
            Property(x => x.Lastacctime).HasColumnName("LASTACCTIME");
            Property(x => x.Createdtime).HasColumnName("CREATEDTIME");
            Property(x => x.Accesscount).HasColumnName("ACCESSCOUNT");
            Property(x => x.Lang).HasColumnName("LANG").HasMaxLength(2);
            Property(x => x.Acsess).HasColumnName("ACSESS").HasMaxLength(1000);
            // Navigation properties
        }
    }
}
