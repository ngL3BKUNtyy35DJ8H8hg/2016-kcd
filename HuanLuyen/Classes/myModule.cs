using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
namespace HuanLuyen
{
    internal sealed class myModule
    {
        internal static int intMonitorW = 0;
        internal static int intMonitorH = 0;
        internal static bool RegisterOK = false;
        [DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetVolumeInformationA", ExactSpelling = true, SetLastError = true)]
        public static extern int GetVolumeInformation([MarshalAs(UnmanagedType.VBByRefStr)] ref string lpRootPathName, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpVolumeNameBuffer, int nVolumeNameSize, ref int lpVolumeSerialNumber, ref int lpMaximumComponentLength, ref int lpFileSystemFlags, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpFileSystemNameBuffer, int nFileSystemNameSize);
        [DllImport("kernel32", CharSet = CharSet.Ansi, EntryPoint = "GetComputerNameW", ExactSpelling = true, SetLastError = true)]
        public static extern void GetComputerName([MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpBuffer, ref int nSize);
        public static string GetComputerName()
        {
            StringBuilder stringBuilder = new StringBuilder(50);
            int maxCapacity = stringBuilder.MaxCapacity;
            myModule.GetComputerName(stringBuilder, ref maxCapacity);
            return stringBuilder.ToString();
        }
        internal static string toUnicode(object t1)
        {
            //[CONVERT FAIL]
//            string result = "";
//            checked
//            {
//                try
//                {
//                    if (t1 == null)
//                    {
//                        t1 = "";
//                    }
//                    else
//                    {
//                        t1 = t1.ToString();
//                    }
//                    string[] array = new string[]{
//"Ă",
//"Â",
//"Ê",
//"Ô",
//"Ơ",
//"Ư",
//"Đ",
//"ă",
//"â",
//"ê",
//"ô",
//"ơ",
//"ư",
//"đ",
//"*",
//"*",
//"*",
//"*",
//"*",
//"*",
//"à",
//"ả",
//"ã",
//"á",
//"ạ",
//"*",
//"ằ",
//"ẳ",
//"ẵ",
//"ắ",
//"*",
//"*",
//"*",
//"*",
//"*",
//"*",
//"*",
//"ặ",
//"ầ",
//"ẩ",
//"ẫ",
//"ấ",
//"ậ",
//"è",
//"*",
//"ẻ",
//"ẽ",
//"é",
//"ẹ",
//"ề",
//"ể",
//"ễ",
//"ế",
//"ệ",
//"ì",
//"ỉ",
//"*",
//"*",
//"*",
//"ĩ",
//"í",
//"ị",
//"ò",
//"à",
//"ỏ",
//"õ",
//"ó",
//"ọ",
//"ồ",
//"ổ",
//"ỗ",
//"ố",
//"ộ",
//"ờ",
//"ở",
//"ỡ",
//"ớ",
//"ợ",
//"ù",
//"*",
//"ủ",
//"ũ",
//"ú",
//"ụ",
//"ừ",
//"ử",
//"ữ",
//"ứ",
//"ự",
//"ỳ",
//"ỷ",
//"ỹ",
//"ý",
//"ỵ",
//"*"
//};
//                    string text = "";
//                    int arg_3E8_0 = 1;
//                    int num = t1.ToString().Length;
//                    for (int i = arg_3E8_0; i <= num; i++)
//                    {
//                        int num2 = String.Asc(t1.ToString().Substring(i, 1)) - 161;
//                        if (num2 < 0)
//                        {
//                            text += t1.ToString().Substring(i, 1);
//                        }
//                        else if (t1.ToString().Substring(num2, 1) == "*")
//                        {
//                            text += t1.ToString().Substring(i, 1);
//                        }
//                        else
//                        {
//                            text += array[num2];
//                        }
//                    }
//                    result = text;
//                }
//                catch (Exception arg_474_0)
//                {
//                    throw arg_474_0;
//                }
//                return result;
//            }

            return "";
        }
        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static void Main()
        {
            myModule.RegisterOK = true;
            checked
            {
                if (myModule.RegisterOK)
                {
                    string text = SystemInformation.PrimaryMonitorSize.ToString();
                    string[] array = text.Split(new char[]{'='});
                    myModule.intMonitorW = (int)Math.Round(double.Parse(array[1]));
                    myModule.intMonitorH = (int)Math.Round(double.Parse(array[2]));
                    frmMain frmMain = new frmMain();
                    frmMain.ShowDialog();
                }
            }
        }
        private static bool GetReg()
        {
            return false;
        }
    }
}