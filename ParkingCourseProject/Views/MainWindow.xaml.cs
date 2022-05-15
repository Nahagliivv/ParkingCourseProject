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
using System.Windows.Shapes;

namespace ParkingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mainframe.Content = new MyAccPage(this);
        }
        //свернуть приложение
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        //Закрыть приложение
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
        //кнопка выхода
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CurrentUser.UserRef = null;
            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new EnterWindow();
            App.Current.MainWindow.Show();
        }
        //Кнопка аккаунта
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Mainframe.Content = new MyAccPage(this);
        }
        //кнопка автомобилей
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Mainframe.Content = new MyCarsPage(this);
        }
    }
}
