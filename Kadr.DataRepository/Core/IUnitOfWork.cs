using Kadr.Models.Entity;
using System;
using System.Collections.Generic;

namespace Kadr.Models.Core
{
    public interface IUnitOfWork : IDisposable
    {
        #region Declare
        IStatusRepository Status { get; }
        IRoleRepository Role { get; }

        IAccessListRepository AccessList { get; }

        IAtestatiyaRepository Atestatiya { get; }
        IDbstructRepository Dbstruct { get; }
        IDeputyRepository Deputy { get; }
        IPhotoRepository Photo { get; }
        IGosnagradiRepository Gosnagradi { get; }
        IMainRepository Main { get; }
        IMestorabRepository Mestorab { get; }
        IOperatorRepository Operator { get; }
        IPovishkvalRepository Povishkval { get; }
        IQarindoshRepository Qarindosh { get; }
        ISetupRepository Setup { get; }
        IShatRepository Shat { get; }
        IUniverRepository Univer { get; }
        IUserRepository User { get; }

        ISpListRepository Sps { get; }

        #endregion

        int Complete();

        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();

        int UpdDel(string sql, string table, string param);

        object ExecSql(string sql);

        List<T> GetListToServer<T>(string name = "");

        bool BackupDatabase(string file);
    }
}
