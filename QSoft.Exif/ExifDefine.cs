using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace QSoft.Exif
{

    public class CDirectoryEntry
    {
        public enum Types
        {
            BYTE=1,
            ASCII,
            SHORT,
            LONG,
            RATIONAL,
            SBYTE,
            UNDEFINED,
            SSHORT,
            SLONG,
            SRATIONAL,
            FLOAT,
            DOUBLE
        }
        public short Tag { set; get; }
        public Types Type { set; get; }
        public int Count { set; get; }
        public int ValueOffset { set; get; }

        public override string ToString()
        {
            return $"Tag:{this.Tag}(0x{this.Tag:x}) Type:{this.Type} Count:{this.Count} ValueOffset:{this.ValueOffset}";
        }
    }



    public static class BinaryReaderEx
    {
        public static short ReadInt16BN(this BinaryReader src)
        {
            byte[] buf = src.ReadBytes(2);
            Array.Reverse(buf);
            return BitConverter.ToInt16(buf, 0);
        }

        public static int ReadInt32BN(this BinaryReader src)
        {
            byte[] buf = src.ReadBytes(4);
            Array.Reverse(buf);
            return BitConverter.ToInt32(buf, 0);
        }

        public static long ReadInt64BN(this BinaryReader src)
        {
            byte[] buf = src.ReadBytes(8);
            Array.Reverse(buf);
            return BitConverter.ToInt64(buf, 0);
        }

        public static ushort ReadUInt16BN(this BinaryReader src)
        {
            byte[] buf = src.ReadBytes(2);
            Array.Reverse(buf);
            return BitConverter.ToUInt16(buf, 0);
        }

        public static uint ReadUInt32BN(this BinaryReader src)
        {
            byte[] buf = src.ReadBytes(4);
            Array.Reverse(buf);
            return BitConverter.ToUInt32(buf, 0);
        }

        public static ulong ReadUInt64BN(this BinaryReader src)
        {
            byte[] buf = src.ReadBytes(8);
            Array.Reverse(buf);
            return BitConverter.ToUInt64(buf, 0);
        }
    }
}
