using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QSoft.Exif
{
    public class ExifReader
    {
        public bool Open(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);



            br.Close();
            br.Dispose();
            return true;
        }
    }
}
