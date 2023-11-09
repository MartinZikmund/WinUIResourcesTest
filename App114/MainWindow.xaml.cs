using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App114
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            int UIA_MEDIA_ASPECTRATIO = 5306;
            var localized = GetLocalizedResource(UIA_MEDIA_ASPECTRATIO);
        }

        private string GetLocalizedResource(int resourceId)
        {
            IntPtr block = MAKEINTRESOURCE(resourceId / 16 + 1);
            IntPtr hModule = NativeMethods.GetModuleHandle("Microsoft.UI.Xaml.dll");

            // Find and load the string resource
            IntPtr hResource = NativeMethods.FindResource(hModule, block, (IntPtr)NativeMethods.RT_STRING);
            IntPtr hStr = NativeMethods.LoadResource(hModule, hResource);
            IntPtr pString = NativeMethods.LockResource(hStr);
            var res = Marshal.PtrToStringAuto(pString);
            return res;
        }

        private static IntPtr MAKEINTRESOURCE(int id)
        {
            return new IntPtr(0x0000FFFF & id);
        }
    }

    public static class NativeMethods
    {
        public const int RT_STRING = 6;

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr FindResource(IntPtr hModule, IntPtr lpName, IntPtr lpType);

        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr MakeIntResource(IntPtr hModule, IntPtr lpName, IntPtr lpType);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LoadResource(IntPtr hModule, IntPtr hResInfo);

        [DllImport("kernel32.dll")]
        public static extern IntPtr LockResource(IntPtr hResData);

        // Other constants and P/Invokes may be required depending on usage
    }
}
