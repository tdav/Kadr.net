using System;
using System.Runtime.InteropServices;

namespace Apteka.Utils
{
    public static class UsbNotification
    {
        public const int DbtDevicearrival = 0x8000; // system detected a new device        
        public const int DbtDeviceremovecomplete = 0x8004; // device is gone      
        public const int WmDevicechange = 0x0219; // device change event      
        private const int DbtDevtypDeviceinterface = 5;
        private static readonly Guid GuidDevinterfaceUSBDevice = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED"); // USB devices
        private static IntPtr notificationHandle;

        /// <summary>
        /// Registers a window to receive notifications when USB devices are plugged or unplugged.
        /// </summary>
        /// <param name="windowHandle">Handle to the window receiving notifications.</param>
        public static void RegisterUsbDeviceNotification(IntPtr windowHandle)
        {
            DevBroadcastDeviceinterface dbi = new DevBroadcastDeviceinterface
            {
                DeviceType = DbtDevtypDeviceinterface,
                Reserved = 0,
                ClassGuid = GuidDevinterfaceUSBDevice,
                Name = 0
            };

            dbi.Size = Marshal.SizeOf(dbi);
            IntPtr buffer = Marshal.AllocHGlobal(dbi.Size);
            Marshal.StructureToPtr(dbi, buffer, true);

            notificationHandle = RegisterDeviceNotification(windowHandle, buffer, 0);
        }

        /// <summary>
        /// Unregisters the window for USB device notifications
        /// </summary>
        public static void UnregisterUsbDeviceNotification()
        {
            UnregisterDeviceNotification(notificationHandle);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr RegisterDeviceNotification(IntPtr recipient, IntPtr notificationFilter, int flags);

        [DllImport("user32.dll")]
        private static extern bool UnregisterDeviceNotification(IntPtr handle);

        [StructLayout(LayoutKind.Sequential)]
        private struct DevBroadcastDeviceinterface
        {
            internal int Size;
            internal int DeviceType;
            internal int Reserved;
            internal Guid ClassGuid;
            internal short Name;
        }
    }
}


/*
    //Here's how you use it from a WPF Window (Windows Forms is similar):
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);

        // Adds the windows message processing hook and registers USB device add/removal notification.
        HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
        if (source != null)
        {
            windowHandle = source.Handle;
            source.AddHook(HwndHandler);
            UsbNotification.RegisterUsbDeviceNotification(windowHandle);
        }
    }

    /// <summary>
    /// Method that receives window messages.
    /// </summary>
    private IntPtr HwndHandler(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam, ref bool handled)
    {
        if (msg == UsbNotification.WmDevicechange)
        {
            switch ((int)wparam)
            {
                case UsbNotification.DbtDeviceremovecomplete:
                    Usb_DeviceRemoved(); // this is where you do your magic
                    break;
                case UsbNotification.DbtDevicearrival:
                    Usb_DeviceAdded(); // this is where you do your magic
                    break;
            }
        }

        handled = false;
        return IntPtr.Zero;
    }
     



    //Here's the use example for Windows Forms (even simpler):
    public Form1()
    {
        InitializeComponent();
        UsbNotification.RegisterUsbDeviceNotification(this.Handle);
    }

    protected override void WndProc(ref Message m)
    {
        base.WndProc(ref m);
            if (m.Msg == UsbNotification.WmDevicechange)
        {
            switch ((int)m.WParam)
            {
                case UsbNotification.DbtDeviceremovecomplete:
                    Usb_DeviceRemoved(); // this is where you do your magic
                    break;
                case UsbNotification.DbtDevicearrival:
                    Usb_DeviceAdded(); // this is where you do your magic
                    break;
            }
        }
    }
     */
