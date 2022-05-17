using ParkingCourseProject.DB;
using ParkingCourseProject.Logic;
using ParkingCourseProject.Models;
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

namespace ParkingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    
    public partial class LoginPage : Page
    {
        EnterWindow mainwindow;
        public LoginPage(EnterWindow mainwindow)
        {
            InitializeComponent();
            this.mainwindow = mainwindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.Mainframe.Content = new EnterPage(mainwindow);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try {
                using (var db = new ParkingDBEntities())
                {
                    int linq = db.OWNER.Count(q => q.Tel_number == TextBoxPhoneNumber.Text);
                    if (linq == 0)
                    {
                        ErrorMessage.Content = "Зарегистрированного пользователя с таким номером телефона нет";
                        return;
                    }
                    var user = db.OWNER.FirstOrDefault(q => q.Tel_number == TextBoxPhoneNumber.Text);
                    if (HashPssword.VerifyHashedPassword(user.Password, TextBoxPassword.Password))
                    {

                        CurrentUser.UserRef = user;
                        if (CurrentUser.UserRef.IsAdmin == true)
                        {
                            mainwindow.Mainframe.Content = new AdminPage(mainwindow);
                        }
                        else
                        {
                            App.Current.MainWindow.Hide();
                            App.Current.MainWindow = new MainWindow();
                            App.Current.MainWindow.Show();
                        }
                    }
                    else
                    {
                        ErrorMessage.Content = "Неверный пароль";
                        return;
                    }
                }
                
            }
            catch
            {
                MessageBox.Show("Ошибка входа"); return;
            }
        }
    }
}
