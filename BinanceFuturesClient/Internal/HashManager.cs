using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GBinanceFuturesClient.Internal
{
    internal static class HashManager
    {
        internal static string HashHMACHex(string keyHex, string message)
        {
            byte[] hash = HashHMAC(StringEncode(keyHex), StringEncode(message));
            return HashEncode(hash);
        }

        private static byte[] HashHMAC(byte[] key, byte[] message)
        {
            var hash = new HMACSHA256(key);
            return hash.ComputeHash(message);
        }

        static string HashEncode(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }

        private static byte[] StringEncode(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        private static byte[] HexDecode(string hex)
        {
            var bytes = new byte[hex.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = byte.Parse(hex.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return bytes;
        }
    }
}
