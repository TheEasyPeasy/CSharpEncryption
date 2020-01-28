using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting;
using System.Text;

namespace EncryptionProject
{
    class XOREncryption : EncryptMethod
    {

        public override void Decrypt(String PathFile, String EncryptKey)
        {
            byte[] helpBytes = Encoding.UTF8.GetBytes("This is simple text that i use do encrypt bytes of my program");
            byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptKey);
            byte[] fileBytes = File.ReadAllBytes(PathFile);
            for (int i = 0; i < fileBytes.Length; i += 8)
            {
                fileBytes[i] = (byte)(fileBytes[i] ^ 115 ^ helpBytes[0] ^ keyBytes[0]);
                fileBytes[i + 1] = (byte)(fileBytes[i + 1] ^ 62 ^ helpBytes[1] ^ keyBytes[1]);
                fileBytes[i + 2] = (byte)(fileBytes[i + 2] ^ 34 ^ helpBytes[2] ^ keyBytes[2]);
                fileBytes[i + 3] = (byte)(fileBytes[i + 3] ^ 22 ^ helpBytes[3] ^ keyBytes[3]);
                fileBytes[i + 4] = (byte)(fileBytes[i + 4] ^ 92 ^ helpBytes[4] ^ keyBytes[4]);
                fileBytes[i + 5] = (byte)(fileBytes[i + 5] ^ 15 ^ helpBytes[5] ^ keyBytes[5]);
                fileBytes[i + 6] = (byte)(fileBytes[i + 6] ^ 2 ^ helpBytes[6] ^ keyBytes[6]);
                fileBytes[i + 7] = (byte)(fileBytes[i + 7] ^ 43 ^ helpBytes[7] ^ keyBytes[7]);
            }
            File.WriteAllBytes(FileUtil.RenameFile(PathFile, "decrypted"), fileBytes);
        }

        public override void Encrypt(String PathFile, String EncryptKey)
        {
            byte[] helpBytes = Encoding.UTF8.GetBytes("This is simple text that i use do encrypt bytes of my program");
            byte[] keyBytes = Encoding.UTF8.GetBytes(EncryptKey);
            byte[] fileBytes = File.ReadAllBytes(PathFile);
            for (int i = 0; i < fileBytes.Length; i += 8)
            {
                fileBytes[i] = (byte)(fileBytes[i] ^ 115 ^ helpBytes[0] ^ keyBytes[0]);
                fileBytes[i + 1] = (byte)(fileBytes[i + 1] ^ 62 ^ helpBytes[1] ^ keyBytes[1]);
                fileBytes[i + 2] = (byte)(fileBytes[i + 2] ^ 34 ^ helpBytes[2] ^ keyBytes[2]);
                fileBytes[i + 3] = (byte)(fileBytes[i + 3] ^ 22 ^ helpBytes[3] ^ keyBytes[3]);
                fileBytes[i + 4] = (byte)(fileBytes[i + 4] ^ 92 ^ helpBytes[4] ^ keyBytes[4]);
                fileBytes[i + 5] = (byte)(fileBytes[i + 5] ^ 15 ^ helpBytes[5] ^ keyBytes[5]);
                fileBytes[i + 6] = (byte)(fileBytes[i + 6] ^ 2 ^ helpBytes[6] ^ keyBytes[6]);
                fileBytes[i + 7] = (byte)(fileBytes[i + 7] ^ 43 ^ helpBytes[7] ^ keyBytes[7]);
            }
            File.WriteAllBytes(FileUtil.RenameFile(PathFile, "encrypted"), fileBytes);
        }
    }
}
