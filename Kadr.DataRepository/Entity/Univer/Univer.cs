namespace Kadr.Models.Entity
{
    public class UniverRepository : Repository<tbUniver>, IUniverRepository
    {
        public UniverRepository(KadrDbContext context) : base(context)
        {
        }
    }
}
