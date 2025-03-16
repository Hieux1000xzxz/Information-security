using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TraoDoiKhoa
{
    /// <summary>
    /// Interaction logic for KenhTraoDoiKhoa.xaml
    /// </summary>
    public partial class KenhTraoDoiKhoa : Window
    {
        string filePath1 = @"C:\Users\This MC\OneDrive\Desktop\TraoDoiKhoa\TraoDoiKhoa\DataA.txt";
        string filePath2 = @"C:\Users\This MC\OneDrive\Desktop\TraoDoiKhoa\TraoDoiKhoa\DataB.txt";
        public KenhTraoDoiKhoa()
        {
            InitializeComponent();
        }
        public void Window_Load(object sender, EventArgs e)
        {
            LayKhoa();
        }

        public void LayKhoa()
        {
            txtPA.Text = ShareWindow.winB.txtPB.Text;
            txtAA.Text = ShareWindow.winB.txtAB.Text;
            txtYA.Text = ShareWindow.winB.txtYB.Text;
            txtPB.Text = ShareWindow.winA.txtPB.Text;
            txtAB.Text = ShareWindow.winA.txtAB.Text;
            txtYB.Text = ShareWindow.winA.txtYB.Text;
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tdg1.Text == "Nhập nội dung gửi...")
            {
                tdg1.Text = "";
                tdg1.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black); // Đổi màu chữ thành đen
                tdg1.FontStyle = System.Windows.FontStyles.Normal; // Đổi kiểu chữ
            }

        }
        private void TextBox1_GotFocus(object sender, RoutedEventArgs e)
        {

            if (tdg2.Text == "Nhập nội dung gửi...")
            {
                tdg2.Text = "";
                tdg2.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black); // Đổi màu chữ thành đen
                tdg2.FontStyle = System.Windows.FontStyles.Normal; // Đổi kiểu chữ
            }
        }

        // Khi TextBox mất focus, nếu không có dữ liệu thì hiển thị lại chữ gợi ý
        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tdg1.Text))
            {
                tdg1.Text = "Nhập nội dung gửi...";
                tdg1.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray); // Đổi màu chữ thành mờ
                tdg1.FontStyle = System.Windows.FontStyles.Italic; // Đổi kiểu chữ thành nghiêng
            }
        }
        private void TextBox1_LostFocus(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tdg2.Text))
            {
                tdg2.Text = "Nhập nội dung gửi...";
                tdg2.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Gray); // Đổi màu chữ thành mờ
                tdg2.FontStyle = System.Windows.FontStyles.Italic; // Đổi kiểu chữ thành nghiêng
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkKhoaCkB())
                {
                    if (tdg1.Text == "Nhập nội dung gửi...")
                    {
                        MessageBoxResult rs = MessageBox.Show("Bạn chưa nhập thông điệp!", "Không thể gửi thông điệp", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        string data = tdg1.Text;
                        Elgamal el = new Elgamal(BigInteger.Parse(txtPB.Text), BigInteger.Parse(txtAB.Text), 0, BigInteger.Parse(txtYB.Text));
                        var x = el.MaHoaVanBanTiengViet(data);
                        string y = "";
                        foreach (var i in x)
                        {
                            y += i.Item1 + "\n" + i.Item2 + "\n";
                        }
                        tdn2.Text = y;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi");
            }
        }
        private bool checkKhoaCkB()
        {
            if(txtPB.Text == "" || txtAB.Text == "" || txtYB.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Khóa công khai của đối tác chưa đúng!", "Lỗi lấy khóa công khai", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private bool checkKhoaCkA()
        {
            if (txtPA.Text == "" || txtAA.Text == "" || txtYA.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Khóa công khai của đối tác chưa đúng!", "Lỗi lấy khóa công khai", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tdn2.Text != "")
                {
                    if (File.Exists(filePath2))
                    {
                        string[] lines = File.ReadAllLines(filePath2);
                        string data = tdg1.Text;
                        string khoa = lines[2].ToString();
                        Elgamal el = new Elgamal(BigInteger.Parse(txtPB.Text), BigInteger.Parse(txtAB.Text), BigInteger.Parse(khoa), BigInteger.Parse(txtYB.Text));
                        var x = el.MaHoaVanBanTiengViet(data);
                        string y = el.GiaiMaVanBanTiengViet(x);
                        tdn2.Text = y;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khóa!");
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin chưa được gửi đến!", "Lỗi giải mã", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi");

            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkKhoaCkA())
                {
                    if (tdg2.Text == "Nhập nội dung gửi...")
                    {
                        MessageBoxResult rs = MessageBox.Show("Bạn chưa nhập thông điệp!", "Không thể gửi thông điệp", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        string data = tdg2.Text;
                        Elgamal el = new Elgamal(BigInteger.Parse(txtPA.Text), BigInteger.Parse(txtAA.Text), 0, BigInteger.Parse(txtYA.Text));
                        var x = el.MaHoaVanBanTiengViet(data);
                        string y = "";
                        foreach (var i in x)
                        {
                            y += i.Item1 + "\n" + i.Item2 + "\n";
                        }
                        tdn1.Text = y;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");

            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tdn1.Text != "")
                {
                    if (File.Exists(filePath1))
                    {
                        string[] lines = File.ReadAllLines(filePath1);
                        string data = tdg2.Text;
                        string khoa = lines[2].ToString();
                        Elgamal el = new Elgamal(BigInteger.Parse(txtPA.Text), BigInteger.Parse(txtAA.Text), BigInteger.Parse(khoa), BigInteger.Parse(txtYA.Text));
                        var x = el.MaHoaVanBanTiengViet(data);
                        string y = el.GiaiMaVanBanTiengViet(x);
                        tdn1.Text = y;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy khóa!");
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin chưa được gửi đến!", "Lỗi giải mã", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi");

            }
        }

        private void rada2_Checked(object sender, RoutedEventArgs e)
        {
            Elgamal el = new Elgamal();
            el.SinhKhoa(41);
            txtp1.Text = el.SoNguyenTo.ToString();
            txta1.Text = el.CanNguyenThuy.ToString();
            txtp1.IsReadOnly = true;
            txta1.IsReadOnly = true;
        }

        private void rada1_Checked(object sender, RoutedEventArgs e)
        {
            txtp1.Text = "";
            txta1.Text = "";
            txtp1.IsReadOnly = false;
            txta1.IsReadOnly = false;
        }

        private void rada3_Checked(object sender, RoutedEventArgs e)
        {
            txtKhoa1.Text = "";
            txtKhoa1.IsReadOnly = false;
        }

        private void rada4_Checked(object sender, RoutedEventArgs e)
        { 
            Elgamal el = new Elgamal();
            el.SinhKhoa(41);
            txtKhoa1.Text = el.SinhSoNgauNhien(99, 1000000).ToString();
            txtKhoa1.IsReadOnly = true;
        }

        private void rada1b_Checked(object sender, RoutedEventArgs e)
        {
            txtp2.Text = "";
            txta2.Text = "";
            txtp2.IsReadOnly = false;
            txta2.IsReadOnly = false;
        }

        private void rada2b_Checked(object sender, RoutedEventArgs e)
        {
            Elgamal el = new Elgamal();
            el.SinhKhoa(41);
            txtp2.Text = el.SoNguyenTo.ToString();
            txta2.Text = el.CanNguyenThuy.ToString();
            txtp2.IsReadOnly = true;
            txta2.IsReadOnly = true;
        }

        private void rada3b_Checked(object sender, RoutedEventArgs e)
        {
            txtKhoa2.Text = "";
            txtKhoa2.IsReadOnly = false;
        }

        private void rada4b_Checked(object sender, RoutedEventArgs e)
        {
            Elgamal el = new Elgamal();
            el.SinhKhoa(41);
            txtKhoa2.Text = el.SinhSoNgauNhien(99, 1000000).ToString();
            txtKhoa2.IsReadOnly = true;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (txtp1.Text == "" || txta1.Text == "" || txtKhoa1.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Bạn chưa nhập đủ tham số!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                txtA.Text = BigInteger.ModPow(BigInteger.Parse(txta1.Text), BigInteger.Parse(txtKhoa1.Text), BigInteger.Parse(txtp1.Text)).ToString();
                txtAk.Text = txtA.Text;
            }
        }

        private void btngui_Click(object sender, RoutedEventArgs e)
        {
            if (txtp1.Text == "" || txta1.Text == "") {
                MessageBoxResult rs = MessageBox.Show("Chưa tạo p và q", "Lỗi gửi tham số", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn sử dụng p và q này làm tham số công khai chung không?", "Tham số", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rs == MessageBoxResult.Yes)
                {
                    txtp2.Text = txtp1.Text;
                    txta2.Text = txta1.Text;
                }
            }
        }

        private void btnguib_Click(object sender, RoutedEventArgs e)
        {

            if (txtp2.Text == "" || txta2.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Chưa tạo p và q", "Lỗi gửi tham số", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBoxResult rs = MessageBox.Show("Bạn có chắc chắn sử dụng p và q này làm tham số công khai chung không?", "Tham số", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rs == MessageBoxResult.Yes)
                {
                    txtp1.Text = txtp2.Text;
                    txta1.Text = txta2.Text;
                }
            }
          
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (txtp1.Text == "" || txta1.Text == "" || txtKhoa1.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Bạn chưa nhập đủ tham số!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                txtB.Text = BigInteger.ModPow(BigInteger.Parse(txta2.Text), BigInteger.Parse(txtKhoa2.Text), BigInteger.Parse(txtp2.Text)).ToString();
                txtBA.Text = txtB.Text;
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (txtp1.Text == "" || txtKhoa1.Text == "" || txtBA.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Bạn chưa nhập đủ tham số!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                txtK1.Text = BigInteger.ModPow(BigInteger.Parse(txtBA.Text), BigInteger.Parse(txtKhoa1.Text), BigInteger.Parse(txtp1.Text)).ToString();
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (txtp2.Text == "" || txtKhoa2.Text == "" || txtAk.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Bạn chưa nhập đủ tham số!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            else
            {
                txtK2.Text = BigInteger.ModPow(BigInteger.Parse(txtAk.Text), BigInteger.Parse(txtKhoa2.Text), BigInteger.Parse(txtp2.Text)).ToString();
            }
            
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            try
            {
                if (k1 != "")
                {
                    string plainText = tdgk1.Text; // Thông điệp cần mã hóa
                    string rawKey = k1; // Khóa ngắn
                    string key = PadKey(rawKey, 16); // Hoặc HashKey(rawKey, 16)
                    string iv = "6543210987654321";  // Vector khởi tạo (16 ký tự)
                    string encrypted = EncryptAES(plainText, key, iv);
                    tdnk2.Text = encrypted;
                }
                else
                {
                    MessageBox.Show("Chưa có khóa K", "Lỗi mã hóa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi");

            }
        }


        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            try
            {
                if (k2 != "")
                {
                    string rawKey = k2; // Khóa ngắn
                    string key = PadKey(rawKey, 16); // Hoặc HashKey(rawKey, 16)
                    string iv = "6543210987654321";  // Vector khởi tạo (16 ký tự)
                    string decrypted = DecryptAES(tdnk2.Text, key, iv);
                    tdnk2.Text = decrypted;
                }
                else
                {
                    MessageBox.Show("Chưa có khóa K", "Lỗi mã hóa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thông điệp đã được giải mã rồi!!","Giải mã",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            try
            {
                if (k2 != "")
                {
                    string plainText = tdgk2.Text; // Thông điệp cần mã hóa
                    string rawKey = k2; // Khóa ngắn
                    string key = PadKey(rawKey, 16); // Hoặc HashKey(rawKey, 16)
                    string iv = "6543210987654321";  // Vector khởi tạo (16 ký tự)
                    string encrypted = EncryptAES(plainText, key, iv);
                    tdnk1.Text = encrypted;
                }
                else
                {
                    MessageBox.Show("Chưa có khóa K", "Lỗi mã hóa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi");

            }
        }

            private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            try {
                if (k1 != "")
                {
                    string rawKey = k1; // Khóa ngắn
                    string key = PadKey(rawKey, 16); // Hoặc HashKey(rawKey, 16)
                    string iv = "6543210987654321";  // Vector khởi tạo (16 ký tự)
                    string decrypted = DecryptAES(tdnk1.Text, key, iv);
                    tdnk1.Text = decrypted;
                }
                else
                {
                    MessageBox.Show("Chưa có khóa K", "Lỗi mã hóa", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thông điệp đã được giải mã rồi!!", "Giải mã", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private static string k1 ="";
        private static string k2 ="";
        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            
            MessageBoxResult rs = MessageBox.Show("Bạn có chắn chắn dùng khóa K này làm khóa chung không?", "Sử dụng khóa K", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (rs == MessageBoxResult.Yes) { 
                k1 = txtK1.Text;
            }
           
        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Bạn có chắn chắn dùng khóa K này làm khóa chung không?", "Sử dụng khóa K", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (rs == MessageBoxResult.Yes)
            {
                k2 = txtK2.Text;
            }
        }
        static string PadKey(string key, int requiredLength)
        {
            if (key.Length >= requiredLength)
                return key.Substring(0, requiredLength);
            return key.PadRight(requiredLength, '0');
        }

        static string EncryptAES(string plainText, string key, string iv)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                using (var encryptStream = new System.IO.MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(encryptStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var writer = new System.IO.StreamWriter(cryptoStream))
                        {
                            writer.Write(plainText);
                        }
                    }
                    return Convert.ToBase64String(encryptStream.ToArray());
                }
            }
        }

        static string DecryptAES(string cipherText, string key, string iv)
        {
            try 
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(PadKey(key, 16));
                    aes.IV = Encoding.UTF8.GetBytes(iv);
                    aes.Padding = PaddingMode.PKCS7;  // Đảm bảo padding mode phù hợp
                    aes.Mode = CipherMode.CBC;        // Đảm bảo cipher mode phù hợp

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (var decryptStream = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                    using (var cryptoStream = new CryptoStream(decryptStream, decryptor, CryptoStreamMode.Read))
                    using (var reader = new System.IO.StreamReader(cryptoStream, Encoding.UTF8, true))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch (CryptographicException)
            {
                // Tạo chuỗi nhiễu ngẫu nhiên
                Random random = new Random();
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+";
                return new string(Enumerable.Repeat(chars, 20)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
            }
        }
    }
}
