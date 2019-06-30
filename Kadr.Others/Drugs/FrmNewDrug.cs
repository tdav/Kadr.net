using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Apteka.Models.Core;
using Apteka.Models.Entity;
using Apteka.Utils;
using Apteka.UtilsUI;

namespace Apteka.Others
{
    public partial class FrmNewDrug : DevExpress.XtraEditors.XtraForm
    {
        private spDrug drug;
        private IUnitOfWork db;

        public FrmNewDrug(spDrug d)
        {
            InitializeComponent();

            db = new UnitOfWork();
            FormClosed += (s, e) => { db.Dispose(); };

            lb1.Visible = false;
            lb2.Visible = false;

            if (d != null)
            {
                drug = d;
                SetData();
            }
            else
            {
                drug = new spDrug();
                drug.CreateDate = DateTime.Now;
                drug.CreateUser = Vars.UserId;
                drug.Status = 1;
                drug.Barcode = Vars.BarcodeEmpty;
            }

            cbUnit.Properties.DataSource = db.Unit.GetSp();
            cbManufacturer.Properties.DataSource = db.Manufacturer.GetSp();
            cbDrugCategory.Properties.DataSource = db.DrugCategory.GetSp();
            cbPharmGroup.Properties.DataSource = db.PharmGroup.GetSp();

            CLang.Init(this);
        }

        public void SetData()
        {
            edBarcode.Text = drug.Barcode;
            edName.Text = drug.Name;
            edDoza.Text = drug.Dose;
            edInternationalName.Text = drug.InternationalName;
            cbDrugCategory.EditValue = drug.DrugCategoryId;
            cbManufacturer.EditValue = drug.ManufacturerId;
            cbPharmGroup.EditValue = drug.PharmGroupId;
            edPiece.Text = drug.Piece.ToString();
            cbUnit.EditValue = drug.UnitId;
            pcPhoto.Image = LoadImage(drug.Photo);

            edSumText.Text = drug.Description;

            if (!string.IsNullOrWhiteSpace(drug.PriceManufacturer))
            {
                lb1.Visible = true;
                lb2.Visible = true;
                lb2.Text = drug.PriceManufacturer;
            }
        }

        private Image LoadImage(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename)) return null;

            var fi = new FileInfo(filename);

            if (!File.Exists(Vars.ImagesPath + filename))
            {
                AlertMessage.ShowError("Рисунок лекарства не найдено".ToLang(this.Name));
                return null;
            } 

            return Image.FromFile(Vars.ImagesPath + filename);
        }

        public spDrug GetData()
        {
            var mes = "Неправильное значения".ToLang(this.Name);
            dx.ClearErrors();

            drug.Barcode = edBarcode.Text;
            drug.Name = edName.Text;
            drug.InternationalName = edInternationalName.Text;
            drug.Dose = edDoza.Text;

            var s = edSumText.Text;

            while (s.IndexOf("  ") > 0)
                s = s.Replace("  ", " ");

            drug.Description = s;


            if (edName.Text == "")
            {
                dx.SetError(edName, mes);
                return null;
            }

            //if (edDoza.Text == "")
            //{
            //    dxErrorProvider1.SetError(edDoza, mes);
            //    return null;
            //}

            if (s=="")
            {
                dx.SetError(edSumText, mes);
                return null;
            }

            if (TryConvert.ToInt(edPiece.Text, out var p) && p > 0)
            {
                drug.Piece = p;
            }
            else
            {
                dx.SetError(edPiece, mes);
                return null;
            }


            if (TryConvert.ToGuid(cbDrugCategory.EditValue, out var g))
                drug.DrugCategoryId = g;

            if (TryConvert.ToGuid(cbPharmGroup.EditValue, out g))
                drug.PharmGroupId = g;


            if (TryConvert.ToGuid(cbManufacturer.EditValue, out g))
            {
                drug.ManufacturerId = g;
            }
            else
            {
                dx.SetError(cbManufacturer, mes);
                return null;
            }


            if (TryConvert.ToGuid(cbUnit.EditValue, out var gp) )
            {
                drug.UnitId = gp;
            }
            else
            {
                dx.SetError(cbUnit, mes);
                return null;
            }

            if (pcPhoto.Image != null)
            {
                var filename = Guid.NewGuid().ToString() + ".png";
                pcPhoto.Image.Save(Vars.ImagesPath + filename);
                drug.Photo = filename;
            }

            return drug;
        }

        private void OnBtnSpListAdd(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmNewSp f;
            try
            {
                if (e.Button.Index == 1)
                {
                    int i = e.Button.Tag.ToInt();

                    switch (i)
                    {
                        case 1:
                            var fm = new FrmNewManufacturer();

                            if (!string.IsNullOrWhiteSpace(drug.PriceManufacturer))
                            {
                                fm.edName.Text = drug.PriceManufacturer;
                            }

                            if (fm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                cbManufacturer.Properties.DataSource = db.Manufacturer.GetSp();
                                AlertMessage.Show("Данные успешно сохранены".ToLang(this.Name));
                            }
                            break;

                        case 2:
                            f = new FrmNewSp();
                            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                var name = f.edName.Text;
                                if (!string.IsNullOrWhiteSpace(name))
                                {
                                    var ss = new spDrugCategory();
                                    ss.Id = Guid.NewGuid();
                                    ss.Name = name;
                                    ss.Status = 1;
                                    ss.CreateUser = Vars.UserId;
                                    ss.CreateDate = DateTime.Now;
                                    db.DrugCategory.Add(ss);
                                    db.Complete();
                                    cbDrugCategory.Properties.DataSource = db.DrugCategory.GetSp();
                                    AlertMessage.Show("Данные успешно сохранены".ToLang(this.Name));
                                }
                            }
                            f.Dispose();
                            break;

                        case 3:
                            f = new FrmNewSp();
                            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                var name = f.edName.Text;
                                if (!string.IsNullOrWhiteSpace(name))
                                {
                                    var sc = new spPharmGroup();

                                    sc.Id = Guid.NewGuid();
                                    sc.Name = name;
                                    sc.Status = 1;
                                    sc.CreateUser = Vars.UserId;
                                    sc.CreateDate = DateTime.Now;

                                    db.PharmGroup.Add(sc);
                                    db.Complete();
                                    cbPharmGroup.Properties.DataSource = db.PharmGroup.GetSp();
                                    AlertMessage.Show("Данные успешно сохранены".ToLang(this.Name));
                                }
                            }
                            f.Dispose();
                            break;

                        case 4:
                            f = new FrmNewSp();
                            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {
                                var name = f.edName.Text;
                                if (!string.IsNullOrWhiteSpace(name))
                                {
                                    var su = new spUnit();
                                    su.Id = Guid.NewGuid();
                                    su.Name = name;
                                    su.Status = 1;
                                    su.CreateUser = Vars.UserId;
                                    su.CreateDate = DateTime.Now;
                                    db.Unit.Add(su);
                                    db.Complete();
                                    cbUnit.Properties.DataSource = db.Unit.GetSp();
                                    AlertMessage.Show("Данные успешно сохранены".ToLang(this.Name));
                                }
                            }
                            f.Dispose();
                            break;
                    }
                }
            }
            catch (System.Exception ee)
            {
                var li = new LogItem
                {
                    App = "Sklad",
                    Stacktrace = ee.GetStackTrace(5),
                    Message = ee.GetAllMessages(),
                    Method = "FrmProductList.OnBtnSpListAdd"
                };
                CLogJson.Write(li);
                AlertMessage.ShowError("Ошибка при сохранении".ToLang(this.Name));
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            dialog.Title = "Please select an image file to encrypt.".ToLang(this.Name);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fi = new FileInfo(dialog.FileName);

                if (fi.Length >= 100000)
                {
                    MessageBoxDev.ShowError("Размер файла больше 100кб.".ToLang(this.Name));
                    return;
                }

                pcPhoto.LoadAsync(dialog.FileName);
            }           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var p = GetData();

            if (p == null) return;

            if (p.Id == Guid.Empty)
            {
                p.Id = Guid.NewGuid();
                db.Drugs.Add(p);
            }
            else
            {
                p.UpdateUser = Vars.UserId;
                p.UpdateDate = DateTime.Now;
                db.Drugs.Update(p, p.Id);
            }

            db.Complete();
            AlertMessage.Show("Данные успешно сохранены".ToLang(this.Name));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void OnSumTextValueChanged(object sender, EventArgs e)
        {
            //Nazvanie, yedinica izmerenie, doza, № skolko v upokovke.
            edSumText.Text = $"{edName.Text} {cbUnit.Text} {edDoza.Text} №{edPiece.Text}";
        }

        private void FrmNewDrug_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.F9:
                    btnSave.PerformClick();
                    break;
            }
        }
    }
}