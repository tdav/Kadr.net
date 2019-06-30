namespace Kadr.Models.Entity
{
    public class DbstructRepository : Repository<tbDbstruct>, IDbstructRepository
    {
        public DbstructRepository(KadrDbContext context) : base(context)
        {
        } 
    }
}
