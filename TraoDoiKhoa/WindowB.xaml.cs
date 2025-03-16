using System;
using System.Collections.Generic;
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
    /// Interaction logic for WindowB.xaml
    /// </summary>
    public partial class WindowB : Window
    {
        public event Action<string> DataChanged;

        string filePath = @"C:\Users\This MC\OneDrive\Desktop\TraoDoiKhoa\TraoDoiKhoa\DataB.txt";
        string filePath1 = @"C:\Users\This MC\OneDrive\Desktop\TraoDoiKhoa\TraoDoiKhoa\KhoaCuaTrungTam.txt";
        public WindowB()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBoxResult rs = MessageBox.Show("Bạn có muốn sinh khóa tự động không?", "Sinh khóa tự động", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rs == MessageBoxResult.Yes)
            {
                Elgamal el = new Elgamal();
                el.SinhKhoa(42);
                txtP.Text = el.SoNguyenTo.ToString();
                txtA.Text = el.CanNguyenThuy.ToString();
                txtX.Text = el.KhoaBiMat.ToString();
            }
        }
        private bool checkTaoKhoa()
        {
            Elgamal el = new Elgamal();
            if (txtP.Text == "" || txtA.Text == "" || txtX.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Bạn bạn phải nhập đủ các trường p, a, x!", "Lỗi tạo khóa y", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (el.KiemTraNguyenTo(BigInteger.Parse(txtP.Text)) == false)
            {
                MessageBoxResult rs = MessageBox.Show("p không phải là số nguyên tố!", "Lỗi tạo khóa y", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (BigInteger.Parse(txtX.Text) > BigInteger.Parse(txtP.Text))
            {
                MessageBoxResult rs = MessageBox.Show("x phải nhỏ hơn p!", "Lỗi tạo khóa y", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!BigInteger.TryParse(txtP.Text, out BigInteger p) || p <= 0)
            {
                MessageBoxResult rs = MessageBox.Show("p phải là số nguyên và lớn hơn 0", "Lỗi tạo khóa y", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!BigInteger.TryParse(txtA.Text, out BigInteger a) || a <= 0)
            {
                MessageBoxResult rs = MessageBox.Show("a phải là số nguyên và lớn hơn 0", "Lỗi tạo khóa y", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!BigInteger.TryParse(txtX.Text, out BigInteger x) || x <= 0)
            {
                MessageBoxResult rs = MessageBox.Show("x phải là số nguyên và lớn hơn 0", "Lỗi tạo khóa y", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (checkTaoKhoa() == true)
                {
                    BigInteger P = BigInteger.Parse(txtP.Text);
                    BigInteger A = BigInteger.Parse(txtA.Text);
                    BigInteger X = BigInteger.Parse(txtX.Text);
                    BigInteger KhoaCongKhai = BigInteger.ModPow(A, X, P);
                    try
                    {
                        // Ghi dữ liệu vào file
                        using (StreamWriter writer = new StreamWriter(filePath, false)) // false để ghi đè
                        {
                            writer.WriteLine(P); // Ghi giá trị từ P
                            writer.WriteLine(A); // Ghi giá trị từ A
                            writer.WriteLine(X); // Ghi giá trị từ X
                            writer.WriteLine(KhoaCongKhai);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    // Đọc toàn bộ nội dung từ file
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length >= 4)
                    {
                        // Gán giá trị vào các TextBox
                        txtY.Text = lines[3];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có muốn tạo lại khóa không", "Tạo lại khóa"
                , MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                txtP.Text = "";
                txtA.Text = "";
                txtX.Text = "";
                txtY.Text = "";
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                BigInteger p = BigInteger.Parse(txtP.Text);
                BigInteger a = BigInteger.Parse(txtA.Text);
                BigInteger y = BigInteger.Parse(txtY.Text);
                Elgamal el = new Elgamal(15061129497263, 5, 13451374093507, 14849534664756);
                (BigInteger c1, BigInteger c2) = el.MaHoaAuto(p);
                (BigInteger c3, BigInteger c4) = el.MaHoaAuto(a);
                (BigInteger c5, BigInteger c6) = el.MaHoaAuto(y);
                string data = c1 + " " + c2 + " " + c3 + " " + c4 + " " + c5 + " " + c6;

                // Tạo một instance của WindowB và truyền dữ liệu

                ShareWindow.winC.SetData(data);
                ShareWindow.winC.txtIDGuiKhoa.Text = "2";
                // Hiển thị WindowB
                MessageBox.Show("Khóa công khai của bạn đã được mã hóa và gửi đến trung tâm trao đổi khóa!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi gửi: {ex.Message}");
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (txtID.Text != "")
            {
                string data = txtID.Text + "\n" + DateTime.Now;
                Elgamal el = new Elgamal(15061129497263, 5, 13451374093507, 14849534664756);
                var x = el.MaHoaVanBanTiengViet(data);
                MessageBoxResult result = MessageBox.Show("Gửi yêu cầu thành công!", "Thành công"
                    , MessageBoxButton.OK, MessageBoxImage.Information);
                SharedData.Banma = x;
                string y = "";
                foreach (var i in x)
                {
                    y += i.Item1 + "\n" + i.Item2 + "\n" ;
                }
                ShareWindow.winC.yeuCau.Text ="ID2:\n" + y;
            }
            else
            {
                MessageBoxResult rs = MessageBox.Show("Yêu cầu không được để trống", "Lỗi gửi yêu cầu", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private string pb, ab, yb;
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if (khoaMaHoa.Text != "")
                {
                    string data = khoaMaHoa.Text;
                    string[] numbers = data.Split(' '); // Tách chuỗi thành mảng dựa trên khoảng trắng
                    BigInteger c1 = BigInteger.Parse(numbers[0]);
                    BigInteger c2 = BigInteger.Parse(numbers[1]);
                    BigInteger c3 = BigInteger.Parse(numbers[2]);
                    BigInteger c4 = BigInteger.Parse(numbers[3]);
                    BigInteger c5 = BigInteger.Parse(numbers[4]);
                    BigInteger c6 = BigInteger.Parse(numbers[5]);
                    Elgamal el = new Elgamal(15061129497263, 5, 14849534664756, 14849534664756);
                    var ma1 = (c1, c2);
                    var ma2 = (c3, c4);
                    var ma3 = (c5, c6);
                    pb = el.GiaiMa(ma1).ToString();
                    ab = el.GiaiMa(ma2).ToString();
                    yb = el.GiaiMa(ma3).ToString();
                    string x = $"\np = {pb}\na = {ab}\nx = {yb}";
                    string y = el.GiaiMaVanBanTiengViet(SharedData.yc);
                    y = y + x;
                    khoaMaHoa.Text = y;
                }
                else
                {
                    MessageBoxResult rs = MessageBox.Show("Khóa và thông điệp chưa được gửi đến", "Lỗi giải mã", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thông điệp đã được giải mã rồi!!", "Giải mã", MessageBoxButton.OK, MessageBoxImage.Warning);

            }



        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (SharedData.Data2 == null || pb == null)
            {
                MessageBoxResult result = MessageBox.Show("Khóa chưa được gửi đến hoặc giải mã!", "Lỗi"
               , MessageBoxButton.OK, MessageBoxImage.Error);


            }
            else
            {
                txtPB.Text = pb;
                txtAB.Text = ab;
                txtYB.Text = yb;
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (txtIDB.Text == "2")
            {
                MessageBoxResult rs = MessageBox.Show("ID này trùng với ID của bạn!", "Lỗi kết nối", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtIDB.Text != "1")
            {
                MessageBoxResult rs = MessageBox.Show("ID này không tồn tại trong hệ thống!", "Lỗi kết nối", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (txtPB.Text == "" || txtAB.Text == "" || txtYB.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Bạn chưa nhập khóa công khai của đối tác!", "Lỗi kết nối", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                yeuCau.Items.Add($"Bạn đang kết nối tới đối tác có ID = 1 ...!");
                yeuCau.Items.Add($"Vui lòng chờ xác nhận!");
                ShareWindow.winA.but.Background = Brushes.Green;
                ShareWindow.winA.but.Foreground = Brushes.White;
                ShareWindow.winA.yeuCau.Items.Add("B đang muốn kết nối với bạn!"); ;
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (txtPB.Text == "" || txtAB.Text == "" || txtYB.Text == "")
            {
                MessageBoxResult rs = MessageBox.Show("Bạn chưa nhập khóa công khai của đối tác!", "Lỗi kết nối", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else {
                if (but.Background == Brushes.Green)
                {
                    KenhTraoDoiKhoa x = new KenhTraoDoiKhoa();
                    x.Show();
                }
                else
                {
                    MessageBoxResult rs = MessageBox.Show("Chưa có ai muốn kết nối với bạn!", "Lỗi kết nối", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
           
        }
    }
}
