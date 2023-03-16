using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TheCorrectAssignment.Security
{
    public class DataProtection
    {
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16]; // cipher 128 bit
            byte[] array; 

            using (Aes aes = Aes.Create()) // The Advanced Encryption Standard (AES) is a symmetric block cipher chosen by the U.S. goverment.                            
            {
                aes.Key = Encoding.UTF8.GetBytes(key); // now key is 32 bit?
                aes.IV = iv; // is this the cipher? 

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV); // similar to hash algorithm
                                                                                   //Transform: The cryptographic transformation that is to be performed on the stream.

                using (MemoryStream memoryStream = new MemoryStream()) // MemoryStream in C# programs allows you to use in-memory byte arrays or other data as though they are streams.
                                                                       // Instead of storing data in files, you can store data in-memory.
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    // Stream: The stream on which to perform the cryptographic transformation.
                    // CryptoStream is designed to perform transformation from a stream to another stream only and allows transformations chaining.
                    // For instance you can encrypt a data stream then Base 64 encode the encryption output.
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}