// <copyright file="Program.cs" company="LNU">
// All rights reserved.
// </copyright>
// <author>TORV team</author>

namespace PCIS
{
    /// <summary>
    /// Initial point of app. Variant 1
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Starting app
        /// </summary>
        private static void Main()
        {
            string path1 = @"C:\Users\USER\Desktop\PCIS\PCIS.Collections\Data\Data.txt";
            string path2 = @"C:\Users\USER\Desktop\PCIS\PCIS.Collections\Data\File1.txt";
            string path3 = @"C:\Users\USER\Desktop\PCIS\PCIS.Collections\Data\File2.txt";
            PCIS.Collections.Data.Task a = new Collections.Data.Task();
            a.RunTask1(path1, path2);
            a.RunTask2(path3);
        }
    }
}
