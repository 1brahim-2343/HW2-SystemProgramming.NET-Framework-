using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2_SystemProgramming.NET_Framework_
{
    public class FileHelper
    {
        public int FileNum { get; set; }
        private int _counter { get; set; }
       
        public void CreateFile(int fileNum, int counter)
        {
            File.WriteAllText($"test\\file{fileNum} N{counter}.txt", $"testFile{fileNum}");
        }
    }
}
