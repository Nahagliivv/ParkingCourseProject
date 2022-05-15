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
    /// Логика взаимодействия для EnterPage.xaml
    /// </summary>
    public partial class EnterPage : Page
    {   //Ссылка на окно, которое содержит в себе страницу, для перехода между страницами
        EnterWindow mainwindow;
        public EnterPage(EnterWindow mainwindow)
        {
            InitializeComponent();
            this.mainwindow = mainwindow;
        }
        //Кнопка регистрации
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.Mainframe.Content = new RegisterPage(mainwindow);
        }
        //Кнопка входа
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mainwindow.Mainframe.Content = new LoginPage(mainwindow);
        }
    }
}
