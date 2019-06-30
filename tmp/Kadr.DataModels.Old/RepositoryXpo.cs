using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq.Expressions;
using Asbt.Data.Xpo;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;


namespace Asbt.Data
{    
    public class RepositoryXpo
    {
        public static string ConnectionString = "";
        

        public RepositoryXpo()
        {
            ConnectFb();
        }

        public static void ConnectFb()
        {
            ConnectionString =
                @"XpoProvider=Firebird;DataSource=localhost;User=sysdba;Password=masterkey;Database=d:\Work_New\Kadr.net\DataBase\REFERENCE.FDB;ServerType=0;Charset=UTF8";

            if (XpoDefault.DataLayer == null)
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(ConnectionString, AutoCreateOption.None);
            if (XpoDefault.Session == null)
                XpoDefault.Session = new Session(XpoDefault.DataLayer, null);
        }

        public void Dispose()
        {
            
        }
        public IQueryable<TBMAIN> GetAll()
        {

            XPCollection<TBMAIN> res = new XPCollection<TBMAIN>();
           return res.AsQueryable();
        }

        public TBMAIN GetSingle(string id)
        {

            XPQuery<TBMAIN> tb = Session.DefaultSession.Query<TBMAIN>();
            var tr = from c in tb
                where (c.ID == id)
                select c;
            return tr.SingleOrDefault();
        }



        public void Insert(TBMAIN entity)
        {   
            entity.Save();
        }

        public virtual void Delete(object id)
        {
            TBMAIN t = new TBMAIN(XpoDefault.Session);

        }

        public virtual void Delete(TBMAIN entityToDelete)
        {
            
        }

        public void Update(TBMAIN entityToUpdate)
        {
        }

        public bool Save()
        {
            return true;

        }
    }

}
