using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraEditors;
using Kadr.LangResource;

namespace Kadr.Utils
{
    public static class CLang
    {
        private static CultureResurce cr;
        private static ValuesResurceList vres;
        private static Control root;

        public static void Culture()
        {
            //Thread.CurrentThread.CurrentUICulture
        }

        private static bool IsTestInClass(Control contrl, string PropertyName)
        {
            Type type = contrl.GetType();
            var properties = type.GetProperties();
            return properties.Where(obj => obj.Name == PropertyName).FirstOrDefault() == null;
        }

        public static string ToLang(this string key, string frm)
        {
            if (cr.CultureValues == null)
            {
                FormResurceItem fr = In(frm);
                cr.CultureValues = new Dictionary<string, FormResurceItem>();
                cr.CultureValues.Add(CultureInfo.CurrentCulture.Name, fr);
            }

            if (!cr.CultureValues.ContainsKey(CultureInfo.CurrentCulture.Name))
            {
                FormResurceItem fr = In(frm);
                cr.CultureValues.Add(CultureInfo.CurrentCulture.Name, fr);
            }

            cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues.TryGetValue(frm, out vres);
            if (vres?.ControlValues != null )
            {
                if (!vres.ControlValues.TryGetValue(key, out var r0))
                {
                    vres.ControlValues.Add(key, key); 
                    cr.Save();
                }
                else
                {
                    return r0;
                }
            }

            return key;
        }

        public static string GetText(string frm, string key)
        {
            string str;
            if (cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues[frm].ControlValues.TryGetValue(key, out str))
                return str;
            else
                return key;
        }

        public static void SetText(string frm, string key, string value)
        {
            if (!cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues.ContainsKey(frm))
            {
                ValuesResurceList vl = new ValuesResurceList();
                vl.ControlValues = new Dictionary<string, string>();
                cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues.Add(frm, vl);
            };

            if (cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues[frm].ControlValues.ContainsKey(key))
                cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues[frm].ControlValues[key] = value;
            else
                cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues[frm].ControlValues.Add(key, value);
            cr.Save();
        }

        private static FormResurceItem In(string frmName)
        {
            ValuesResurceList vr = new ValuesResurceList();
            vr.ControlValues = new Dictionary<string, string>();

            FormResurceItem fr = new FormResurceItem();
            fr.ResurceValues = new Dictionary<string, ValuesResurceList>();
            fr.ResurceValues.Add(frmName, vr);
            return fr;
        }

        public static void Init(Form frm)
        {
            cr = CultureResurce.Load();

            if (cr.CultureValues == null)
            {
                FormResurceItem fr = In(frm.Name);
                cr.CultureValues = new Dictionary<string, FormResurceItem>();
                cr.CultureValues.Add(CultureInfo.CurrentCulture.Name, fr);
            }

            if (!cr.CultureValues.ContainsKey(CultureInfo.CurrentCulture.Name))
            {
                FormResurceItem fr = In(frm.Name);
                cr.CultureValues.Add(CultureInfo.CurrentCulture.Name, fr);
            }

            root = frm;

            cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues.TryGetValue(frm.Name, out vres);
            if (vres == null)
            {
                vres = new ValuesResurceList();
                vres.ControlValues = new Dictionary<string, string>();
                cr.CultureValues[CultureInfo.CurrentCulture.Name].ResurceValues.Add(frm.Name, vres);
            }

            svWinFormCaption2Xml();

            svContextMenuStrip2Xml();
            svWinFormControl2Xml(typeof(Button));
            svWinFormControl2Xml(typeof(RadioButton));

            svWinFormControl2Xml(typeof(Label));
            svListView2Xml(typeof(ListView));

            svDevLabelControl2Xml(typeof(LabelControl));
            svDevRibbonControl2Xml(typeof(DevExpress.XtraBars.Ribbon.RibbonControl));
            svDevNavBarControl2Xml(typeof(DevExpress.XtraNavBar.NavBarControl));
            svDevGridControl2Xml(typeof(DevExpress.XtraGrid.GridControl));
            svDevSimpleButton2Xml(typeof(DevExpress.XtraEditors.SimpleButton));


            cr.Save();
        }

        private static void svContextMenuStrip2Xml()
        {
            if (root.ContextMenuStrip != null)
            {
                ContextMenuStrip cms = root.ContextMenuStrip;
                foreach (ToolStripMenuItem item in cms.Items)
                {
                    if (item.Text != "" && item.Name != "")
                        if (!vres.ControlValues.ContainsKey(item.Name))
                            vres.ControlValues.Add(item.Name, item.Text);
                        else
                            item.Text = vres.ControlValues[item.Name];
                }
            }
        }

        private static void svDevLabelControl2Xml(Type type)
        {
            var cs = root.GetAllControls(type);
            foreach (var item in cs)
            {
                DevExpress.XtraEditors.LabelControl gc = item as DevExpress.XtraEditors.LabelControl;
                if (gc != null)
                    if (gc.Text != "" && gc.Name != "")
                        if (!vres.ControlValues.ContainsKey(gc.Name))
                            vres.ControlValues.Add(gc.Name, gc.Text);
                        else
                            gc.Text = vres.ControlValues[gc.Name];
            }
        }

        private static void svListView2Xml(Type type)
        {
            var cs = CReflection.GetSelfAndChildrenRecursive(root);
            foreach (var ctrl in cs)
            {
                ListView gc = ctrl as ListView;
                if (gc != null)
                    for (int i = 0; i < gc.Columns.Count; i++)
                    {
                        ColumnHeader ic = gc.Columns[i];
                        if (!vres.ControlValues.ContainsKey(gc.Name + "Columns" + i.ToString()))
                            vres.ControlValues.Add(gc.Name + "Columns" + i.ToString(), ic.Text);
                        else
                            ic.Text = vres.ControlValues[gc.Name + "Columns" + i.ToString()];
                    }
            }
        }

        private static void svWinFormCaption2Xml()
        {
            if (root.Text != "" && root.Name != "")
                if (!vres.ControlValues.ContainsKey(root.Name))
                    vres.ControlValues.Add(root.Name, root.Text);
                else
                    root.Text = vres.ControlValues[root.Name];
        }

        private static void svDevSimpleButton2Xml(Type type)
        {
            var cs = CReflection.GetSelfAndChildrenRecursive(root);
            foreach (var ctrl in cs)
            {
                DevExpress.XtraEditors.SimpleButton gc = ctrl as DevExpress.XtraEditors.SimpleButton;
                if (gc != null)
                    if (gc.Text != "" && gc.Name != "")
                        if (!vres.ControlValues.ContainsKey(gc.Name))
                            vres.ControlValues.Add(gc.Name, gc.Text);
                        else
                            gc.Text = vres.ControlValues[gc.Name];
            }
        }

        private static void svDevGridControl2Xml(Type type)
        {
            var cs = root.GetAllControls(type);
            foreach (var item in cs)
            {
                DevExpress.XtraGrid.GridControl rc = item as DevExpress.XtraGrid.GridControl;
                foreach (DevExpress.XtraGrid.Views.Base.BaseView ri in rc.ViewCollection)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gr = ri as DevExpress.XtraGrid.Views.Grid.GridView;
                    if (gr != null)
                        foreach (DevExpress.XtraGrid.Columns.GridColumn gc in gr.Columns)
                        {
                            if (gc.Caption != "" && gc.Name != "")
                                if (!vres.ControlValues.ContainsKey(gc.Name))
                                    vres.ControlValues.Add(gc.Name, gc.Caption);
                                else
                                    gc.Caption = vres.ControlValues[gc.Name];
                        }

                }
            }
        }

        private static void svDevNavBarControl2Xml(Type type)
        {
            var cs = root.GetAllControls(type);
            foreach (var item in cs)
            {
                DevExpress.XtraNavBar.NavBarControl rc = item as DevExpress.XtraNavBar.NavBarControl;

                foreach (DevExpress.XtraNavBar.NavBarGroup ri in rc.Groups)
                {
                    if (ri.Caption != "" && ri.Name != "")
                        if (!vres.ControlValues.ContainsKey(ri.Name))
                            vres.ControlValues.Add(ri.Name, ri.Caption);
                        else
                            ri.Caption = vres.ControlValues[ri.Name];
                }

                foreach (DevExpress.XtraNavBar.NavBarItem ri in rc.Items)
                {
                    if (ri.Caption != "" && ri.Name != "")
                        if (!vres.ControlValues.ContainsKey(ri.Name))
                            vres.ControlValues.Add(ri.Name, ri.Caption);
                        else
                            ri.Caption = vres.ControlValues[ri.Name];
                }
            }
        }

        private static void svDevRibbonControl2Xml(Type type)
        {
            var cs = root.GetAllControls(type);
            foreach (var item in cs)
            {
                DevExpress.XtraBars.Ribbon.RibbonControl rc = item as DevExpress.XtraBars.Ribbon.RibbonControl;
                foreach (DevExpress.XtraBars.BarItem ri in rc.Items)
                {
                    if (ri.Caption != "" && ri.Name != "")
                    {
                        if (!vres.ControlValues.ContainsKey(ri.Name + "Hint"))
                            vres.ControlValues.Add(ri.Name + "Hint", ri.Hint);
                        else
                        {
                            if (vres.ControlValues[ri.Name + "Hint"] == "")
                                vres.ControlValues[ri.Name + "Hint"] = ri.Hint;
                            else
                                ri.Hint = vres.ControlValues[ri.Name + "Hint"];
                        }

                        if (!vres.ControlValues.ContainsKey(ri.Name))
                            vres.ControlValues.Add(ri.Name, ri.Caption);
                        else
                            ri.Caption = vres.ControlValues[ri.Name];
                    }
                }

                //                                 //rc.PageCategories.TotalCategory.Pages[0]
                //for (int i = 0; i < rc.PageCategories.TotalCategory.Pages.Count; i++)
                //{
                //    var rcc = rc.PageCategories.TotalCategory.Pages[i];

                //    if (rcc.Text != "" && rcc.Name != "")
                //        if (!vres.ControlValues.ContainsKey(rcc.Name))
                //            vres.ControlValues.Add(rcc.Name, rcc.Text);
                //        else
                //            rcc.Text = vres.ControlValues[rcc.Name];

                foreach (DevExpress.XtraBars.Ribbon.RibbonPage rp in rc.Pages)
                {
                    if (rp.Text != "" && rp.Name != "")
                        if (!vres.ControlValues.ContainsKey(rp.Name))
                            vres.ControlValues.Add(rp.Name, rp.Text);
                        else
                            rp.Text = vres.ControlValues[rp.Name];

                    foreach (DevExpress.XtraBars.Ribbon.RibbonPageGroup rg in rp.Groups)
                    {
                        if (rg.Text != "" && rg.Name != "")
                            if (!vres.ControlValues.ContainsKey(rg.Name))
                                vres.ControlValues.Add(rg.Name, rg.Text);
                            else
                                rg.Text = vres.ControlValues[rg.Name];
                    }
                }
                //}
            }

        }

        private static void svWinFormControl2Xml(Type t)
        {
            var cs = root.GetAllControls(t);
            foreach (var item in cs)
            {
                if (item.Text != "" && item.Name != "")
                    if (!vres.ControlValues.ContainsKey(item.Name))
                        vres.ControlValues.Add(item.Name, item.Text);
                    else
                        item.Text = vres.ControlValues[item.Name];
            }
        }

    }
}
