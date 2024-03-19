using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CreateAuth
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        DBContainer db = new DBContainer();
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "" || lastName.Text == "" || firstName.Text == "" || middleName.Text == "")
            {
                MessageBox.Show("Пустые поля");
                return;
            }
            if (db.Users.Select(item => item.Login).Contains(login.Text))
            {
                MessageBox.Show("Такой логин существует в системе");
                return;
            }
            User newUser = new User()
            {
                Login = login.Text,
                Password = password.Password,
                LastName = lastName.Text,
                FirstName = firstName.Text,
                MiddleName = middleName.Text
            };
            db.Users.Add(newUser);
            db.SaveChanges();
            MessageBox.Show("Вы успешно зарегестрировались");
            MainWindow aw = new MainWindow();
            aw.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow aw = new MainWindow();
            aw.Show();
            this.Close();
        }
    }
}
