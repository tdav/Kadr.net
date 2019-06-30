using Dapper;
using Kadr.Database.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kadr.Models.Entity
{
    public class UserRepository : Repository<tbUser>, IUserRepository
    {
        public UserRepository(KadrDbContext context) : base(context)
        {
        }

        public Tuple<string, viUser> CheckCardId(string id)
        {
            string sql = @"SELECT t.Id, t.LastName, t.FirstName, t.FatherName,  
                                  t.Login, t.Password, t.Status, t.CreateDate, 
                                  t.UpdateDate, r.Name as Role, r.UserAccess
                           FROM tbUsers t INNER JOIN spRoles r ON t.RoleId = r.Id
                           WHERE t.CardNumber='{0}'";

            sql = string.Format(sql, id);
            var user = Context.Database.Connection.Query<viUser>(sql).FirstOrDefault();

            if (user == null)
            {
                return new Tuple<string, viUser>("Пользователь не найден", null);
            }

            if (user.Status == 0)
            {
                return new Tuple<string, viUser>("Пользователь отключен", null);
            }

            return new Tuple<string, viUser>("", user);
        }

        public Tuple<string, viUser> CheckLogin(string u, string p)
        {
            string sql = @"SELECT t.Id, t.LastName, t.FirstName, t.FatherName,  
                                  t.Login, t.Password, t.Status, t.CreateDate, 
                                  t.UpdateDate, r.Name as Role, r.UserAccess
                           FROM tbUsers t INNER JOIN spRoles r ON t.RoleId = r.Id
                           WHERE t.Login='{0}' AND t.Password='{1}' ";

            sql = string.Format(sql, u, p);
            var user = Context.Database.Connection.Query<viUser>(sql).FirstOrDefault();

            if (user == null)
            {
                return new Tuple<string, viUser>("Пользователь не найден", null);
            }

            if (user.Status == 0)
            {
                return new Tuple<string, viUser>("Пользователь отключен", null);
            }

            return new Tuple<string, viUser>("", user);
        }

        public List<viUser> GetAllUsers()
        {
            string sql = @"SELECT t.Id, t.LastName, t.FirstName, t.FatherName,  
                                  t.Login, t.Password, t.Status, t.CreateDate, 
                                  t.UpdateDate, r.Name as Role, r.UserAccess
                           FROM tbUsers t INNER JOIN spRoles r ON t.RoleId = r.Id";
            return Context.Database.Connection.Query<viUser>(sql).ToList();
        }

        public List<viSpList> GetSp()
        {
            string sql = "SELECT Id, LastName+' '+FirstName+' '+FatherName AS Name FROM tbUsers order by LastName";
            return Context.Database.Connection.Query<viSpList>(sql).ToList();
        }
    }
}
