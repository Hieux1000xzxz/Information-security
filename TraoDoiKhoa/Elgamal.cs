using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TraoDoiKhoa
{
    internal class Elgamal
    {
        public BigInteger SoNguyenTo { get; private set; } // Số nguyên tố lớn (p)
        public BigInteger CanNguyenThuy { get; private set; } // Số nguyên căn nguyên thủy (g)
        public BigInteger KhoaBiMat { get; private set; } // Khóa bí mật (x)
        public BigInteger KhoaCongKhai { get; private set; } // Khóa công khai (y)

        public Elgamal()
        {
        }
        public (BigInteger, BigInteger)[] MaHoaVanBanTiengViet(string vanBan)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(vanBan);
            var ketQua = new List<(BigInteger, BigInteger)>();

            foreach (byte b in bytes)
            {
                BigInteger thongDiep = new BigInteger(b);
                // Đảm bảo thông điệp nhỏ hơn p
                if (thongDiep >= SoNguyenTo)
                {
                    throw new Exception("Thông điệp quá lớn");
                }
                var banMa = MaHoaAuto(thongDiep);
                ketQua.Add(banMa);
            }
            return ketQua.ToArray();
        }

        public string GiaiMaVanBanTiengViet((BigInteger, BigInteger)[] banMa)
        {
            var bytes = new List<byte>();
            foreach (var cap in banMa)
            {
                BigInteger giaTri = GiaiMa(cap);
                bytes.Add((byte)giaTri);
            }
            return Encoding.UTF8.GetString(bytes.ToArray());
        }



        public Elgamal(BigInteger SoNguyenTo, BigInteger CanNguyenThuy, BigInteger KhoaBiMat, BigInteger KhoaCongKhai)
        {
            this.SoNguyenTo = SoNguyenTo;
            this.CanNguyenThuy = CanNguyenThuy;
            this.KhoaBiMat = KhoaBiMat;
            this.KhoaCongKhai = KhoaCongKhai;
        }
        public Elgamal(BigInteger SoNguyenTo, BigInteger CanNguyenThuy, BigInteger KhoaCongKhai)
        {
            this.SoNguyenTo = SoNguyenTo;
            this.CanNguyenThuy = CanNguyenThuy;
            this.KhoaCongKhai = KhoaCongKhai;
        }
        public BigInteger luuKhoaBiMat(BigInteger x)
        {
            return this.KhoaBiMat = x;
        }
        // Hàm sinh khóa
        public void SinhKhoa(int kichThuocKhoa)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                // Sinh một số nguyên tố lớn (p)
                SoNguyenTo = SinhSoNguyenToLon(kichThuocKhoa);

                // Chọn g sao cho 1 < g < p
                CanNguyenThuy = TimCanNguyenThuy(SoNguyenTo);

                // Sinh khóa bí mật x (1 < x < p-1)
                KhoaBiMat = SinhSoNgauNhien(2, SoNguyenTo - 2);

                // Tính khóa công khai y = g^x mod p
                KhoaCongKhai = BigInteger.ModPow(CanNguyenThuy, KhoaBiMat, SoNguyenTo);
            }
        }

        // Hàm mã hóa
        public (BigInteger, BigInteger) MaHoaAuto(BigInteger thongDiep)
        {
            // Sinh khóa ngẫu nhiên k (1 < k < p-1)
            BigInteger khoaTam = SinhSoNgauNhien(2, SoNguyenTo - 2);
            // Tính y1 = a^k mod p
            BigInteger y1 = BigInteger.ModPow(CanNguyenThuy, khoaTam, SoNguyenTo);

            // Tính y2 = (thông điệp * y^k) mod p
            BigInteger y2 = (thongDiep * BigInteger.ModPow(KhoaCongKhai, khoaTam, SoNguyenTo)) % SoNguyenTo;

            return (y1, y2);
        }
        public (BigInteger, BigInteger) MaHoa(BigInteger thongDiep, BigInteger p, BigInteger a, BigInteger y, BigInteger k)
        {
            BigInteger y1 = BigInteger.ModPow(a, k, p);

            // Tính y2 = (thông điệp * y^k) mod p
            BigInteger y2 = (thongDiep * BigInteger.ModPow(y, k, p)) % p;
            return (y1, y2);
        }

        // Hàm giải mã
        public BigInteger GiaiMa((BigInteger, BigInteger) banMa)
        {
            BigInteger y1 = banMa.Item1;
            BigInteger y2 = banMa.Item2;

            // Tính y1^x mod p
            BigInteger khoaBiMatNguoc = BigInteger.ModPow(y1, KhoaBiMat, SoNguyenTo);

            // Tìm nghịch đảo của y1^x mod p
            BigInteger nghichDao = ModInverse(khoaBiMatNguoc, SoNguyenTo);

            // Tính thông điệp = (y2 * nghịch đảo) mod p
            BigInteger thongDiep = (y2 * nghichDao) % SoNguyenTo;

            return thongDiep;
        }

        // Sinh số nguyên tố lớn
        public BigInteger SinhSoNguyenToLon(int kichThuoc)
        {
            while (true)
            {
                BigInteger soNgauNhien = SinhSoNgauNhien((BigInteger.One << (kichThuoc - 1)), (BigInteger.One << kichThuoc) - 1);
                if (KiemTraNguyenTo(soNgauNhien))
                {
                    return soNgauNhien;
                }
            }
        }

        // Tìm căn nguyên thủy (primitive root)
        private BigInteger TimCanNguyenThuy(BigInteger p)
        {
            for (BigInteger g = 2; g < p; g++)
            {
                if (KiemTraCanNguyenThuy(g, p))
                {
                    return g;
                }
            }
            throw new Exception("Không tìm thấy căn nguyên thủy.");
        }

        private bool KiemTraCanNguyenThuy(BigInteger g, BigInteger p)
        {
            BigInteger phi = p - 1;
            for (BigInteger i = 2; i * i <= phi; i++)
            {
                if (phi % i == 0)
                {
                    if (BigInteger.ModPow(g, phi / i, p) == 1 || BigInteger.ModPow(g, i, p) == 1)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Kiểm tra số nguyên tố
        public bool KiemTraNguyenTo(BigInteger n)
        {
            if (n < 2) return false;
            for (BigInteger i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        // Sinh số ngẫu nhiên trong khoảng [min, max]
        public BigInteger SinhSoNgauNhien(BigInteger min, BigInteger max)
        {
            byte[] bytes = max.ToByteArray();
            BigInteger soNgauNhien;
            using (var rng = RandomNumberGenerator.Create())
            {
                do
                {
                    rng.GetBytes(bytes);
                    soNgauNhien = new BigInteger(bytes);
                }
                while (soNgauNhien < min || soNgauNhien > max);
            }
            return soNgauNhien;
        }

        // Tìm nghịch đảo modular
        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m, t, q;
            BigInteger x0 = 0, x1 = 1;

            if (m == 1) return 0;

            while (a > 1)
            {
                q = a / m;
                t = m;
                m = a % m; a = t;
                t = x0;
                x0 = x1 - q * x0;
                x1 = t;
            }

            if (x1 < 0)
                x1 += m0;

            return x1;
        }
    }
}

