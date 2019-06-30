namespace Kadr.Models.Entity
{
    public class QarindoshRepository : Repository<tbQarindosh>, IQarindoshRepository
    {
        public QarindoshRepository(KadrDbContext context) : base(context)
        {
        }
    }
}
