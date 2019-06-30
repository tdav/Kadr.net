using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dotSwitcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            bool onlyInstance;
            Mutex mtx = new Mutex(true, "dotSwitcher", out onlyInstance);

            if (!(onlyInstance)) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var engine = new Switcher();
            Application.ApplicationExit += (s, a) => { engine.Dispose(); };
            Application.Run(new SysTrayApp(engine));
        }
    }
}
