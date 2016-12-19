using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetToAutoRun
{
    class Program
    {
        static void Main(string[] args)
        {
            string reSet = string.Empty;
            RegistryKey reg = null;
            try
            {
                if (!System.IO.File.Exists(fileName))
                {
                    reSet = "该文件不存在!";
                }
                string name = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
                reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (reg == null)
                {
                    reg = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                }
                if (isAutoRun)
                {
                    reg.SetValue(name, fileName);
                    reSet = "1";
                }
                else
                {
                    reg.SetValue(name, false);
                }

            }
            catch (Exception ex)
            {
                //“记录异常”
            }
            finally
            {
                if (reg != null)
                {
                    reg.Close();
                }
            }
            return reSet;
        }
    }
}
