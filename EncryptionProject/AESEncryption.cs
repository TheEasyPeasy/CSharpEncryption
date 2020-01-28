using System;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;
namespace EncryptionProject
{
    class AESEncryption : EncryptMethod
    {
        public override void Decrypt(string PathFile, string EncryptKey)
        {
            byte[] saltBytes = new byte[] { 5, 10, 15, 20, 25, 30, 35, 40 };
            byte[] fileBytes = File.ReadAllBytes(PathFile);
            using MemoryStream memoryStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 128;
            aes.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(EncryptKey, saltBytes, 1000);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            using var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(fileBytes, 0, fileBytes.Length);
            cryptoStream.Close();
            fileBytes = memoryStream.ToArray();
            File.WriteAllBytes(FileUtil.RenameFile(PathFile, "decrypted"), fileBytes);
        }

        public override void Encrypt(string PathFile, string EncryptKey)
        {
            byte[] saltBytes = new byte[] { 5, 10, 15, 20, 25, 30, 35, 40 };
            byte[] fileBytes = File.ReadAllBytes(PathFile);
            using MemoryStream memoryStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = 128;
            aes.BlockSize = 128;
            using var key = new Rfc2898DeriveBytes(EncryptKey, saltBytes, 1000);
            aes.Key = key.GetBytes(aes.KeySize / 8);
            aes.IV = key.GetBytes(aes.BlockSize / 8);
            aes.Mode = CipherMode.CBC;
            using var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(fileBytes, 0, fileBytes.Length);
            cryptoStream.Close();
            fileBytes = memoryStream.ToArray();
            File.WriteAllBytes(FileUtil.RenameFile(PathFile, "encrypted"), fileBytes);
        }
    }
}
