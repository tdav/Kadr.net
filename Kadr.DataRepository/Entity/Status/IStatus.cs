using Kadr.Database.Views;
using System.Collections.Generic;

namespace Kadr.Models.Entity
{
    public interface IStatusRepository : IRepositoy<spStatus>
    {
        List<viSpList> GetSp();
    }
}
