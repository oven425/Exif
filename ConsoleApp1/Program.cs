using QSoft.Exif;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = File.OpenRead("D:\\CCITT_1.TIF");
            ExifReader exifr = new ExifReader();
            exifr.Open(stream);
        }
    }
}
