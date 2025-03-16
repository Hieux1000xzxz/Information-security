using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
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
    /// Interaction logic for TrungTamKhoa.xaml
    /// </summary>

    public partial class TrungTamKhoa : Window
    {
        string filePath = @"C:\Users\This MC\OneDrive\Desktop\TraoDoiKhoa\TraoDoiKhoa\DataA.txt";
        string filePath1 = @"C:\Users\This MC\OneDrive\Desktop\TraoDoiKhoa\TraoDoiKhoa\KhoaCuaTrungTam.csv";
        string filePath2 = @"C:\Users\This MC\OneDrive\Desktop\TraoDoiKhoa\TraoDoiKhoa\Share.txt";
        public event Action<string> guiData;
        public TrungTamKhoa()
        {
            InitializeComponent();
        }
        public void SetData(string data)
        {
            khoaNhan.Text = data;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (khoaNhan.Text != "")
            {
                string data = khoaNhan.Text;
                string[] numbers = data.Split(' '); // Tách chuỗi thành mảng dựa trên khoảng trắng
                BigInteger c1 = BigInteger.Parse(numbers[0]);
                BigInteger c2 = BigInteger.Parse(numbers[1]);
                BigInteger c3 = BigInteger.Parse(numbers[2]);
                BigInteger c4 = BigInteger.Parse(numbers[3]);
                BigInteger c5 = BigInteger.Parse(numbers[4]);
                BigInteger c6 = BigInteger.Parse(numbers[5]);

                Elgamal el = new Elgamal(15061129497263, 5, 13451374093507, 14849534664756);

                var ma1 = (c1, c2);
                var ma2 = (c3, c4);
                var ma3 = (c5, c6);
                string p = el.GiaiMa(ma1).ToString();
                string a = el.GiaiMa(ma2).ToString();
                string y = el.GiaiMa(ma3).ToString();
                txtP.Text = p;
                txtA.Text = a;
                txtY.Text = y;
            }
            else
            {
                MessageBoxResult rs = MessageBox.Show("Khóa chưa được gửi đến!", "Lỗi giải mã", MessageBoxButton.OK, MessageBoxImage.Error);

            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (txtIDGuiKhoa.Text == "" || khoaNhan.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Khóa chưa được gửi đến!", "Lỗi giải mã", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BigInteger P = BigInteger.Parse(txtP.Text);
                BigInteger A = BigInteger.Parse(txtA.Text);
                BigInteger Y = BigInteger.Parse(txtY.Text);
                if (txtIDGuiKhoa.Text == "1")
                {
                    SaveKeyExchange.keyA = P + " " + A + " " + Y;
                    try
                    {
                        // Ghi dữ liệu vào file
                        DataModel d = new DataModel();
                        d.id_ = 1;
                        d.Name = "Nguyễn Văn A";
                        d.p = txtP.Text;
                        d.a = txtA.Text;
                        d.y = txtY.Text;
                        CSVHelper csv = new CSVHelper();
                        csv.WriteOrUpdateById(filePath1, d);
                        MessageBox.Show("Dữ liệu đã được lưu vào file an toàn!");
                        txtIDGuiKhoa.Text = "";
                        khoaNhan.Text = "";
                        txtP.Text = "";
                        txtA.Text = "";
                        txtY.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu file: {ex.Message}");
                    }
                }
                else if (txtIDGuiKhoa.Text == "2")
                {
                    SaveKeyExchange.keyB = P + " " + A + " " + Y;
                    try
                    {
                        // Ghi dữ liệu vào file
                        DataModel d = new DataModel();
                        d.id_ = 2;
                        d.Name = "Triệu Thị B";
                        d.p = txtP.Text;
                        d.a = txtA.Text;
                        d.y = txtY.Text;
                        CSVHelper csv = new CSVHelper();
                        csv.WriteOrUpdateById(filePath1, d);
                        MessageBox.Show("Dữ liệu đã được lưu vào file an toàn!");
                        txtIDGuiKhoa.Text = "";
                        khoaNhan.Text = "";
                        txtP.Text = "";
                        txtA.Text = "";
                        txtY.Text = "";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi lưu file: {ex.Message}");
                    }
                }
            }
        } 

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (File.Exists(filePath1))
            {
                try
                {
                    // Mở file bằng trình soạn thảo mặc định
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = filePath1,
                        UseShellExecute = true // Sử dụng trình mặc định của hệ thống
                    });
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi khi mở file
                    MessageBox.Show($"Lỗi mở file: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Thông báo khi file không tồn tại
                MessageBox.Show("File không tồn tại.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private bool checkLayKhoa()
        {
            if (txtIDLay.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("ID không được để trống!", "Lỗi lấy khóa"
               , MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (int.Parse(txtIDLay.Text) <= 0 || int.Parse(txtIDLay.Text) >= 3)
            {
                MessageBoxResult result = MessageBox.Show("ID không tồn tại!", "Lỗi lấy khóa"
              , MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
           
            return true; 
        }

            private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkLayKhoa())
                {
                    if (txtIDLay.Text == "1")
                    {
                        CSVHelper csv = new CSVHelper();
                        DataModel d = new DataModel();
                        d = csv.ReadById(filePath1, 1);
                        // Loại bỏ dấu ngoặc
                        BigInteger p = BigInteger.Parse(d.p);
                        BigInteger a = BigInteger.Parse(d.a);
                        BigInteger y = BigInteger.Parse(d.y);
                        txtPLay.Text = p.ToString();
                        txtALay.Text = a.ToString();
                        txtYLay.Text = y.ToString();
                    }
                    if (txtIDLay.Text == "2")
                    {
                        CSVHelper csv = new CSVHelper();
                        DataModel d = new DataModel();
                        d = csv.ReadById(filePath1, 2);
                        // Loại bỏ dấu ngoặc
                        BigInteger p = BigInteger.Parse(d.p);
                        BigInteger a = BigInteger.Parse(d.a);
                        BigInteger y = BigInteger.Parse(d.y);
                        txtPLay.Text = p.ToString();
                        txtALay.Text = a.ToString();
                        txtYLay.Text = y.ToString();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Hãy đóng file khóa trước khi lấy khóa!", "Lấy khóa", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (txtPLay.Text == "" || txtALay.Text == "" || txtYLay.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Chưa có dữ liệu!", "Lỗi mã hóa", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BigInteger pg = BigInteger.Parse(txtPLay.Text);
                BigInteger ag = BigInteger.Parse(txtALay.Text);
                BigInteger yg = BigInteger.Parse(txtYLay.Text);
                Elgamal el = new Elgamal(15061129497263, 5, 8751742992449, 8751742992449);
                (BigInteger c1, BigInteger c2) = el.MaHoaAuto(pg);
                (BigInteger c3, BigInteger c4) = el.MaHoaAuto(ag);
                (BigInteger c5, BigInteger c6) = el.MaHoaAuto(yg);
                string dataMaHoa = c1 + " " + c2 + " " + c3 + " " + c4 + " " + c5 + " " + c6;
                string data = yeuCau.Text;

                var x = el.MaHoaVanBanTiengViet(data);
                MessageBoxResult result = MessageBox.Show("Khóa và yêu cầu được mã hóa thành công!", "Mã hóa khóa và yêu cầu"
                    , MessageBoxButton.OK, MessageBoxImage.Information);
                SharedData.yc = x;
                string y = "";
                foreach (var i in x)
                {
                    y +=" "+i.Item1 + " " + i.Item2;
                }
                dataMaHoa += y;
                khoaGui.Text = dataMaHoa;
            }

        }
        private bool checkGuiKhoa()
        {
            if (txtIDGui.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("ID không được bỏ trống!", "Lỗi"
               , MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (int.Parse(txtIDGui.Text) <=0 || int.Parse(txtIDGui.Text) >= 3)
            {

                MessageBoxResult result = MessageBox.Show("ID không tồn tại!", "Lỗi"
               , MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (khoaGui.Text == "")
            {
                MessageBoxResult result = MessageBox.Show("Khóa không tồn tại hoặc chưa được mã hóa!", "Lỗi"
               , MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (txtIDLay.Text == txtIDGui.Text )
            {
                MessageBoxResult result = MessageBox.Show("ID nhận khóa không được trùng với ID lấy khóa!", "Lỗi"
               , MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
            
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (checkGuiKhoa())
            {
                if (int.Parse(txtIDGui.Text) == 1)
                {
               
                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn gửi khóa công khai cho ID này không?", "Gửi khóa"
               , MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes) {
                        SharedData.Data1 = khoaGui.Text;
                        ShareWindow.winA.khoaMaHoa.Text = khoaGui.Text;
                        MessageBoxResult rs = MessageBox.Show("Gửi khóa thành công cho ID trên!", "Gửi khóa thành công"
              , MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    khoaGui.Text = "";
                    yeuCau.Text = "";
                }

                if (int.Parse(txtIDGui.Text) == 2)
                {
                    MessageBoxResult result = MessageBox.Show("Bạn có chắc chắn gửi khóa công khai cho ID này không?", "Gửi khóa"
             , MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        SharedData.Data2 = khoaGui.Text;
                        ShareWindow.winB.khoaMaHoa.Text = khoaGui.Text;
                        MessageBoxResult rs = MessageBox.Show("Gửi khóa thành công cho ID trên!", "Gửi khóa thành công"
              , MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    khoaGui.Text = "";
                    yeuCau.Text = "";

                }
            }
        }
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (yeuCau.Text != "")
            {
                Elgamal el = new Elgamal(15061129497263, 5, 13451374093507, 14849534664756);
                var y = SharedData.Banma;
                var k = el.GiaiMaVanBanTiengViet(y);
                yeuCau.Text = k;
            }
            else
            {
                MessageBoxResult rs = MessageBox.Show("Không có yêu cầu nào được gửi đến!", "Lỗi giải mã yêu cầu", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }
    }
}
