using System;
using System.Linq;
using System.Windows.Forms;
using Apteka.Utils;
using DevExpress.XtraEditors.DXErrorProvider;

namespace Kadr.CommonControls
{
    public class PValidation : DXValidationProvider
    {
        public ValidationNumberNotEmpty RuleNumberNotEmpty()
        {
            return new ValidationNumberNotEmpty("Фақат сон киритилиш лозим");
        }

        public ValidationDateBirthEmpty RuleDateBirthEmpty()
        {
            return new ValidationDateBirthEmpty("Туғилган санаси нотуғри киритилган");
        }

        public ValidationDateBirthNotEmpty RuleDateBirthNotEmpty()
        {
            return new ValidationDateBirthNotEmpty("Туғилган санаси нотуғри киритилган");
        }

        public ValidationRuleDateNotEmpty RuleDate()
        {
            return new ValidationRuleDateNotEmpty("Мажбурий сана, санани тўғри киритинг");
        }

        public ValidationNotEmpty RuleNotEmpty()
        {
            return new ValidationNotEmpty("Тулдирилиш лозим бўлган майдон, илтимос маълумот киритинг");
        }

        public ValidationNotEmptyNotZero NotEmptyNotZero()
        {
            return new ValidationNotEmptyNotZero("Тулдириш лозим бўлган майдон, нольдан катта сон киритинг");
        }

        public ValidationEmailEmpty EmailEmpty()
        {
            return new ValidationEmailEmpty("Возможно не корректный ввод e-mail");
        }

        public ValidationNotEmptyIfUzb RuleNotEmptyIfUzb(string inCountry)
        {
            return new ValidationNotEmptyIfUzb("Тулдирилиш лозим бўлган майдон, илтимос маълумот киритинг", inCountry);
        }

        public ValidationNotEmptyFioCir RuleNotEmptyFioCir(string inSurname, string inName, string inPatronym)
        {
            return new ValidationNotEmptyFioCir("Кирилда Фамилия исми ёки шарифи киритилса тўлиқ киритиш лозим",
                inSurname, inName, inPatronym);
        }

        public ValidationSedeniEmpty RuleSedeniEmpty(string val)
        {
            return new ValidationSedeniEmpty("Автобус ўриндиқлар сони кўрсатилмаган...", val);
        }

        public ValidationPowerEmpty RulePowerEmpty()
        {
            return new ValidationPowerEmpty("АМТ от кучи кўрсатилмаган...");
        }

        public ValidationMassEmpty RuleMassEmpty(string val)
        {
            return new ValidationMassEmpty("Юк кўтариш қобилияти кўрсатилмаган...", val);
        }

        public ValidationVinCodeEmpty RuleVinCodeEmpty(int AmtYear)
        {
            return new ValidationVinCodeEmpty("АМТ VIN код кўрсатилмаган ёки Нотўғри кўрсатилган" +
                                              Environment.NewLine + " 17тадан кам бўлмаслиги керак", AmtYear);
        }

        public ValidationTexpNumEmpty RuleTexpNumEmpty()
        {
            return new ValidationTexpNumEmpty("Тех. паспорт рақами нотўғри кўрсатилган...");
        }

        public class ValidationNumberNotEmpty : ValidationRule
        {
            public ValidationNumberNotEmpty(String mess)
            {
                ErrorText = mess;
                ErrorType = ErrorType.Critical;
            }

            public override bool Validate(Control control, object value)
            {
                if (!control.Visible) return true;
                if (value.ToString().Trim().Length == 0) return false;
                for (var i = 0; i < value.ToString().Length; i++)
                    if (CTransliter.CheckNumber(value.ToString()[i])) return false;
                return true;
            }
        }

        public class ValidationDateBirthEmpty : ValidationRule
        {
            public ValidationDateBirthEmpty(String mess)
            {
                ErrorText = mess;
                ErrorType = ErrorType.Critical;
            }

            public override bool Validate(Control control, object value)
            {
                if (!control.Visible) return true;
                value = control.Text.Replace("XX.XX", "01.01");
                if (value == null) return true;
                var str = value.ToString();
                DateTime birth_dt;
                try
                {
                    birth_dt = Convert.ToDateTime(str);
                }
                catch (Exception)
                {
                    return false;
                }
                if (birth_dt.CompareTo(DateTime.Today) > 0) return false;
                if (birth_dt.CompareTo(DateTime.Today.AddYears(-150)) < 0) return false;
                return true;
            }
        }

        public class ValidationDateBirthNotEmpty : ValidationRule
        {
            public ValidationDateBirthNotEmpty(String mess)
            {
                ErrorText = mess;
                ErrorType = ErrorType.Critical;
            }

            public override bool Validate(Control control, object value)
            {
                if (!control.Visible) return true;
                value = control.Text.Replace("XX.XX", "01.01");
                if (value == null) return false;
                var str = value.ToString();
                DateTime birth_dt;
                try
                {
                    birth_dt = Convert.ToDateTime(str);
                }
                catch (Exception)
                {
                    return false;
                }
                if (birth_dt.CompareTo(DateTime.Today) > 0) return false;
                if (birth_dt.CompareTo(DateTime.Today.AddYears(-150)) < 0) return false;
                return true;
            }
        }

        public class ValidationRuleDateNotEmpty : ValidationRule
        {
            public ValidationRuleDateNotEmpty(String mess)
            {
                ErrorText = mess;
                ErrorType = ErrorType.Critical;
            }

            public override bool Validate(Control control, object value)
            {
                if (!control.Visible) return true;
                if (value == null) return false;
                var str = value.ToString();
                DateTime birth_dt;
                try
                {
                    birth_dt = Convert.ToDateTime(str);
                }
                catch (Exception)
                {
                    return false;
                }
                if (birth_dt.CompareTo(DateTime.Today) < 0) return false;
                if (birth_dt.CompareTo(DateTime.Today.AddYears(100)) > 0) return false;
                return true;
            }
        }

        public class ValidationNotEmpty : ValidationRule
        {
            public ValidationNotEmpty(String mess)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
            }

            public override bool Validate(Control control, object value)
            {
                if ((control.Visible) && (control.Enabled))
                {
                    if (value == null) return false;
                    if (value.ToString().Trim().Length == 0) return false;
                    return true;
                }
                return true;
            }
        }

        public class ValidationNotEmptyNotZero : ValidationRule
        {
            public ValidationNotEmptyNotZero(String mess)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
            }

            public override bool Validate(Control control, object value)
            {
                if ((control.Visible) && (control.Enabled))
                {
                    if (value == null) return false;
                    if (value.ToString() == "0") return false;
                    return true;
                }
                return true;
            }
        }

        public class ValidationEmailEmpty : ValidationRule
        {
            public ValidationEmailEmpty(String mess)
            {
                ErrorType = ErrorType.Warning;
                ErrorText = mess;
            }

            public override bool Validate(Control control, object value)
            {
                if (value == null) return true;
                if (value.ToString().Trim().Length == 0) return true;
                return ((value.ToString().Contains('@')) && (value.ToString().Contains('.')));
            }
        }

        public class ValidationNotEmptyIfUzb : ValidationRule
        {
            private readonly string CurCountry = string.Empty;

            public ValidationNotEmptyIfUzb(String mess, String inCountry)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
                CurCountry = inCountry;
            }

            public override bool Validate(Control control, object value)
            {
                if ((control.Visible) && (control.Enabled))
                {
                    if ((CurCountry == "182") && (value == null)) return false;
                    if ((CurCountry == "182") && (value.ToString().Length == 0)) return false;
                    return true;
                }
                return true;
            }
        }

        public class ValidationNotEmptyFioCir : ValidationRule
        {
            private readonly string CurName = string.Empty;
            private readonly string CurPatronym = string.Empty;
            private readonly string CurSurname = string.Empty;

            public ValidationNotEmptyFioCir(String mess, String inSurname, String inName, String inPatronym)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
                CurSurname = inSurname;
                CurName = inName;
                CurPatronym = inPatronym;
            }

            public override bool Validate(Control control, object value)
            {
                if ((control.Visible) && (control.Enabled))
                {
                    if (((CurSurname != "") || (CurName != "") || (CurPatronym != "")) && (value == null)) return false;
                    if (((CurSurname != "") || (CurName != "") || (CurPatronym != "")) && (value.ToString().Length == 0))
                        return false;
                    return true;
                }
                return true;
            }
        }

        public class ValidationSedeniEmpty : ValidationRule
        {
            private readonly string AmtType = string.Empty;

            public ValidationSedeniEmpty(string mess, object val)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
                AmtType = val.ToStr();
            }

            public override bool Validate(Control control, object value)
            {
                if ((control.Visible) && (control.Enabled))
                {
                    if ((AmtType == "1") &&
                        ((value.ToStr() == "") || (value == null) || (value.ToString() == "0"))) return false;
                    return true;
                }
                return true;
            }
        }

        public class ValidationMassEmpty : ValidationRule
        {
            private readonly string[] cv = {"3", "6", "10", "11"};
            private readonly string Val = string.Empty;

            public ValidationMassEmpty(string mess, object val)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
                Val = val.ToStr();
            }

            public override bool Validate(Control control, object value)
            {
                if ((control.Visible) && (control.Enabled))
                {
                    var xd = cv.Where(x => x == Val);
                    if ((xd.ToStr() != "") && (value == null)) return false;
                    if ((xd.ToStr() != "") && (value == null) && (value.ToString() == "0")) return false;
                    return true;
                }
                return true;
            }
        }

        public class ValidationPowerEmpty : ValidationRule
        {
            public ValidationPowerEmpty(string mess)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
            }

            public override bool Validate(Control control, object value)
            {
                if ((control.Visible) && (control.Enabled))
                {
                    if ((value.ToStr() == "") || (value == null) || (value.ToString() == "0"))
                        return false;
                    return true;
                }
                return true;
            }
        }

        public class ValidationVinCodeEmpty : ValidationRule
        {
            private readonly int year;

            public ValidationVinCodeEmpty(string mess, int amtYear)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
                year = amtYear;
            }

            public override bool Validate(Control control, object value)
            {
                var s = value.ToStr();
                if ((control.Visible) && (control.Enabled))
                {
                    if ((year > 1986) &&
                        ((s == "") || (value.ToString() == "0") || (s.Length != 17)))
                        return false;
                    return true;
                }
                return true;
            }
        }

        public class ValidationTexpNumEmpty : ValidationRule
        {
            public ValidationTexpNumEmpty(string mess)
            {
                ErrorType = ErrorType.Critical;
                ErrorText = mess;
            }

            public override bool Validate(Control control, object value)
            {
                var s = value.ToStr();
                if ((control.Visible) && (control.Enabled))
                {
                    if ((s.Length > 0) && (s.Length != 7))
                        return false;
                    return true;
                }
                return true;
            }
        }
    }
}