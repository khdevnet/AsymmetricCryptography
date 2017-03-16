using System;
using System.IO;

namespace Common
{
    internal class FileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/" + fileName);
        }
    }
}