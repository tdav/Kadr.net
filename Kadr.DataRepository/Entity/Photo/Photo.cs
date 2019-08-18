namespace Kadr.Models.Entity
{
    public class PhotoRepository : Repository<tbPhoto>, IPhotoRepository
    {
        public PhotoRepository(KadrDbContext context) : base(context)
        {
        }
    }
}
