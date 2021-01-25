using System;
using System.IO;

namespace CopyBinaryFile
{
    class StartUp
    {
        static void Main(string[] args)
        {

            using (FileStream reader = new FileStream("../../../copyMe.png", FileMode.Open))
            {
                using (FileStream writer = new FileStream("../../../newFile.png", FileMode.Create))
                {
                    byte[] bufer = new byte[4096];

                    while (reader.CanRead)
                    {
                        int byteRead = reader.Read(bufer, 0, bufer.Length);

                        if (byteRead == 0)
                        {
                            break;
                        }

                        writer.Write(bufer, 0, bufer.Length);
                    }
                }
            }
            
        }
    }
}
