using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace WSAutomation
{
    class ImageComparer
    {
        public bool IsOK()
        {
            Bitmap img2 = new Bitmap(Environment.CurrentDirectory + "\\output.png");
            ImageConverter converter = new ImageConverter();
            byte[] img2Bytes = (byte[])converter.ConvertTo(img2, typeof(byte[]));

            Bitmap img1 = new Bitmap(Environment.CurrentDirectory + "\\isOK.png");
            byte[] img1Bytes = (byte[])converter.ConvertTo(img1, typeof(byte[]));

            if (CompareImages(img1Bytes, img2Bytes))
            {
                img2.Dispose();
                return true;
            }
            else
            {
                img2.Dispose();
                return false;
            }
        }

        private bool CompareImages(byte[] b1, byte[] b2)
        {
            EqualityComparer<byte> comparer = EqualityComparer<byte>.Default;
            if (b1.Length == b2.Length)
            {
                for (int i = 0; i < b1.Length; i++)
                {
                    if (!comparer.Equals(b1[i], b2[i])) return false;
                }
            }
            else { return false; }

            return true;
        }
    }
}
