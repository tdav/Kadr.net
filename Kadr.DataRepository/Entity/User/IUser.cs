using Kadr.Database.Views;
using System;
using System.Collections.Generic;

namespace Kadr.Models.Entity
{
    public interface IUserRepository : IRepositoy<tbUser>
    {
        List<viUser> GetAllUsers();
        List<viSpList> GetSp();

        Tuple<string, viUser> CheckLogin(string u, string p);

        Tuple<string, viUser> CheckCardId(string id);
    }
}
