using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace Apteka.Utils.DataBase
{
    public static class CDatabaseExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> source)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();

            DataTable output = new DataTable();

            foreach (var prop in properties)
            {
                output.Columns.Add(prop.Name, typeof(string));
            }

            foreach (var item in source)
            {
                DataRow row = output.NewRow();

                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item, null);
                }

                output.Rows.Add(row);
            }

            return output;
        }

        public static string ToJson(this IDataReader source)
        {
            int i = 0;
            int c = source.FieldCount;
            int l = source.RecordsAffected;
            var ao = new object[c];

            var sb = new StringBuilder();
            sb.Append("[");
                        
            while (source.Read())
            {
                sb.Append("{");
                source.GetValues(ao);
                for (int j = 0; j < c; j++)
                {
                    sb.Append($"{source.GetName(j).ToDQuote()}:{ao[j].ToString().Replace('"', '-').ToDQuote() },");
                }
                sb.Append("},");
                i++;
            }
            sb.Append("]");
            source.Close();
            return sb.ToString().Replace(char.Parse(@"\"), '/');
        }

        public static string ToJson(this DataTable table)
        {
            var jsonString = new StringBuilder();
            jsonString.Append("[");
            if (table.Rows.Count > 0)
            {
                //jsonString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    jsonString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            jsonString.Append(
                                $"{table.Columns[j].ColumnName.ToDQuote()}:{table.Rows[i][j].ToStr().Replace('"', '-').ToDQuote()},");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            jsonString.Append(
                                $"{table.Columns[j].ColumnName.ToDQuote()}:{table.Rows[i][j].ToStr().Replace('"', '-').ToDQuote()}");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        jsonString.Append("}");
                    }
                    else
                    {
                        jsonString.Append("},");
                    }
                }

                //jsonString.Append("]");
            }
            else
            {
                jsonString.Append('"');
                jsonString.Append('"');
            }
            jsonString.Append("]");
            return jsonString.ToString().Replace(char.Parse(@"\"), '/');
        }


        public static string ToJson(this DataSet tables)
        {
            var str = "{";


            for (int i = 0; i < tables.Tables.Count; i++)
            {
                if (i != 0) str += ",";
                var st = tables.Tables[i].ToJson();

                if (!string.IsNullOrEmpty(st))
                    str += tables.Tables[i].TableName.ToDQuote() + ":" + st;
            }

            str += "}";

            return str;
        }

        public static string ToExcel2(this DataTable dt)
        {
            StringBuilder str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`>");
            str.Append("<tr>");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                str.Append("<td><b><font face=Arial Narrow >");
                str.Append(dt.Columns[i].ToString().ToUpper());
                str.Append("</font></b></td>");
            }
            str.Append("</tr>");

            for (int i = 0; i < (dt.Rows.Count); i++)
            {
                str.Append("<tr>");
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    str.Append("<td>");
                    str.Append(dt.Rows[i][j] != null ? Convert.ToString(dt.Rows[i][j]) : "");
                    str.Append("</td> ");
                }
                str.Append("</tr>");
            }
            str.Append("</table>");

            return str.ToString();
        }
    }
}
