using System;
using System.Collections.Generic;
using System.IO;
using Apteka.Utils;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Kadr.GlobalVars;

namespace Kadr.UtilsUI.GridFunctions
{
    public class ReportGridForms
    {
        public void Save(GridView v)
        {
            if (v.Columns.Count == 0) return;
            var Name = v.Tag.ToString(); ;

            var config = new List<GridColunmConfigItem>();

            foreach (GridColumn item in v.Columns)
            {
                var gc = new GridColunmConfigItem();

                gc.IsGroups = item.GroupIndex != -1;

                if (item.SummaryItem.SummaryType != SummaryItemType.None)
                {
                    gc.IsAgrs = true;
                    gc.SumType = item.SummaryItem.SummaryType;
                }

                gc.DateType = item.ColumnType.FullName;
                gc.Width = item.Width;
                gc.Name = item.Name;
                gc.FieldName = item.FieldName;
                gc.DisplayName = item.Caption;
                gc.ColIndex = item.AbsoluteIndex;
                gc.Visible = item.Visible;
                config.Add(gc);
            }

            var s = Newtonsoft.Json.JsonConvert.SerializeObject(config, Newtonsoft.Json.Formatting.Indented);
            CFile.SaveFile(s, Vars.RepConfigPath + $"rf{Name}.json");
        }

        public void Load(GridView v, string name)
        {
            var Name = name;
            v.Tag = name;

            try
            {
                 v.BeginUpdate();
                if (!File.Exists(Vars.RepConfigPath + $"rf{Name}.json")) return;

                var s = CFile.GetFileContents(Vars.RepConfigPath + $"rf{Name}.json");

                var config = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GridColunmConfigItem>>(s);              

                for (int i = 0; i < config.Count; i++)
                {
                    var c = v.Columns[config[i].ColIndex];
                    if (c == null) return;

                    if (config[i].IsGroups)
                    {
                        c. GroupIndex = i;
                    }

                    if (config[i].IsAgrs)
                    {
                      //  c.SummaryItem.FieldName = config[i].ColunmName;
                        c.SummaryItem.SummaryType = config[i]. SumType;
                        c.SummaryItem.DisplayFormat = GetNameArg(config[i].SumType);
                    }
                    c.Width = config[i].Width;
                }
            }
            catch (Exception ee)
            {
                var li = new LogItem
                {
                    App = "Apteka.UtilsUI",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "ReportGridForms.ReportGridForms"
                };
                CLogJson.Write(li);
            }

            finally
            {
                v.EndUpdate();
            }
        }

        private static string GetNameArg(SummaryItemType func)
        {
            switch (func)
            {
                case SummaryItemType.Sum:
                    return "Сумм. {0:#.##}";
                case SummaryItemType.Min:
                    return "Мин. {0:#.##}";
                case SummaryItemType.Max:
                    return "Макс. {0:#.##}";
                case SummaryItemType.Count:
                    return "Кол. {0:#.##}";
                case SummaryItemType.Average:
                    return "Сред. {0:#.##}";
            }
            return "";
        }
    }
}
