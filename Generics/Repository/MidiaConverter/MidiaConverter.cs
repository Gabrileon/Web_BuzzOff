using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.MidiaConverter
{
    public class MidiaConverter
    {
        public static byte[] ToByte(string midiaPath)
        {
            byte[] bytes = File.ReadAllBytes(midiaPath);
            return bytes;
        }

        public static MemoryStream ToMidia(byte[] bytes)
        {
            var midia = new MemoryStream(bytes);
            return midia;
        }
    }
}
