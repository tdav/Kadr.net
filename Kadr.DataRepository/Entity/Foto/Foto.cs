namespace Kadr.Models.Entity
{
    public class FotoRepository : Repository<tbFoto>, IFotoRepository
    {
        public FotoRepository(KadrDbContext context) : base(context)
        {
        }
    }
}
