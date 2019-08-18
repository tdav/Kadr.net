namespace Apteka.Utils
{
    public class UsbDevices
    {
        public static void EnableUsbStore(bool enable)
        {
            if (enable)
                Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 3, Microsoft.Win32.RegistryValueKind.DWord);
            else
                Microsoft.Win32.Registry.SetValue(@"HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Services\USBSTOR", "Start", 4, Microsoft.Win32.RegistryValueKind.DWord);
        }

        //public static void EnableMouse(bool enable)
        //{
        //    Guid mouseGuid = new Guid("{4d36e96f-e325-11ce-bfc1-08002be10318}");
        //    string instancePath = @"ACPI\PNP0F03\4&3688D3F&0";
        //    DeviceHelper.SetDeviceEnabled(mouseGuid, instancePath, enable);
        //}

        //public static void EnableDvdRom(bool enable)
        //{
        //    string deviceGuid;
        //    string deviceType;
        //    Guid actualGuid;

        //    ManagementObjectSearcher search = new System.Management.ManagementObjectSearcher("SELECT * From Win32_PnPEntity");
        //    foreach (System.Management.ManagementObject info in search.Get())
        //    {
        //        try
        //        {
        //            deviceType = info["DeviceID"].ToString();
        //            deviceGuid = info["ClassGuid"].ToString();
        //            if (deviceGuid.ToUpper() == "{4D36E965-E325-11CE-BFC1-08002BE10318}")
        //            {
        //                actualGuid = new Guid(deviceGuid);
        //                DeviceHelper.SetDeviceEnabled(actualGuid, deviceType, enable);
        //            }
        //        }
        //        catch (Exception)
        //        {
        //        }
        //    }
        //}
    }
}
