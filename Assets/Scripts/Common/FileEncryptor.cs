using System;
using System.IO;
using System.Security.Cryptography;
using Cysharp.Threading.Tasks;

namespace Common
{
    public class FileEncryptor
    {
        private byte[] _defaultKey =
        {
            0xc9, 0xce, 0xa7, 0x6d, 0x70, 0x28, 0xf2, 0xf9,
            0xc7, 0xab, 0xc7, 0x0b, 0x5c, 0x47, 0xa5, 0x5b,
            0x9f, 0xe9, 0x20, 0xb5, 0x3e, 0xe1, 0x5e, 0x74,
            0x80, 0x37, 0x19, 0x8c, 0x05, 0x76, 0x24, 0x5f
        };
        
        private byte[] _defaultIv = 
        {
            0xc6, 0xb8, 0xbc, 0xc5, 0x72, 0xa2, 0x4a, 0xcc, 
            0x82, 0xdb, 0x68, 0x1e, 0xed, 0x8f, 0x46, 0x56
        };
        
        public async UniTask<string> EncryptAsync(string fileText)
        {
            using var aes = Aes.Create();
            aes.Key = _defaultKey;
            aes.IV = _defaultIv;
            var cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream();
            await using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
            {
                await using (var streamWriter = new StreamWriter(cryptoStream))
                {
                    await streamWriter.WriteAsync(fileText);
                }
            }
            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public async UniTask<string> DecryptAsync(string encryptFileText)
        {
            var bytes = Convert.FromBase64String(encryptFileText);

            using var aes = Aes.Create();
            aes.Key = _defaultKey;
            aes.IV = _defaultIv;
            var decryptor  = aes.CreateDecryptor(aes.Key, aes.IV);
            using var memoryStream = new MemoryStream(bytes);
            await using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cryptoStream);
            return await reader.ReadToEndAsync();
        }
    }

    public class KeyStorage
    {
        private static readonly byte[] AdditionalEntropy = { 9, 8, 7, 6, 5 };
        
    }
}