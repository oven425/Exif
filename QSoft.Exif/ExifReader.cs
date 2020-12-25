using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QSoft.Exif
{
    public class ExifReader
    {
        public bool Open(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);
            byte[] bb = br.ReadBytes(2);
            bb = br.ReadBytes(2);
            bb = br.ReadBytes(2);


            br.Close();
            return true;
        }
    }
}
