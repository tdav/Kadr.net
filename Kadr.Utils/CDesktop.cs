using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;

namespace Apteka.Utils
{

    public static class CWindowsAnimate
    {
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmEnableComposition(CompositionAction uCompositionAction);

        [Flags]
        public enum CompositionAction : uint
        {
            DWM_EC_DISABLECOMPOSITION = 0,
            DWM_EC_ENABLECOMPOSITION = 1
        } 

        //make your computer run a little faster.
        //You can shut off the animation displayed when you minimize and maximize Windows.
        //1. Open RegEdit
        //2. Go to HKEY_CURRENT_USER\Control panel \Desktop\WindowMetrics
        //3. Create a new string value "MinAnimate".
        //4. Set the value data of 0 for Off or 1 for On
    }

    internal static class NativeMethods
    {
        public const int COLOR_DESKTOP = 1;
        public const int SPI_SETDESKWALLPAPER = 20;
        public const int SPIF_UPDATEINIFILE = 0x01;
        public const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll")]
        public static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
    }


    public static class CWallpaperColorChanger
    {
        public static void SetColor(Color color)
        {

            // Remove the current wallpaper
            NativeMethods.SystemParametersInfo(NativeMethods.SPI_SETDESKWALLPAPER, 0, "", NativeMethods.SPIF_UPDATEINIFILE | NativeMethods.SPIF_SENDWININICHANGE);

            // Set the new desktop solid color for the current session
            int[] elements = { NativeMethods.COLOR_DESKTOP };
            int[] colors = { System.Drawing.ColorTranslator.ToWin32(color) };
            NativeMethods.SetSysColors(elements.Length, elements, colors);

            // Save value in registry so that it will persist
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Control Panel\\Colors", true);
            key.SetValue(@"Background", string.Format("{0} {1} {2}", color.R, color.G, color.B));
        }

    

        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        public enum Style : int
        {
            Tiled,
            Centered,
            Stretched
        }

        public static void Set(Uri uri, Style style)
        {
            System.IO.Stream s = new System.Net.WebClient().OpenRead(uri.ToString());

            System.Drawing.Image img = System.Drawing.Image.FromStream(s);
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            if (style == Style.Stretched)
            {
                key.SetValue(@"WallpaperStyle", 2.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Centered)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 0.ToString());
            }

            if (style == Style.Tiled)
            {
                key.SetValue(@"WallpaperStyle", 1.ToString());
                key.SetValue(@"TileWallpaper", 1.ToString());
            }

           NativeMethods. SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                tempPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }
    }
}