using System.IO;
using System.Text;

namespace CommandSequenceParser
{
    public static class Extensions
    {
        public static char[] ToFixedCharArray(this string str, int length)
        {
            return str.PadRight(length).ToCharArray();
        }
        
        public static string CharArrayToString(this char[] charArray)
        {
            var str = new string(charArray);
            int length = str.IndexOf('\0');
            if (length > -1)
                str = str.Substring(0, length);
            return str;
        }

        public static string ReadASCIIString(this BinaryReader binReader, int length)
        {
            return ASCIIEncoding.ASCII.GetString(binReader.ReadBytes(length));
        }
    }
}
