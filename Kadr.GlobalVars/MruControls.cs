using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Kadr.GlobalVars;

namespace Kadr.Data
{
    public static class MruItemExtensions
    {
        public static List<string> ToList(this MRUEditItemCollection inParam)
        {
            var ls = new List<string>();
            var s = "";
            foreach (var item in inParam)
            {
                s = item.ToString();
                if (s != "")
                    ls.Add(s);
            }
            return ls;
        }
    }

    public class MruStorge
    {
        public string ControlName { get; set; }
        public List<string> Values { get; set; }
    }

    public class GlobaleStorge
    {
        public List<MruStorge> StValues { get; set; }
    }


    public static class MruControls
    {
        public static void LoadItems(MRUEdit c)
        {
            try
            {
                if (!File.Exists(Vars.CurPath + "\\MruControlsVal.xml")) return;
                var gs = CSerializer.ObjectXMLSerializer<GlobaleStorge>.Load(Vars.CurPath + "\\MruControlsVal.xml");
                var item = gs.StValues.FirstOrDefault(x => x.ControlName == c.Name);
                if (item != null)
                {
                    c.Properties.Items.AddRange(item.Values);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void SaveItems(MRUEdit c)
        {
            try
            {
                if (File.Exists(Vars.CurPath + "\\MruControlsVal.xml"))
                {
                    var gs =
                        CSerializer.ObjectXMLSerializer<GlobaleStorge>.Load(Vars.CurPath + "\\MruControlsVal.xml");
                    var item = gs.StValues.FirstOrDefault(x => x.ControlName == c.Name);
                    if (item != null)
                    {
                        item.Values = c.Properties.Items.ToList();
                    }
                    else
                    {
                        gs.StValues.Add(new MruStorge {ControlName = c.Name, Values = c.Properties.Items.ToList()});
                    }
                    CSerializer.ObjectXMLSerializer<GlobaleStorge>.Save(gs, Vars.CurPath + "\\MruControlsVal.xml");
                }
                else
                {
                    var gs = new GlobaleStorge();
                    gs.StValues = new List<MruStorge>();
                    gs.StValues.Add(new MruStorge {ControlName = c.Name, Values = c.Properties.Items.ToList()});
                    CSerializer.ObjectXMLSerializer<GlobaleStorge>.Save(gs, Vars.CurPath + "\\MruControlsVal.xml");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}