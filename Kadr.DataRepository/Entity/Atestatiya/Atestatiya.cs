namespace Kadr.Models.Entity
{
    public class AtestatiyaRepository : Repository<tbAtestatiya>, IAtestatiyaRepository
    {
        public AtestatiyaRepository(KadrDbContext context) : base(context)
        {
        }

    }
}
