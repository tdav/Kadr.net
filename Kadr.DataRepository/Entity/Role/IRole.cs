using Kadr.Database.Views;
using System.Collections.Generic;

namespace Kadr.Models.Entity
{
    public interface IRoleRepository : IRepositoy<spRole>
    {
        List<viSpList> GetSp();

    }
}
