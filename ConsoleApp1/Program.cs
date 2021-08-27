using ConsoleApp1.Properties;
using QSoft.Exif;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //string name = assembly.GetName().Name;
            //var names = assembly.GetManifestResourceNames();
            //Stream imageStream = assembly.GetManifestResourceStream("ConsoleApp1.Properties.Resources.resources");
            //var rr = new ResourceReader(imageStream);
            //var dict = rr.GetEnumerator();
            //int ctr = 0;
            //while (dict.MoveNext())
            //{
            //    ctr++;
            //    Console.WriteLine("{0:00}: {1} = {2}", ctr, dict.Key, dict.Value);
            //}
            var img = Resources.A;
            //Stream stream = File.OpenRead("D:\\CCITT_1.TIF");
            //byte[] bb = File.ReadAllBytes("D:\\mobile01-51f74a1e86330f30c9e565237f11e099.jpg");

            string exif_str = "Exif";
            exif_str = BitConverter.ToString(Encoding.UTF8.GetBytes(exif_str)).Replace("-", "");


            string str = BitConverter.ToString(img).Replace("-", "");
            int index = str.IndexOf(exif_str);

            Stream stream = new MemoryStream(img);
            stream.Position = index;
            ExifReader exifr = new ExifReader();
            exifr.Open(stream);
        }
    }
}
