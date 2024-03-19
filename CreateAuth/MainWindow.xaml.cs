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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CreateAuth
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBContainer db;
        public MainWindow()
        {
            InitializeComponent();
            db= new DBContainer();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (login.Text == "" || password.Password == "")
            {
                MessageBox.Show("Ошибка! Пустые поля!");
                return;
            }
            if(db.Users.Select(item => item.Login + " " + item.Password).Contains(login.Text + " " + password.Password))
            {
                MessageBox.Show("Вы авторизированы");
            }
            else
            {
                MessageBox.Show("Ошибка авторизации");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Registration rw = new Registration();
            rw.Show();
            this.Close();
        }
    }
}
