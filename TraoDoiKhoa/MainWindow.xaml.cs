using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TraoDoiKhoa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string CORRECT_EMAIL = "Admin@gmail.com";
        private const string CORRECT_PASSWORD = "123456";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (email == CORRECT_EMAIL && password == CORRECT_PASSWORD)
            {
                // Đóng cửa sổ đăng nhập
                this.Hide();

                // Khởi tạo và mở tất cả cửa sổ
                if (ShareWindow.winA == null)
                    ShareWindow.winA = new WindowA();

                if (ShareWindow.winB == null)
                    ShareWindow.winB = new WindowB();

                if (ShareWindow.winC == null)
                    ShareWindow.winC = new TrungTamKhoa();

                ShareWindow.winA.Show();
                ShareWindow.winB.Show();
                ShareWindow.winC.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Email hoặc mật khẩu không đúng!", "Lỗi đăng nhập", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenAllWindows_Click(object sender, RoutedEventArgs e)
        {
            // Khởi tạo cửa sổ nếu chưa tồn tại
            if (ShareWindow.winA == null)
                ShareWindow.winA = new WindowA();

            if (ShareWindow.winB == null)
                ShareWindow.winB = new WindowB();

            if (ShareWindow.winC == null)
                ShareWindow.winC = new TrungTamKhoa();

            // Hiển thị cửa sổ
            ShareWindow.winA.Show();
            ShareWindow.winB.Show();
            ShareWindow.winC.Show();
        }
    }
}