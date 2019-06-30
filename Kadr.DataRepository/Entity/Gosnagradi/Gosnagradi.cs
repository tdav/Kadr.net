namespace Kadr.Models.Entity
{
    public class GosnagradiRepository : Repository<tbGosnagradi>, IGosnagradiRepository
    {
        public GosnagradiRepository(KadrDbContext context) : base(context)
        {
        } 
    }
}
