using ParkingCourseProject.DB;
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
            DeleteLatePass();
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
        //купить абонемент
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Mainframe.Content = new BuyPassPage(this);
        }
        //Удаление просроченных абонементов
        void DeleteLatePass()
        {
            using (var db = new ParkingDBEntities())
            {
                try
                {
                    bool isAlDelete = false;
                    bool isDelete1 = true; ;
                    while (!isAlDelete)
                    {
                        foreach (var x in db.PASS)
                        {
                            if (x.End_date < DateTime.Today)
                            {
                                foreach (var y in db.PLACE.Where(z => z.ID_PASS == x.ID_PASS))
                                {
                                    y.ID_PASS = null;
                                    y.ID_Owner = null;
                                    y.ID_Vehicle = null;

                                }
                                db.PASS.Remove(x); isDelete1 = false; break;
                            }
                            db.SaveChanges();
                        }
                        if (isDelete1) { isAlDelete = true; }
                    }
                }
                catch { MessageBox.Show("Невозможно удалить просроченный абонементы из бд"); }
            }
        }
        //переход на страницу для выбора места
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Mainframe.Content = new Place(this);
        }
    }
}
