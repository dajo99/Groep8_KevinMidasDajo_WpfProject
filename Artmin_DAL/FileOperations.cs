using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artmin_DAL
{
    public static class FileOperations
    {
        public static void Foutloggen(Exception fout)
        {
            using (StreamWriter writer = new StreamWriter("ErrorFile.txt", true))
            {
                writer.WriteLine(DateTime.Now.ToString("HH:mm:ss:tt"));
                writer.WriteLine(fout.GetType().Name);
                writer.WriteLine(fout.Message);
                writer.WriteLine(fout.StackTrace);
                writer.WriteLine(new string('*', 100));
                writer.WriteLine();
            }
        }
    }
}
