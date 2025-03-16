using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiKhoa
{
    public class UnicodeCaesar
    {
        private readonly BigInteger _key;
        private const int UnicodeRangeStart = 32;
        private const int UnicodeRangeEnd = 65535;
        private static readonly BigInteger UnicodeRange = UnicodeRangeEnd - UnicodeRangeStart + 1;

        public UnicodeCaesar(string keyString)
        {
            // Chuyển đổi string thành BigInteger để tránh lỗi overflow
            if (BigInteger.TryParse(keyString, out BigInteger inputKey))
            {
                _key = NormalizeKey(inputKey);
            }
            else
            {
                throw new ArgumentException("Khóa không hợp lệ", nameof(keyString));
            }
        }

        public UnicodeCaesar(BigInteger key)
        {
            _key = NormalizeKey(key);
        }

        private BigInteger NormalizeKey(BigInteger key)
        {
            // Đảm bảo khóa luôn dương
            key = BigInteger.Abs(key);

            // Áp dụng modulo với phạm vi Unicode
            key = key % UnicodeRange;

            // Xử lý trường hợp âm sau khi mod
            if (key < 0)
            {
                key += UnicodeRange;
            }

            return key;
        }

        public string Encrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            char[] result = new char[plainText.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                int charCode = plainText[i];

                if (charCode < UnicodeRangeStart || charCode > UnicodeRangeEnd)
                {
                    result[i] = plainText[i];
                    continue;
                }

                BigInteger normalizedCode = charCode - UnicodeRangeStart;
                BigInteger shiftedCode = (normalizedCode + _key) % UnicodeRange;

                if (shiftedCode < 0)
                    shiftedCode += UnicodeRange;

                result[i] = (char)((int)shiftedCode + UnicodeRangeStart);
            }

            return new string(result);
        }

        public string Decrypt(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            char[] result = new char[cipherText.Length];

            for (int i = 0; i < cipherText.Length; i++)
            {
                int charCode = cipherText[i];

                if (charCode < UnicodeRangeStart || charCode > UnicodeRangeEnd)
                {
                    result[i] = cipherText[i];
                    continue;
                }

                BigInteger normalizedCode = charCode - UnicodeRangeStart;
                BigInteger shiftedCode = (normalizedCode - _key) % UnicodeRange;

                if (shiftedCode < 0)
                    shiftedCode += UnicodeRange;

                result[i] = (char)((int)shiftedCode + UnicodeRangeStart);
            }

            return new string(result);
        }

        // Kiểm tra tính hợp lệ của khóa
        public static (bool isValid, string message) ValidateKey(string keyInput)
        {
            try
            {
                if (BigInteger.TryParse(keyInput, out BigInteger key))
                {
                    if (key == 0)
                    {
                        return (false, "Khóa không thể bằng 0");
                    }

                    BigInteger normalizedKey = key % UnicodeRange;
                    if (key != normalizedKey)
                    {
                        return (true, $"Khóa sẽ được chuẩn hóa thành: {normalizedKey}");
                    }

                    return (true, "Khóa hợp lệ");
                }
                return (false, "Khóa phải là số nguyên");
            }
            catch (Exception)
            {
                return (false, "Khóa không hợp lệ");
            }
        }

        // Lấy khóa đã chuẩn hóa
        public BigInteger GetNormalizedKey()
        {
            return _key;
        }

        // Tạo khóa ngẫu nhiên với số bit chỉ định
        public static BigInteger GenerateRandomKey(int bitLength = 256)
        {
            byte[] bytes = new byte[bitLength / 8];
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return new BigInteger(bytes) % UnicodeRange;
        }
    }
}
