using System;
using System.IO;

namespace BankApi.Library.Readers
{
    internal class FileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/" + fileName);
        }
    }
}