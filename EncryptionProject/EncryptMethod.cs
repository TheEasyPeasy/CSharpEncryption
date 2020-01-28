using Salem;
using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptionProject
{
    abstract class EncryptMethod
    {
        Logger logger = new Logger();
        public abstract void Encrypt(String PathFile, String EncryptKey);

        public abstract void Decrypt(String PathFile, String EncryptKey);

    }
}
