using Kadr.Database.Views;
using System.Collections.Generic;

namespace Kadr.Models.Entity
{
    public interface IAccessListRepository : IRepositoy<spAccessList>
    {
        List<viSpList> GetSp();        
        List<viSpList> GetList(string s);        
    }
}
