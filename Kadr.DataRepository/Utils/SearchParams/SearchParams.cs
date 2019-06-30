using Apteka.Utils;
using Kadr.DataRepository.Utils;
using System;
using System.Collections.Generic;

namespace Kadr.Models.Utils
{
    public class SearchParam
    {
        public string FieldName { get; set; }

        public TypeEnum ParamType { get; set; }

        public СonditionsSearchEnum Conditions { get; set; }

        public object[] Value { get; set; }

        public string GetSqlParam()
        {
            string res = string.Empty;

            switch (Conditions)
            {
                case СonditionsSearchEnum.csEqually:
                    switch (ParamType)
                    {
                        case TypeEnum.teNumeric:
                            res = $"{FieldName } = {Value[0].ToSearchParamsNumeric()}";
                            break;
                        case TypeEnum.teString:
                            res = $"{FieldName } = '{Value[0]}'";
                            break;
                        case TypeEnum.teDate:
                            res = $"{FieldName } = '{Value[0].ToMsSqlDate()}'";
                            break;
                    }
                    break;
                case СonditionsSearchEnum.csLike:
                    switch (ParamType)
                    {
                        case TypeEnum.teNumeric:
                            throw new Exception("Numericда BETWEEN булмайди");
                        case TypeEnum.teString:
                            res = $"{FieldName } LIKE '%{Value[0]}%'";
                            break;
                        case TypeEnum.teDate:
                            throw new Exception("Dateда BETWEEN булмайди");
                    }
                    break;
                case СonditionsSearchEnum.csBetween:
                    var mask = "";
                    if (Value.Length == 3)
                        mask = Value[2].ToStr();

                    if (Value[0].ToStr()?.Length == 0 && Value[1].ToStr()?.Length == 0)
                    {
                        res = "";
                        break;
                    }

                    if (Value[0].ToStr()?.Length == 0)
                        Value = new object[] { Value[1] };

                    if (Value.Length > 1 && Value[1].ToStr()?.Length == 0)
                        Value = new object[] { Value[0] };

                    if (Value.Length == 1)
                    {
                        switch (ParamType)
                        {
                            case TypeEnum.teNumeric:
                                res = $"{FieldName } = {Value[0]}";
                                break;
                            case TypeEnum.teString:
                                res = $"{FieldName } = '{Value[0]}'";
                                break;
                            case TypeEnum.teDate:
                                res = $"{FieldName } = {Value[0].ToMsSqlDate()}";
                                break;
                            case TypeEnum.teSqlParam:
                                res = $"{FieldName } = {Value[0]} {mask}";
                                break;
                        }
                    }
                    else
                    {
                        switch (ParamType)
                        {
                            case TypeEnum.teNumeric:
                                res = $"{FieldName } BETWEEN {Value[0]} and {Value[1]}";
                                break;
                            case TypeEnum.teString:
                                throw new Exception("Stringда BETWEEN булмайди");
                            case TypeEnum.teDate:
                                res = $"{FieldName } BETWEEN {Value[0].ToMsSqlDate(1)} and {Value[1].ToMsSqlDate(2)}";
                                break;
                            case TypeEnum.teSqlParam:
                                res = $"{FieldName } BETWEEN {Value[0]}{mask} and {Value[1]}{mask}";
                                break;
                        }
                    }
                    break;

                case СonditionsSearchEnum.csGreaterEqual:
                    switch (ParamType)
                    {
                        case TypeEnum.teNumeric:
                            res = $"{FieldName } >= {Value[0]}";
                            break;
                        case TypeEnum.teString:
                            throw new Exception("Stringда >= булмайди");
                        case TypeEnum.teDate:
                            res = $"{FieldName } >= {Value[0].ToMsSqlDate()}";
                            break;
                    }
                    break;
                case СonditionsSearchEnum.csLessEqual:
                    switch (ParamType)
                    {
                        case TypeEnum.teNumeric:
                            res = $"{FieldName } <= {Value[0]}";
                            break;
                        case TypeEnum.teString:
                            throw new Exception("Stringда <= булмайди");
                        case TypeEnum.teDate:
                            res = $"{FieldName } <= {Value[0].ToMsSqlDate()}";
                            break;
                    }
                    break;
                case СonditionsSearchEnum.csIn:
                    switch (ParamType)
                    {
                        case TypeEnum.teNumeric:
                        case TypeEnum.teString:
                        case TypeEnum.teDate:
                            string vsn = ArrayToString();
                            res = $"{FieldName } IN ({vsn})";
                            break;
                    }
                    break;
                case СonditionsSearchEnum.csNotIn:
                    switch (ParamType)
                    {
                        case TypeEnum.teNumeric:
                        case TypeEnum.teString:
                        case TypeEnum.teDate:
                            string vsn = ArrayToString();
                            res = $"{FieldName } NOT IN ({vsn})";
                            break;
                    }
                    break;
                case СonditionsSearchEnum.csIsNull:
                    switch (ParamType)
                    {
                        case TypeEnum.teNumeric:
                        case TypeEnum.teString:
                        case TypeEnum.teDate:
                            res = $"{FieldName } IS NULL";
                            break;
                    }
                    break;
                case СonditionsSearchEnum.csInNotNull:
                    switch (ParamType)
                    {
                        case TypeEnum.teNumeric:
                        case TypeEnum.teString:
                        case TypeEnum.teDate:
                            res = $"{FieldName } IS NOT NULL";
                            break;
                    }
                    break;
            }
            return res;
        }

        private string ArrayToString()
        {
            string res = "";
            switch (ParamType)
            {
                case TypeEnum.teNumeric:
                    for (int i = 0; i < Value.Length; i++)
                    {
                        res = res + Value[i].ToStr() + (i != Value.Length ? "," : "");
                    }
                    return res;

                case TypeEnum.teString:
                    for (int i = 0; i < Value.Length; i++)
                    {
                        res = res + Value[i].ToStr().ToDQuote() + (i != Value.Length ? "," : "");
                    }
                    return res;

                case TypeEnum.teDate:
                    for (int i = 0; i < Value.Length; i++)
                    {
                        res = res + Value[i].ToMsSqlDate() + (i != Value.Length ? "," : "");
                    }
                    return res;
            }
            throw new Exception("Берилган кийматлар тури нотугри");
        }
    }

    public class SearchParamList : List<SearchParam>
    {
        public SearchParamsRes GetSql()
        {
            string res = "", orderby = "", top = "";
            SearchParamList ls = this;

            for (int i = 0; i < ls.Count; i++)
            {
                bool IsNotEmpty = true;

                if (ls[i].ParamType == TypeEnum.teSqlParam && ls[i].Conditions == СonditionsSearchEnum.csOrderBy)
                {
                    orderby = $", {ls[i].FieldName}";
                    continue;
                }

                if (ls[i].ParamType == TypeEnum.teSqlParam && ls[i].Conditions == СonditionsSearchEnum.csFetchTop)
                {
                    top = $"TOP {ls[i].FieldName} {Environment.NewLine}";
                    continue;
                }

                if (ls[i].Value != null)
                {
                    var index = 0;
                    foreach (object item in ls[i].Value)
                    {
                        if (ls[i].ParamType == TypeEnum.teSqlParam && index == 2)
                        {
                            IsNotEmpty = true;
                            break;
                        }

                        if (item.ToStr()?.Length != 0)
                        {
                            IsNotEmpty = false;
                            break;
                        }

                        index++;
                    }
                }
                if (IsNotEmpty) continue;

                res = res + ls[i].GetSqlParam() + (i != ls.Count ? " AND " : "") + Environment.NewLine;
            }

            if (!string.IsNullOrEmpty(orderby))
                orderby = orderby.Remove(0, 1);

            return new SearchParamsRes()
            {
                TOP = top,
                ORDER = orderby,
                WHERE = res.Length > 0 ? res.Substring(0, res.Length - 6) : ""
            };
        }
    }
}
