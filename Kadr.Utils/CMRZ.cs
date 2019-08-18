using System;
using System.Collections.Generic;
using System.Linq;

namespace Apteka.Utils
{
    public class MrzParsing
    {
        public string PspType { get; set; }
        public string Country { get; set; }
        public string Owner { get; set; }

        public string PspSeryNumber { get; set; }
        public string PspCheckSum { get; set; }
        public string Citizenship { get; set; }
        public string DateBirth { get; set; }
        public string DateBirthCheckSum { get; set; }
        public string Sex { get; set; }
        public string DateValid { get; set; }
        public string DateValidCheckSum { get; set; }
        public string Pinpp { get; set; }
        public string PinppCheckSum { get; set; }
        public string TotalCheckSum { get; set; }
    }

    public class MrzValues
    {
        public string PspType { get; set; }
        public string OwnerSurname { get; set; }
        public string OwnerName { get; set; }
        public string PspSery { get; set; }
        public string PspNumber { get; set; }
        public string Country { get; set; }
        public string Citizenship { get; set; }
        public string db { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Sex { get; set; }
        public string dv { get; set; }
        public DateTime? ValidDay { get; set; }
        public string Pinpp { get; set; }
        public byte[] Photo { get; set; }
    }

    public class MrzChecksum
    {
        public bool PspTypeCorrect { get; set; }
        public string PspTypeMayBe { get; set; }
        public bool OwnerSurnameCorrect { get; set; }
        public string OwnerSurnameMayBe { get; set; }
        public bool OwnerNameCorrect { get; set; }
        public string OwnerNameMayBe { get; set; }
        public bool PspSeryCorrect { get; set; }
        public string PspSeryMayBe { get; set; }
        public bool PspNumberCorrect { get; set; }
        public string PspNumberMayBe { get; set; }
        public bool CountryCorrect { get; set; }
        public string CountryMayBe { get; set; }
        public bool CitizenshipCorrect { get; set; }
        public string CitizenshipMayBe { get; set; }
        public bool BirthDayCorrect { get; set; }
        public string BirthDayMayBe { get; set; }
        public bool SexCorrect { get; set; }
        public string SexMayBe { get; set; }
        public bool ValidDayCorrect { get; set; }
        public string ValidDayMayBe { get; set; }
        public bool PinppCorrect { get; set; }
        public string PinppMayBe { get; set; }


        public string PspSerialActualChecksum { get; set; }
        public string PspSerialMustChecksum { get; set; }
        public bool PspSerialChecksumCorrect { get; set; }

        public string DateBirthActualChecksum { get; set; }
        public string DateBirthMustChecksum { get; set; }
        public bool DateBirthChecksumCorrect { get; set; }

        public string DateValidActualChecksum { get; set; }
        public string DateValidMustChecksum { get; set; }
        public bool DateValidChecksumCorrect { get; set; }

        public string PinppActualChecksum { get; set; }
        public string PinppMustChecksum { get; set; }
        public bool PinppChecksumCorrect { get; set; }

        public string TotalActualChecksum { get; set; }
        public string TotalMustChecksum { get; set; }
        public bool TotalChecksumCorrect { get; set; }
    }

    public class PspValues
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronym { get; set; }
        public string Nationality { get; set; }
        public string IssuedBy { get; set; }
        public string BirthPlace { get; set; }
        public string IssuedDate { get; set; }
    }

    public class CMRZ
    {
        public MrzValues values { get; set; }
        public MrzChecksum checksum { get; set; }

        public MrzParsing parsings { get; set; }

        private List<string> docTypes { get; set; }
        private List<string> countries { get; set; }

        public CMRZ()
        {
            checksum = new MrzChecksum();
            values = new MrzValues();
            parsings = new MrzParsing();

            docTypes = new List<string>();
            countries = new List<string>();
            docTypes.Add("P");
            docTypes.Add("PD");
            docTypes.Add("PT");
            docTypes.Add("TD");
            docTypes.Add("RW");
            docTypes.Add("FR");
            docTypes.Add("DP");

            #region ICAO countries
            countries.Add("NIU");
            countries.Add("NOR");
            countries.Add("NFK");
            countries.Add("AZE");
            countries.Add("DEU");
            countries.Add("OMN");
            countries.Add("PLW");
            countries.Add("PAN");
            countries.Add("PNG");
            countries.Add("PRY");
            countries.Add("PER");
            countries.Add("PCN");
            countries.Add("PAK");
            countries.Add("POL");
            countries.Add("PRT");
            countries.Add("GBR");
            countries.Add("HMD");
            countries.Add("HRV");
            countries.Add("NIC");
            countries.Add("PRI");
            countries.Add("REU");
            countries.Add("PSE");
            countries.Add("RUS");
            countries.Add("RWA");
            countries.Add("ROM");
            countries.Add("WSM");
            countries.Add("SMR");
            countries.Add("STP");
            countries.Add("SAU");
            countries.Add("SWZ");
            countries.Add("AUS");
            countries.Add("DOM");
            countries.Add("DMA");
            countries.Add("DZA");
            countries.Add("ZMB");
            countries.Add("ZWE");
            countries.Add("SEN");
            countries.Add("KNA");
            countries.Add("LCA");
            countries.Add("SGP");
            countries.Add("SYR");
            countries.Add("SVK");
            countries.Add("SVN");
            countries.Add("SLB");
            countries.Add("SOM");
            countries.Add("SDN");
            countries.Add("SUR");
            countries.Add("SLE");
            countries.Add("THA");
            countries.Add("TWN");
            countries.Add("TZA");
            countries.Add("TCA");
            countries.Add("TGO");
            countries.Add("TJK");
            countries.Add("TKL");
            countries.Add("TON");
            countries.Add("TTO");
            countries.Add("TUV");
            countries.Add("TUN");
            countries.Add("TUR");
            countries.Add("TKM");
            countries.Add("UGA");
            countries.Add("UKR");
            countries.Add("WLF");
            countries.Add("URY");
            countries.Add("FRO");
            countries.Add("FJI");
            countries.Add("PHL");
            countries.Add("FIN");
            countries.Add("CZE");
            countries.Add("MYT");
            countries.Add("MKD");
            countries.Add("FLK");
            countries.Add("ZAF");
            countries.Add("PYF");
            countries.Add("FRA");
            countries.Add("ALB");
            countries.Add("USA");
            countries.Add("ASM");
            countries.Add("ZAR");
            countries.Add("IDN");
            countries.Add("CHN");
            countries.Add("CHL");
            countries.Add("TMP");
            countries.Add("CHE");
            countries.Add("SWE");
            countries.Add("MNP");
            countries.Add("SJM");
            countries.Add("AIA");
            countries.Add("NTZ");
            countries.Add("SLV");
            countries.Add("SCG");
            countries.Add("TCD");
            countries.Add("GUF");
            countries.Add("LKA");
            countries.Add("ECU");
            countries.Add("ERI");
            countries.Add("IRN");
            countries.Add("EST");
            countries.Add("ETH");
            countries.Add("YUG");
            countries.Add("JAM");
            countries.Add("NZL");
            countries.Add("NCL");
            countries.Add("JPN");
            countries.Add("ESH");
            countries.Add("UZB");
            countries.Add("KGZ");
            countries.Add("KGZ");
            countries.Add("KAZ");
            countries.Add("KWT");
            countries.Add("IND");
            countries.Add("AUT");
            countries.Add("DJI");
            countries.Add("MDV");
            countries.Add("MLT");
            countries.Add("CAF");
            countries.Add("MAR");
            countries.Add("MTQ");
            countries.Add("BEN");
            countries.Add("BMU");
            countries.Add("ARE");
            countries.Add("BGR");
            countries.Add("BOL");
            countries.Add("BIH");
            countries.Add("BWA");
            countries.Add("BRA");
            countries.Add("VGB");
            countries.Add("BRN");
            countries.Add("BVT");
            countries.Add("BFA");
            countries.Add("BDI");
            countries.Add("BTN");
            countries.Add("VUT");
            countries.Add("VAT");
            countries.Add("HUN");
            countries.Add("VEN");
            countries.Add("VIR");
            countries.Add("VNM");
            countries.Add("GAB");
            countries.Add("HTI");
            countries.Add("GMB");
            countries.Add("GHA");
            countries.Add("GLP");
            countries.Add("GTM");
            countries.Add("GIN");
            countries.Add("GNQ");
            countries.Add("GNB");
            countries.Add("GIB");
            countries.Add("HND");
            countries.Add("HKG");
            countries.Add("GRC");
            countries.Add("GRD");
            countries.Add("GRL");
            countries.Add("GEO");
            countries.Add("GUM");
            countries.Add("DNK");
            countries.Add("MDG");
            countries.Add("MAC");
            countries.Add("MWI");
            countries.Add("MYS");
            countries.Add("MLI");
            countries.Add("SYC");
            countries.Add("VCT");
            countries.Add("SPM");
            countries.Add("LGB");
            countries.Add("ATA");
            countries.Add("ATG");
            countries.Add("ARG");
            countries.Add("ARM");
            countries.Add("JOR");
            countries.Add("IRL");
            countries.Add("IRQ");
            countries.Add("ISL");
            countries.Add("ESP");
            countries.Add("ISR");
            countries.Add("ITA");
            countries.Add("YEM");
            countries.Add("CPV");
            countries.Add("CYM");
            countries.Add("KHM");
            countries.Add("CMR");
            countries.Add("CAN");
            countries.Add("QAT");
            countries.Add("KEN");
            countries.Add("CYP");
            countries.Add("KIR");
            countries.Add("CCK");
            countries.Add("COL");
            countries.Add("COM");
            countries.Add("COG");
            countries.Add("PRK");
            countries.Add("KOR");
            countries.Add("CRI");
            countries.Add("CIV");
            countries.Add("CUB");
            countries.Add("COK");
            countries.Add("LAO");
            countries.Add("LVA");
            countries.Add("LSO");
            countries.Add("LBR");
            countries.Add("LBN");
            countries.Add("LBY");
            countries.Add("GUY");
            countries.Add("LTU");
            countries.Add("LIE");
            countries.Add("LUX");
            countries.Add("MNG");
            countries.Add("MUS");
            countries.Add("MRT");
            countries.Add("ABW");
            countries.Add("AFG");
            countries.Add("BHS");
            countries.Add("BGD");
            countries.Add("BRB");
            countries.Add("BHR");
            countries.Add("BLZ");
            countries.Add("BLR");
            countries.Add("BEL");
            countries.Add("AGO");
            countries.Add("AND");
            countries.Add("MHL");
            countries.Add("MEX");
            countries.Add("FSM");
            countries.Add("EGY");
            countries.Add("MOZ");
            countries.Add("MDA");
            countries.Add("MCO");
            countries.Add("MSR");
            countries.Add("SHN");
            countries.Add("MMR");
            countries.Add("IMY");
            countries.Add("NAM");
            countries.Add("NRU");
            countries.Add("NPL");
            countries.Add("NER");
            countries.Add("NGA");
            countries.Add("NLD");
            countries.Add("ANT");
            countries.Add("COD");
            countries.Add("XXX");
            #endregion

        }

        public bool ParseMRZ(string mrz)
        {
            mrz = mrz.ToUpper().Replace(" ", "").Replace("\r", "").Replace("\n", "");
            if (mrz.Length == 88)
                //throw new ArgumentException("MRZ узунлиги 88 белгидан иборат бўлиши керак", "mrz");
                return ParseMRZ(mrz.Substring(0, 44), mrz.Substring(44, 44));
            else
                return false;
        }

        public bool ParseMRZ(string mrz1, string mrz2)
        {
            bool result = true;

            if ((mrz1.Length == 44) && (mrz2.Length == 44))
                //throw new ArgumentException("MRZ узунлиги 44 белгидан иборат бўлиши керак", "mrz1");
                //throw new ArgumentException("MRZ узунлиги 44 белгидан иборат бўлиши керак", "mrz2");
                values.PspType = mrz1.Substring(0, 2).Replace("<", "");
            else
                return false;

            if (!docTypes.Contains(values.PspType))
            {
                checksum.PspTypeMayBe = values.PspType.Replace('B', 'P').Replace('R', 'P').Replace('V', 'W');
                checksum.PspTypeCorrect = result = false;
            }
            else
                checksum.PspTypeCorrect = true;

            values.Country = mrz1.Substring(2, 3);
            if (!countries.Contains(values.Country))
            {
                checksum.CountryMayBe = "UZB";
                checksum.CountryCorrect = result = false;
            }
            else
                checksum.CountryCorrect = true;

            string target = "<<";
            char[] anyOf = target.ToCharArray();
            values.OwnerSurname = mrz1.Substring(5, mrz1.IndexOf("<<") - 5).Replace('<', ' ');
            checksum.OwnerSurnameCorrect = true;
            checksum.OwnerSurnameMayBe = values.OwnerSurname;

            values.OwnerName = mrz1.Substring(mrz1.IndexOfAny(anyOf, 5) + 2, mrz1.IndexOfAny(anyOf, mrz1.IndexOfAny(anyOf, 5) + 2) - mrz1.IndexOfAny(anyOf, 5) - 2).Replace('<', ' ');
            checksum.OwnerNameCorrect = true;
            checksum.OwnerNameMayBe = values.OwnerName;


            values.PspSery = mrz2.Substring(0, 2).Replace("<", "");
            if (values.PspSery.Any(Char.IsDigit))
            {
                checksum.PspSeryCorrect = result = false;
                checksum.PspSeryMayBe = values.PspSery.Replace('4', 'A').Replace('0', 'O').Replace('1', 'I');
            }
            else
                checksum.PspSeryCorrect = true;

            values.PspNumber = mrz2.Substring(2, 7).Replace("<", "");
            if (values.PspNumber.Any(Char.IsLetter))
            {
                checksum.PspNumberCorrect = result = false;
                checksum.PspNumberMayBe = values.PspSery.Replace('I', '1').Replace('O', '0').Replace('B', '8').Replace('S', '5');
            }
            else
                checksum.PspNumberCorrect = true;


            checksum.PspSerialActualChecksum = mrz2[9].ToStr();
            checksum.PspSerialMustChecksum = CalculateControlSum(mrz2.Substring(0, 9));
            checksum.PspSerialChecksumCorrect = (checksum.PspSerialActualChecksum == checksum.PspSerialMustChecksum);

            values.Citizenship = mrz2.Substring(10, 3);
            if (!countries.Contains(values.Citizenship))
            {
                checksum.CitizenshipMayBe = "UZB";
                checksum.CitizenshipCorrect = result = false;
            }
            else
                checksum.CitizenshipCorrect = true;


            values.db = mrz2.Substring(13, 6).Replace("<<", "01").Replace('O', '0');

            values.Pinpp = mrz2.Substring(28, 14);
            string centure = ".19";
            if (values.db.Any(Char.IsLetter))
            {
                values.BirthDay = null;
                checksum.BirthDayCorrect = result = false;
                checksum.BirthDayMayBe = values.db.Replace('I', '1').Replace('O', '0').Replace('T', '7');
            }
            else
            {
                switch (values.Pinpp[0])
                {
                    case '1':
                    case '2':
                        centure = ".18"; break;
                    case '3':
                    case '4':
                        centure = ".19"; break;
                    case '5':
                    case '6':
                        centure = ".20"; break;
                    default:
                        if (DateTime.Today.Year >= ("20" + values.db.Substring(0, 2)).ToInt())
                            centure = ".19";
                        else
                            centure = ".20";

                        break;
                }
                values.BirthDay = (values.db.Substring(4, 2).Replace("<<", "01") + "." + values.db.Substring(2, 2).Replace("<<", "01") + centure + values.db.Substring(0, 2)).ToDataTime();
            }
            checksum.DateBirthActualChecksum = mrz2[19].ToStr();
            checksum.DateBirthMustChecksum = CalculateControlSum(values.db);
            checksum.DateBirthChecksumCorrect = (checksum.DateBirthActualChecksum == checksum.DateBirthMustChecksum);

            checksum.PinppActualChecksum = mrz2[42].ToStr();
            checksum.PinppMustChecksum = CalculateControlSum(values.Pinpp);
            checksum.PinppChecksumCorrect = (checksum.PinppActualChecksum == checksum.PinppMustChecksum);

            values.Sex = mrz2[20].ToStr().Replace('H', 'M').Replace('N', 'M');
            if ((values.Sex != "M") && (values.Sex != "F") && (values.Sex != "<"))
            {
                checksum.SexCorrect = result = false;
                switch (values.Pinpp[0])
                {
                    case '1':
                    case '3':
                    case '5':
                        checksum.SexMayBe = "M";
                        break;
                    default:
                        checksum.SexMayBe = "F";
                        break;
                }
            }

            values.dv = mrz2.Substring(21, 6).Replace('O', '0');
            if (values.dv.Any(Char.IsLetter))
            {
                values.ValidDay = null;
                checksum.ValidDayCorrect = result = false;
                checksum.ValidDayMayBe = values.dv.Replace('I', '1').Replace('O', '0').Replace('T', '7');
            }
            else
                values.ValidDay = (values.dv.Substring(4, 2) + "." + values.dv.Substring(2, 2) + ".20" + values.dv.Substring(0, 2)).ToDataTime();

            checksum.DateValidActualChecksum = mrz2[27].ToStr();
            checksum.DateValidMustChecksum = CalculateControlSum(values.dv);
            checksum.DateValidChecksumCorrect = (checksum.DateValidActualChecksum == checksum.DateValidMustChecksum);

            checksum.TotalActualChecksum = mrz2[43].ToStr();
            checksum.TotalMustChecksum = CalculateControlSum(values.PspSery + values.PspNumber + checksum.PspSerialActualChecksum +
                values.db + checksum.DateBirthActualChecksum + values.dv + checksum.DateValidActualChecksum + values.Pinpp + checksum.PinppActualChecksum);
            checksum.TotalChecksumCorrect = (checksum.DateValidActualChecksum == checksum.DateValidMustChecksum);

            return result;
        }

        public void MRZStrings(string mrz)
        {
            mrz = mrz.ToUpper().Replace(" ", "");
            string[] mrzones = mrz.Split('\r');

            string mrz1 = mrzones[0].Replace("\r", "").Replace("\n", "");
            string mrz2 = mrzones[1].Replace("\r", "").Replace("\n", "");
            MRZStrings(mrz1, mrz2);
        }

        public void MRZStrings(string line1, string line2)
        {
            string mrz1 = line1;
            string mrz2 = line2;
            if (mrz2.Length < 44) return;

            parsings.PspType = mrz1.Substring(0, 2);
            parsings.Country = mrz1.Substring(2, 3);
            parsings.Owner = mrz1.Substring(5, mrz1.Length - 5).PadRight(39, '<');

            parsings.PspSeryNumber = mrz2.Substring(0, 9).Replace('O', '0').Replace('B', '0');
            parsings.PspCheckSum = mrz2[9].ToStr().Replace('O', '0').Replace('B', '0');
            parsings.Citizenship = mrz2.Substring(10, 3);

            parsings.DateBirth = mrz2.Substring(13, 6).Replace('O', '0').Replace('B', '0');
            parsings.DateBirthCheckSum = mrz2[19].ToStr().Replace('O', '0').Replace('B', '0');
            parsings.Sex = mrz2[20].ToStr();
            parsings.DateValid = mrz2.Substring(21, 6).Replace('O', '0').Replace('B', '0');
            parsings.DateValidCheckSum = mrz2[27].ToStr().Replace('O', '0').Replace('B', '0');
            parsings.Pinpp = mrz2.Substring(28, 14).Replace('O', '0').Replace('B', '0');
            parsings.PinppCheckSum = mrz2[42].ToStr().Replace('O', '0').Replace('B', '0');
            parsings.TotalCheckSum = mrz2[43].ToStr().Replace('O', '0').Replace('B', '0');
        }

        public string GetLineForChip(string pspSeryNumber, DateTime DateBirth, DateTime DateValid)
        {
            string db = DateBirth.ToString("yyMMdd");
            string dateValid = DateValid.ToString("yyMMdd");

            return pspSeryNumber + CalculateControlSum(pspSeryNumber) + db + CalculateControlSum(db) + dateValid + CalculateControlSum(dateValid);

            //"CA2022302" + "7" + "790520" + "7" + "240519" + "3"
        }

        public string CalculateControlSum(string inStr)
        {
            int c = 0;
            int j = 0;
            int[] k = new int[3] { 7, 3, 1 };

            for (int i = 0; i < inStr.Length; i++)
            {
                c += GetConvIcaoChar(inStr[i]) * k[j];
                j++;
                if (j == 3) j = 0;
            }
            string result = c.ToString();
            return result[result.Length - 1].ToString();
        }

        public int GetConvIcaoChar(char inCh)
        {
            switch (inCh)
            {
                case 'A': return 10;
                case 'B': return 11;
                case 'C': return 12;
                case 'D': return 13;
                case 'E': return 14;
                case 'F': return 15;
                case 'G': return 16;
                case 'H': return 17;
                case 'I': return 18;
                case 'J': return 19;
                case 'K': return 20;
                case 'L': return 21;
                case 'M': return 22;
                case 'N': return 23;
                case 'O': return 24;
                case 'P': return 25;
                case 'Q': return 26;
                case 'R': return 27;
                case 'S': return 28;
                case 'T': return 29;
                case 'U': return 30;
                case 'V': return 31;
                case 'W': return 32;
                case 'X': return 33;
                case 'Y': return 34;
                case 'Z': return 35;
                case '<': return 0;

                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;

                case '_': return 0;
                case ' ': return 0;

                default: return 0;
            }
        }

       
    }
}
