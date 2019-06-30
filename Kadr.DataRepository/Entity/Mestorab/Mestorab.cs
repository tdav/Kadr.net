namespace Kadr.Models.Entity
{
    public class MestorabRepository : Repository<tbMestorab>, IMestorabRepository
    {
        public MestorabRepository(KadrDbContext context) : base(context)
        {
        }

    }
}
