using CommandLine;
using Salem;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace EncryptionProject
{
    class Program
    {
        
        public class Options
        {
            [Option('f', "file", Required = true, HelpText = "Input files to be encrypted.")]
            public String inputFile
            {
                get; set;
            }

            [Option('k', "key",Required = true, HelpText = "Key used to encrypt file.")]
            public String encryptionKey
            {
                get; set;
            }

            [Option('t', "type", Required = true, HelpText = "Encrypt type used.")]
            public string encryptionType
            {
                get; set;
            }

            [Option('m', "mode", Required = true, HelpText = "Encrypt mode - encrypt/decrypt")]
            public string encryptionMode
            {
                get; set;
            }
        }

        private static Dictionary<String, EncryptMethod> EncryptMethods = new Dictionary<string, EncryptMethod>();
        private static Logger logger = new Logger();
        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                 .WithParsed(RunOptions);
        }

        static void RunOptions(Options options)
        {
            if(options.encryptionType.Contains("AES") && options.encryptionKey.Length != 16)
            {
                logger.Log("Warning", "AES key length must be 16 bytes!");
                return;
            }
            EncryptMethods.Add("XOR", new XOREncryption());
            EncryptMethods.Add("AES", new AESEncryption());
            EncryptMethod encryptMethod;
            if(EncryptMethods.TryGetValue(options.encryptionType, out encryptMethod))
            {
                if (options.encryptionMode.StartsWith("e"))
                {
                    encryptMethod.Encrypt(options.inputFile, options.encryptionKey);

                }
                else if (options.encryptionMode.StartsWith("d"))
                {
                    encryptMethod.Decrypt(options.inputFile, options.encryptionKey);

                }
            }
            else
            {
                logger.Log("Warning", $"Encrypt method with name {options.encryptionKey} does not exist!", options.encryptionKey);   
            }
           

        }

        static void HandleError(IEnumerable<Error> errors)
        {
            errors.Output();
        }
    }
}
