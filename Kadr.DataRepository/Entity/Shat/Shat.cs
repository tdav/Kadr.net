namespace Kadr.Models.Entity
{
    public class ShatRepository : Repository<tbShat>, IShatRepository
    {
        public ShatRepository(KadrDbContext context) : base(context)
        {
        }
    }
}
