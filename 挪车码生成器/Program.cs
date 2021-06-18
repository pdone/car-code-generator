using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 挪车码生成器
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            //Exception ex = e.Exception;
        }

        private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");

            if (dllName.EndsWith("_resources")) return null;

            var obj = Properties.Resources.ResourceManager.GetObject(dllName);
            var bytes = (byte[])obj;
            return System.Reflection.Assembly.Load(bytes);
        }
    }
}
