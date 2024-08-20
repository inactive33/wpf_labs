using System.Windows;
using System.Windows.Media;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Input;
namespace wpf_lab12
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class AuthenticationLog : Window
    {
        DataBase database = new DataBase();
        public AuthenticationLog()
        {
            InitializeComponent();
        }
        private void Login_in_Load(object sender, RoutedEventArgs e)
        {
            txtBoxLogin.MaxLength = 50;
        }
        private void Button_Log_Click(object sender, RoutedEventArgs e)
        {
            ConnectionAccount();
        }
        private void ConnectionAccount()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            var loginUser = txtBoxLogin.Text.Trim();
            var passwordUser = passBoxPassword.Password.Trim();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, database.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count == 1) {
                //MessageBox.Show("Вход выполнен!", "Успешно!", MessageBoxButton.OK, MessageBoxImage.Information);
                txtBoxLogin.Background = Brushes.Transparent;
                MainWindow main_win = new MainWindow();
                this.Hide();
                main_win.ShowDialog();
            } else
            {
                txtBoxLogin.ToolTip = "Аккаунт ещё не зарегистрирован!";
                txtBoxLogin.Background = Brushes.PaleVioletRed;
            }
        }

        private void Sign_in_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationReg sign_in = new AuthenticationReg();
            this.Close();
            sign_in.ShowDialog();
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
