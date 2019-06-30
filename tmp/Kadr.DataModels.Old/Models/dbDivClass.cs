using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using Asbt.Data;
using Asbt.DictionaryDB;
using Asbt.Utils;
using FirebirdSql.Data.FirebirdClient;

namespace Asbt.DataModels
{
    [DataContract]
    public class TbDivClass
    {
        [DataMember]
        public int SpId { get; set; }
        [DataMember]
        public string SpName { get; set; }
        [DataMember]
        public int SpType { get; set; }
        [DataMember]
        public int SpObl { get; set; }
        [DataMember]
        public int Level { get; set; }
    }

    public class tbDivList
    {
        private static List<TbDivClass> uch = null;
        private static List<TbDivClass> obl = null;

        public static List<TbDivClass> GetObl()
        {
            if (obl == null)
            {
                obl = new List<TbDivClass>();
                obl.Add(new TbDivClass() { Level = 1, SpId = 10, SpName = "Тошкент шаҳри" });
                obl.Add(new TbDivClass() {Level=1, SpId = 11, SpName = "Тошкент вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 12, SpName = "Сирдарё вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 13, SpName = "Жиззах вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 14, SpName = "Самарқанд вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 15, SpName = "Фарғона вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 16, SpName = "Наманган вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 17, SpName = "Андижон вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 18, SpName = "Қашқадарё вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 19, SpName = "Сурхондарё вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 20, SpName = "Бухоро вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 21, SpName = "Навоий вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 22, SpName = "Хоразм вилояти" });
                obl.Add(new TbDivClass() {Level=1, SpId = 23, SpName = "Қорақалбоғистон Республикаси" });
            }

            return obl;
        }

        public static List<TbDivClass> GetUcherejdeniya(string obl)
        {
            if (uch==null)
                GetAllUch();

            return uch.Where(x => x.SpObl.ToString() == obl ).ToList();
        }                                  

        public static void GetAllUch()
        {
            if (uch == null)
            {
                uch = new List<TbDivClass>();
                var sql = @"select id,nameuz,turi,obl from sa_kollej";
                try
                {
                    using (var dt = DicoDB.SelectSQL(sql))
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            uch.Add(new TbDivClass()
                            {
                                SpId = row["ID"].ToInt32(),
                                SpName = row["NAMEUZ"].ToStr(),
                                SpType = row["TURI"].ToInt32(),
                                SpObl = row["OBL"].ToInt32(),
                                Level = 2
                            });
                        }
                    }
                }
                catch (Exception exception)
                {
                    CLog.Write(exception.GetAllMessages());
                }
            }
        }
    }
}
