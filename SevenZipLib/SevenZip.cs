using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SevenZipLib
{
    public static class SevenZip
    {



        [DllImport("7zz", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SevenZipExecute")]
        public static extern int ServenZipExecute(IntPtr args);

        public static readonly Encoding CharEncoding;


        static SevenZip()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                CharEncoding = Encoding.Unicode;
            }
            else
            {
                CharEncoding = Encoding.UTF32;
            }
        }




        /// <summary>
        /// 调用7zip将压缩包解压到文件夹
        /// </summary>
        /// <param name="filePath">压缩包路径</param>
        /// <param name="outDir">输出文件夹的路径</param>
        /// <param name="extractFullPath">解压压缩包内的文件时是否添加相对路径</param>
        /// <param name="overwrite">覆盖文件</param>
        /// <param name="password">压缩包密码</param>
        /// <returns>7z执行的返回值</returns>
        public static int ExtractToDir(string filePath, string outDir, bool extractFullPath = true, bool overwrite = true, string password = null)
        {
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            StringBuilder arg = new StringBuilder(extractFullPath ? "x" : "e").Append(" \"").Append(filePath).Append("\"");

            AppendArg(arg, "-o", outDir);

            if (overwrite)
                AppendArg(arg, "-aoa");

            if (password != null)
                AppendArg(arg, "-p", password);





            var argStr = arg.ToString();

            var argBytes = new byte[CharEncoding.GetByteCount(argStr) + 4];

            CharEncoding.GetBytes(argStr, 0, arg.Length, argBytes, 0);

            var argPtr = Marshal.AllocHGlobal(argBytes.Length);

            Marshal.Copy(argBytes, 0, argPtr, argBytes.Length);

            return ServenZipExecute(argPtr);

            void AppendArg(StringBuilder @string, string _arg, string content = null)
            {
                @string.Append(" ").Append(_arg);
                if (content != null)
                    @string.Append("\"").Append(content).Append("\"");
            }


        }
    }
}
