using Dapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.Entity;
using Kadr.Models.Entity;
using Apteka.Utils;

namespace Kadr.Models.Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KadrDbContext _context;

        #region Vars

        public IStatusRepository Status { get; }
        public IRoleRepository Role { get; }
        public IAccessListRepository AccessList { get; }

        public IAtestatiyaRepository Atestatiya { get; }
        public IDbstructRepository Dbstruct { get; }
        public IDeputyRepository Deputy { get; }
        public IPhotoRepository Photo { get; }
        public IGosnagradiRepository Gosnagradi { get; }
        public IMainRepository Main { get; }
        public IMestorabRepository Mestorab { get; }
        public IOperatorRepository Operator { get; }
        public IPovishkvalRepository Povishkval { get; }
        public IQarindoshRepository Qarindosh { get; }
        public ISetupRepository Setup { get; }
        public IShatRepository Shat { get; }
        public IUniverRepository Univer { get; }
        public IUserRepository User { get; }
        public ISpListRepository Sps { get; }

        

        #endregion

        public UnitOfWork()
        {
            _context = new KadrDbContext();

            Main = new MainRepository(_context);
            Atestatiya = new AtestatiyaRepository(_context);
            Dbstruct = new DbstructRepository(_context);
            Deputy = new DeputyRepository(_context);

            Photo = new PhotoRepository(_context);
            Gosnagradi = new GosnagradiRepository(_context);
            Mestorab = new MestorabRepository(_context);
            Operator = new OperatorRepository(_context);
            Povishkval = new PovishkvalRepository(_context);
            Qarindosh = new QarindoshRepository(_context);
            Setup = new SetupRepository(_context);
            Shat = new ShatRepository(_context);
            Univer = new UniverRepository(_context);
            User = new UserRepository(_context);

            AccessList = new AccessListRepository(_context);
            Status = new StatusRepository(_context);
            Role = new RoleRepository(_context);

            Sps = new SpListRepository(_context);
        }

        public int Complete()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                string s = "";
                foreach (DbEntityValidationResult eve in e.EntityValidationErrors)
                {
                    s = $"Entity of type '{eve.Entry.Entity.GetType().Name}' in state '{eve.Entry.State}' has the following validation errors:";
                    foreach (DbValidationError ve in eve.ValidationErrors)
                    {
                        s = s + Environment.NewLine +
                            $"- Property: '{ve.PropertyName}', Error: '{ve.ErrorMessage}'";
                    }
                }

                LogItem li = new LogItem
                {
                    App = "Apteka.Models.Entity",
                    Message = s,
                    Mestype = "e",
                    Method = "UnitOfWork.Complete"
                };
                CLogJson.Write(li);

                throw;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void BeginTransaction()
        {
            _context.transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_context.transaction != null)
            {
                _context.transaction.Commit();
                _context.transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (_context.transaction != null)
            {
                _context.transaction.Rollback();
                _context.transaction = null;
            }
        }

        public object ExecSql(string sql)
        {
            sql = sql.Trim().ToUpper();
            string connstr = _context.Database.Connection.ConnectionString;

            if (sql.Substring(0, 6) == "SELECT")
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, connstr);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                da.Dispose();
                return dataTable;
            }
            else
            {
                return _context.Database.ExecuteSqlCommand(sql);
            }
        }

        public int UpdDel(string sql, string table, string param)
        {
            //try
            //{
            //    return _context.Database.ExecuteSqlCommand($"select count(id) from {table}");
            //}
            //catch (Exception ee)
            //{
            //    CLog.Write(ee.Message);
            //    return null;
            //}

            if (param?.Length == 0) return -1;

            string s = string.Format(sql, table, param);
            return _context.Database.ExecuteSqlCommand(s);
        }

        public List<T> GetListToServer<T>(string name = "")
        {
            try
            {
                string sql = string.Empty;
                if (name?.Length == 0)
                    sql = $"SELECT TOP 50 * FROM {typeof(T).Name}s Where [Send] = 0";
                else
                    sql = $"SELECT TOP 50 * FROM {name} Where [Send] = 0";

                return _context.Database.Connection.Query<T>(sql).ToList();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.Message);
                return null;
            }
        }

        public bool BackupDatabase(string cmd)
        {
            try
            {
                _context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, cmd);
                return true;
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "UnitOfWork",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Params = cmd,
                    Method = "UnitOfWork.BackupDatabase"
                };
                CLogJson.Write(li);
                return false;
            }
        }
    }
}
