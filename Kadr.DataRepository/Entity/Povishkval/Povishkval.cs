namespace Kadr.Models.Entity
{
    public class PovishkvalRepository : Repository<tbPovishkval>, IPovishkvalRepository
    {
        public PovishkvalRepository(KadrDbContext context) : base(context)
        {
        }

    }
}
