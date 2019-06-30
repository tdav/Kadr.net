namespace Kadr.Models.Entity
{
    public class OperatorRepository : Repository<tbOperator>, IOperatorRepository
    {
        public OperatorRepository(KadrDbContext context) : base(context)
        {
        }
    }
}
