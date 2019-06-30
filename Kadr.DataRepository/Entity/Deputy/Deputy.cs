namespace Kadr.Models.Entity
{
    public class DeputyRepository : Repository<tbDeputy>, IDeputyRepository
    {
        public DeputyRepository(KadrDbContext context) : base(context)
        {
        } 
    }
}
