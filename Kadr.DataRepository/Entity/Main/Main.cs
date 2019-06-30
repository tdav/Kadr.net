namespace Kadr.Models.Entity
{
    public class MainRepository : Repository<tbMain>, IMainRepository
    {
        public MainRepository(KadrDbContext context) : base(context)
        {
        }
    }
}
