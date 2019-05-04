using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace AI_Sports.AISports.Util
{
    public class AesUtil
    {
        /// <summary> 
        /// AES加密 
        /// </summary> 
        /// <param name="Data">被加密的明文</param> 
        /// <param name="Key">密钥</param> 
        /// <param name="Vector">向量</param> 
        /// <returns>密文</returns> 
        public static Byte[] Encrypt(Byte[] Data, String Key, String Vector)
        {
            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.GetEncoding("GBK").GetBytes(Key.PadRight(bKey.Length)), bKey, bKey.Length);
            Byte[] bVector = new Byte[16];
            Array.Copy(Encoding.GetEncoding("GBK").GetBytes(Vector.PadRight(bVector.Length)), bVector, bVector.Length);


            Byte[] Cryptograph = null; // 加密后的密文 


            Rijndael Aes = Rijndael.Create();
            try
            {
                // 开辟一块内存流 
                using (MemoryStream Memory = new MemoryStream())
                {
                    // 把内存流对象包装成加密流对象 
                    using (CryptoStream Encryptor = new CryptoStream(Memory,
                     Aes.CreateEncryptor(bKey, bVector),
                     CryptoStreamMode.Write))
                    {
                        // 明文数据写入加密流 
                        Encryptor.Write(Data, 0, Data.Length);
                        Encryptor.FlushFinalBlock();


                        Cryptograph = Memory.ToArray();
                    }
                }
            }
            catch
            {
                Cryptograph = null;
            }


            return Cryptograph;
        }


        /// <summary> 
        /// AES解密 
        /// </summary> 
        /// <param name="Data">被解密的密文</param> 
        /// <param name="Key">密钥</param> 
        /// <param name="Vector">向量</param> 
        /// <returns>明文</returns> 
        public static Byte[] Decrypt(Byte[] Data, String Key, String Vector)
        {
            Byte[] bKey = new Byte[32];
            Array.Copy(Encoding.GetEncoding("GBK").GetBytes(Key.PadRight(bKey.Length)), bKey, bKey.Length);
            Byte[] bVector = new Byte[16];
            Array.Copy(Encoding.GetEncoding("GBK").GetBytes(Vector.PadRight(bVector.Length)), bVector, bVector.Length);


            Byte[] original = null; // 解密后的明文 


            Rijndael Aes = Rijndael.Create();
            try
            {
                // 开辟一块内存流，存储密文 
                using (MemoryStream Memory = new MemoryStream(Data))
                {
                    // 把内存流对象包装成加密流对象 
                    using (CryptoStream Decryptor = new CryptoStream(Memory,
                    Aes.CreateDecryptor(bKey, bVector),
                    CryptoStreamMode.Read))
                    {
                        // 明文存储区 
                        using (MemoryStream originalMemory = new MemoryStream())
                        {
                            Byte[] Buffer = new Byte[1024];
                            Int32 readBytes = 0;
                            while ((readBytes = Decryptor.Read(Buffer, 0, Buffer.Length)) > 0)
                            {
                                originalMemory.Write(Buffer, 0, readBytes);
                            }


                            original = originalMemory.ToArray();
                        }
                    }
                }
            }
            catch
            {
                original = null;
            }


            return original;
        }


        /// <summary>
        /// 不使用向量方式解密
        /// </summary>
        /// <param name="encryptedBytes"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] Decrypt(byte[] encryptedBytes, byte[] key)
        {
            MemoryStream mStream = new MemoryStream(encryptedBytes);
            //mStream.Write( encryptedBytes, 0, encryptedBytes.Length ); 
            //mStream.Seek( 0, SeekOrigin.Begin ); 
            RijndaelManaged aes = new RijndaelManaged();
            aes.Mode = CipherMode.ECB;
            aes.BlockSize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = key;
            //aes.IV = _iV; 
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            try
            {
                byte[] tmp = new byte[encryptedBytes.Length + 32];
                int len = cryptoStream.Read(tmp, 0, encryptedBytes.Length + 32);
                byte[] ret = new byte[len];
                Array.Copy(tmp, 0, ret, 0, len);
                return ret;
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }

        /// <summary>
        /// 不使用向量方式加密
        /// </summary>
        /// <param name="plainBytes"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static byte[] Encrypt(byte[] plainBytes, byte[] key)
        {
            MemoryStream mStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();


            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.BlockSize = 128;
            //aes.Key = _key; 


            aes.Key = key;
            //aes.IV = _iV; 
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            try
            {
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();
                return mStream.ToArray();
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }

    }
}
