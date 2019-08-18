using System.Windows.Forms;

namespace Apteka.Utils
{
    public  class CLanguage
    {
        private int _index;
        private InputLanguage _russianInput;
        private InputLanguage _uzbekInput;
        private InputLanguage _englishInput;


        public CLanguage()
        {
            this._index = 0;
            /*
             English (United States)
             Russian (Russia)
             Uzbek (Cyrillic, Uzbekistan)
            */

            _russianInput = GetInputLanguageByName("russian (russia)");
            _uzbekInput = GetInputLanguageByName("uzbek (cyrillic, uzbekistan)");
            _englishInput = GetInputLanguageByName("english");
        }

        public void SetKeyboardLayout(InputLanguage layout)
        {
            InputLanguage.CurrentInputLanguage = layout;
        }


        public static InputLanguage GetInputLanguageByName(string inputName)
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if (lang.Culture.EnglishName.ToLower().StartsWith(inputName))
                    return lang;
            }
            return null;
        }


        public void NextKeyboardLayout()
        {
            switch (_index)
            {
                case 0:
                    LoadRussianKeyboardLayout();
                    break;
                case 1:
                    LoadUzbekKeyboardLayout();
                    break;
                case 2:
                    LoadEnglishKeyboardLayout();
                    break;
            }
            _index++;
            if (_index == 3)
                _index = 0;
        }

        public void LoadRussianKeyboardLayout()
        {
            if (_russianInput != null)
            {
                InputLanguage.CurrentInputLanguage = _russianInput;
                _index = 0;
            }
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        public void LoadUzbekKeyboardLayout()
        {
            if (_uzbekInput != null)
            {
                InputLanguage.CurrentInputLanguage = _uzbekInput;
                _index = 1;
            }
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        public void LoadEnglishKeyboardLayout()
        {
            if (_englishInput != null)
            {
                InputLanguage.CurrentInputLanguage = _englishInput;
                _index = 2;
            }
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

    }
}
