using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Front
{
    public static class Cryptography
    {
        public static byte[] AES_Encrypt(byte[] inputFile, string password,string filename)
        {
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            //string outputFile = $"C:/Users/GAMA/source/repos/ShareCrypt/Front/Files/nigga";
              string pre = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads"+$"/";
            string outputFile =pre+ filename;
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            string cryptFile = outputFile;
            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

            RijndaelManaged AES = new RijndaelManaged();

            AES.KeySize = 256;
            AES.BlockSize = 128;


            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.Zeros;

            AES.Mode = CipherMode.CBC;

            CryptoStream cs = new CryptoStream(fsCrypt,
                 AES.CreateEncryptor(),
                CryptoStreamMode.Write);

            foreach (byte b in inputFile)
                cs.WriteByte(b);



            cs.Close();
            fsCrypt.Close();

            byte[] buffer = null;
            using (FileStream fs = new FileStream(outputFile, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;

        }

        public static byte[] AES_Decrypt(byte[] inputFile, string password, string filename)
        {
            byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

            string pre = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads" + $"/";
           // filename= filename.Substring(0, filename.IndexOf('('));

            string outputFile = pre + filename;

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            //FileStream fsCrypt = new FileStream(inputFile);
            MemoryStream fsCrypt = new MemoryStream(inputFile);


            RijndaelManaged AES = new RijndaelManaged();

            AES.KeySize = 256;
            AES.BlockSize = 128;


            var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            AES.Padding = PaddingMode.Zeros;

            AES.Mode = CipherMode.CBC;

            CryptoStream cs = new CryptoStream(fsCrypt,
                AES.CreateDecryptor(),
                CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int data;
            while ((data = cs.ReadByte()) != -1)
                fsOut.WriteByte((byte)data);

            fsOut.Close();
            cs.Close();
            fsCrypt.Close();


            byte[] buffer = null;
            using (FileStream fs = new FileStream(outputFile, FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;

        }
    }
}