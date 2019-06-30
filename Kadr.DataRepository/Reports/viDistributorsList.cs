using Apteka.Utils;
using Kadr.DataModels.Utils;
using Kadr.Models;
using System;
using System.Data;
using System.Linq;

namespace Kadr.DataModels.Reports
{
    public class viDistributorsList
    {
        public static DataTable Run( DateTime d1, DateTime d2)
        {
            var sql = @"SELECT 
                          spDistributors.OrganizationName AS [Дистрибьюторы]
                         ,spDrugStores.Name AS Аптека
                         ,tbDocs.CreateDate AS [Дата продажы]
                         ,dbo.DecDrugRealName(tbDocItems.DrugId) AS Товар
                         ,tbDocs.TotalAmount AS Сумма
                         ,tbDocs.TotalDrugs AS [Кол. товара] 
                        FROM dbo.tbDocs
                        INNER JOIN dbo.spDrugStores
                          ON tbDocs.DrugStoreId = spDrugStores.Id
                        INNER JOIN dbo.tbDocItems
                          ON tbDocItems.DocumentId = tbDocs.Id
                        INNER JOIN dbo.spDistributors
                          ON tbDocs.DistributorId = spDistributors.Id
                        WHERE tbDocs.CreateDate BETWEEN '{0}' AND '{1}'
                        ORDER BY spDistributors.OrganizationName, tbDocs.TotalDrugs";

            using (var db = new KadrDbContext())
            {
                sql = string.Format(sql, d1.ToMsSqlDate(1), d2.ToMsSqlDate(2));
                return db.Database.Connection.Select(sql);
            }
        }
    }
}
