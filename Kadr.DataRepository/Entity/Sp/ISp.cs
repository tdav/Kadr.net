using Kadr.Database.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kadr.Models.Entity
{
    public interface ISpListRepository : IRepositoy<viSpList>
    {
        Task<IEnumerable<viSpList>> GetSpAsync(string name, string lang);        
    }
}
