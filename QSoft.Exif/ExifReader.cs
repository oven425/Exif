using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QSoft.Exif
{
    public class ExifReader
    {
        List<CDirectoryEntry> DirectoryEntrys = new List<CDirectoryEntry>();
        public bool Open(Stream stream)
        {
            this.DirectoryEntrys.Clear();
            long start_pos = stream.Position;
            BinaryReader br = new BinaryReader(stream);
            
            byte[] bb = br.ReadBytes(2);
            short ss = br.ReadInt16();
            int offset = br.ReadInt32();
            br.BaseStream.Seek(start_pos+offset, SeekOrigin.Begin);

            while (true)
            {
                List<CDirectoryEntry> des = this.ReadDes(br);
                this.DirectoryEntrys.AddRange(des);
                CDirectoryEntry exifusb = des.FirstOrDefault(x => x.Tag == -30871);
                if(exifusb != null)
                {
                    long oldpos = br.BaseStream.Position;
                    br.BaseStream.Position = start_pos + exifusb.ValueOffset;
                    des = this.ReadDes(br);
                    CDirectoryEntry exposure_time = des.FirstOrDefault(x => x.Tag == -32102);
                    br.BaseStream.Position = start_pos + exposure_time.ValueOffset;
                    int a = br.ReadInt32();
                    int b = br.ReadInt32();
                    this.DirectoryEntrys.AddRange(des);
                    br.BaseStream.Position = oldpos;
                }
                offset = br.ReadInt32();
                if(offset == 0)
                {
                    break;
                }
                br.BaseStream.Position = start_pos + offset;
            }

            br.Close();
            return true;
        }

        List<CDirectoryEntry> ReadDes(BinaryReader br)
        {
            List<CDirectoryEntry> des = new List<CDirectoryEntry>();
            short count = br.ReadInt16();
            for (int i = 0; i < count; i++)
            {
                CDirectoryEntry de = new CDirectoryEntry();
                de.Tag = br.ReadInt16();
                short type = br.ReadInt16();
                de.Type = (CDirectoryEntry.Types)type;
                de.Count = br.ReadInt32();
                de.ValueOffset = br.ReadInt32();
                des.Add(de);
                System.Diagnostics.Trace.WriteLine(de);
            }
            return des;
        }
    }
}
