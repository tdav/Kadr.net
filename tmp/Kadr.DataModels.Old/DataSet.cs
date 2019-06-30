using Asbt.Utils;
using System;
using System.Data;
using System.Windows.Forms;


namespace Asbt.Data.KdnDataSetTableAdapters
{
    partial class TBSHATTableAdapter
    {
        public void IU_DT(DataRow dt)
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[3];

            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                command.Parameters[i].Value = (oi[i] != null ||
                                               oi[i] != DBNull.Value ?
                                               oi[i] :
                                               DBNull.Value);
            }

            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

  public  partial class TBFOTOTableAdapter
    {
        public void IU_DT(DataRow dt, string mid = "")
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[2];
            if (mid != "")
                dt["MAINID"] = mid;
            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                if (i == 1)
                    command.Parameters[i].Value = mid;
                else
                command.Parameters[i].Value = (oi[i] != null ||
                                               oi[i] != DBNull.Value ?
                                               oi[i] :
                                               DBNull.Value);
            }

            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

    partial class TBQARINDOSHTableAdapter
    {
        public void IU_DT(DataRow dt, string mid = "")
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[3];
            if (mid != "")
                dt["MAINID"] = mid;
            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                if (i == 1)
                    command.Parameters[i].Value = mid;
                else
                command.Parameters[i].Value = (oi[i] != null ||
                                               oi[i] != DBNull.Value ?
                                               oi[i] :
                                               DBNull.Value);
            }

            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

    partial class TBUNIVERTableAdapter
    {
        public void IU_DT(DataRow dt, string mid = "")
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[4];
            if (mid != "")
                dt["MAINID"] = mid;
            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                if (i == 1)
                    command.Parameters[i].Value = mid;
                else
                command.Parameters[i].Value = (oi[i] != null ||
                                               oi[i] != DBNull.Value ?
                                               oi[i] :
                                               DBNull.Value);
            }

            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

    partial class TBPOVISHKVALTableAdapter
    {
        public void IU_DT(DataRow dt, string mid = "")
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[3];
            if (mid != "")
                dt["MAINID"] = mid;
            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                if (i == 1)
                    command.Parameters[i].Value = mid;
                else
                command.Parameters[i].Value = (oi[i] != null ||
                                               oi[i] != DBNull.Value ?
                                               oi[i] :
                                               DBNull.Value);
            }

            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

    partial class TBATESTATIYATableAdapter
    {
        public void IU_DT(DataRow dt, string mid = "")
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[3];

            if (mid != "")
                dt["MAINID"] = mid;

            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                if (i == 1)
                    command.Parameters[i].Value = mid;
                else
                command.Parameters[i].Value = (oi[i] != null ||
                                               oi[i] != DBNull.Value ?
                                               oi[i] :
                                               DBNull.Value);
            }

            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

    partial class TBDEPUTYTableAdapter
    {
        public void IU_DT(DataRow dt, string mid = "")
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[3];
            if (mid != "")
                dt["MAINID"] = mid;
            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                if (i == 1)
                    command.Parameters[i].Value = mid;
                else
                    command.Parameters[i].Value = (oi[i] != null ||
                                                   oi[i] != DBNull.Value ?
                                                   oi[i] :
                                                   DBNull.Value);
            }
            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

    partial class TBGOSNAGRADITableAdapter
    {
        public void IU_DT(DataRow dt, string mid = "")
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[3];
            if (mid != "")
                dt["MAINID"] = mid;
            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                if (i == 1)
                    command.Parameters[i].Value = mid;
                else
                command.Parameters[i].Value = (oi[i] != null ||
                                               oi[i] != DBNull.Value ?
                                               oi[i] :
                                               DBNull.Value);
            }

            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

    partial class TBMESTORABTableAdapter
    {
        public void IU_DT(DataRow dt, string mid = "")
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand command = this.CommandCollection[3];
            if (mid != "")
                dt["MAINID"] = mid;
            var oi = dt.ItemArray;
            for (int i = 0; i < oi.Length; i++)
            {
                if (i == 1)
                    command.Parameters[i].Value = mid;
                else
                command.Parameters[i].Value = (oi[i] != null ||
                                               oi[i] != DBNull.Value ?
                                               oi[i] :
                                               DBNull.Value);
            }

            try
            {
                if (((command.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    command.Connection.Open();
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }

    public partial class TbMainTableAdapter
    {
        
        public void IU_DT(KdnDataSet.TbMainDataTable dt)
        {
            global::FirebirdSql.Data.FirebirdClient.FbCommand cmd = this.CommandCollection[3];

            var oi = dt.Rows[0].ItemArray; for (int i = 0; i < oi.Length; i++)
            {
                cmd.Parameters[i].Value = (oi[i] != null || oi[i] != DBNull.Value ? oi[i] : DBNull.Value);
            }

            try
            {
                if (((cmd.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
                {
                    cmd.Connection.Open();
                }
              var k=  cmd.ExecuteNonQuery();
                MessageBox.Show(k.ToString());
            }
            catch (Exception ee)
            {
                CLog.Write(ee.GetAllMessages());
            }
        }
    }
}

namespace Asbt.Data
{


    public partial class KdnDataSet
    {
    }
}
