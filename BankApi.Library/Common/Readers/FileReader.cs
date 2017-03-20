using System;
using System.IO;

namespace BankApi.Library.Common.Readers
{
    internal class FileReader
    {
        public string Read(string fileName)
        {
            return File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "/" + fileName);
        }
    }
}