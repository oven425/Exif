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
            //Stream stream = File.OpenRead("D:\\CCITT_1.TIF");
            byte[] bb = File.ReadAllBytes("D:\\mobile01-51f74a1e86330f30c9e565237f11e099.jpg");

            string exif_str = "Exif";
            exif_str = BitConverter.ToString(Encoding.UTF8.GetBytes(exif_str)).Replace("-","");


            string str = BitConverter.ToString(bb).Replace("-", "");
            int index = str.IndexOf(exif_str);

            Stream stream = File.OpenRead("D:\\mobile01-51f74a1e86330f30c9e565237f11e099.jpg");
            stream.Position = index;
            ExifReader exifr = new ExifReader();
            exifr.Open(stream);
        }
    }
}
