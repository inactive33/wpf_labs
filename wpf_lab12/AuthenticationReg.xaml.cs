using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace wpf_lab12
{
    /// <summary>
    /// Логика взаимодействия для Authentication.xaml
    /// </summary>
    public partial class AuthenticationReg : Window
    {
        DataBase database = new DataBase();
        public AuthenticationReg()
        {
            InitializeComponent();
        }
        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            RegistrationAccount();
        }
        private void RegistrationAccount()
        {
            string loginUser = txtBoxLogin.Text.Trim();
            string passwordUser = passBoxPassword.Password.Trim();
            string password2User = passBoxRepeat.Password.Trim();
            string emailUser = txtBoxEmail.Text.Trim().ToLower();

            if (LoginCheck(loginUser, passwordUser, emailUser) == true && PasswordCheck(passwordUser, password2User) && EmailCheck(emailUser))
            {
                string querystring = $"insert into register(login_user, password_user, email_user, role_user) values ('{loginUser}', '{passwordUser}', '{emailUser}', '2')";
                SqlCommand command = new SqlCommand(querystring, database.getConnection());
                database.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан!", "Создание аккаунта");
                    AuthenticationLog log_in = new AuthenticationLog();
                    log_in.ShowDialog();
                    this.Close();
                }
                database.closeConnection();
            }
            
        }
        private Boolean LoginCheck(string login, string passwordUser, string emailUser)
        {
            bool isCorrect = false;
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select login_user, email_user from register where login_user = '{login}' or email_user = '{emailUser}'";
            SqlCommand command = new SqlCommand(querystring, database.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            while (isCorrect == false)
            {
                if (login.Length < 4)
                {
                    txtBoxLogin.ToolTip = "Длина логина должно составлять минимум 4 символа!";
                    txtBoxLogin.Background = Brushes.PaleVioletRed;
                    break;
                }
                if (table.Rows.Count > 0)
                {
                    txtBoxLogin.ToolTip = "Пользователь уже существует";
                    txtBoxLogin.Background = Brushes.PaleVioletRed;
                    txtBoxEmail.Background = Brushes.PaleVioletRed;

                    break;
                }
                else
                {
                    txtBoxLogin.ToolTip = "";
                    txtBoxLogin.Background = Brushes.Transparent;
                    isCorrect = true;
                }
            }
            return isCorrect;
        }
        private Boolean PasswordCheck(string password, string password2)
        {
            bool isCorrect = false;
            while (isCorrect == false)
            {
                if (password != password2)
                {
                    passBoxRepeat.ToolTip = "Пароли не совпадают!";
                    passBoxPassword.Background = Brushes.PaleVioletRed;   
                    passBoxRepeat.Background = Brushes.PaleVioletRed;
                    break;
                }
                else
                {
                    passBoxRepeat.ToolTip = "";
                    passBoxPassword.Background = Brushes.Transparent;
                    passBoxRepeat.Background = Brushes.Transparent;
                    isCorrect = true;
                }
            }
            return isCorrect;
        }
        private Boolean EmailCheck(string email)
        {
            bool isCorrect = false;
            while (isCorrect == false)
            {
                if (!email.Contains("@") || !email.Contains("."))
                {
                    txtBoxEmail.ToolTip = "Пропущена знак '@' или символ '.'";
                    txtBoxEmail.Background = Brushes.PaleVioletRed;
                    break;
                }
                else
                {
                    txtBoxEmail.ToolTip = "";
                    txtBoxEmail.Background = Brushes.Transparent;
                    MessageBox.Show("Регистрация успешно проведена");
                    isCorrect = true;
                }
            }
            return isCorrect;
        }
        private void Log_in_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationLog log_in = new AuthenticationLog();
            this.Close();
            log_in.ShowDialog();
        }

        private void CloseApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
