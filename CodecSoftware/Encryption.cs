using System;
using System.Security.Cryptography;
using System.Text;

public class CODEC
{
    private static readonly byte[] _salt = Encoding.Unicode.GetBytes("Your random salt goes here!");

    public static void Encrypt(string plainText, string password)
    {
        byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

        using (Aes aes = Aes.Create())
        {
            Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, _salt);
            aes.Key = keyDerivation.GetBytes(aes.KeySize / 8);
            aes.IV = keyDerivation.GetBytes(aes.BlockSize / 8);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                    cs.FlushFinalBlock();
                }
                byte[] cipherBytes = ms.ToArray();
                Console.WriteLine(Convert.ToBase64String(cipherBytes));
                return;
            }
        }
    }

    public static void Decrypt(string cipherText, string password)
    {
        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, _salt);
            aes.Key = keyDerivation.GetBytes(aes.KeySize / 8);
            aes.IV = keyDerivation.GetBytes(aes.BlockSize / 8);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.FlushFinalBlock();
                }
                byte[] plainBytes = ms.ToArray();
                Console.WriteLine(Encoding.Unicode.GetString(plainBytes));
                return;
            }
        }
    }
}
