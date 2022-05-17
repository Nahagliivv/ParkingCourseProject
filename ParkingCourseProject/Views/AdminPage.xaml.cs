using ParkingCourseProject.DB;
using ParkingCourseProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class AdminPage : Page
    {
        public ObservableCollection<OWNER> UsersList { get; set; }
        public ObservableCollection<PLACE> PlacesList { get; set; }
        public OWNER SelectedOwner { get; set; }
        public PLACE SelectedPlace { get;set; }
        EnterWindow mwnd;
        public AdminPage(EnterWindow mwnd)
        {
            InitializeComponent();
            this.mwnd = mwnd;
            UsersList = new ObservableCollection<OWNER>();
            PlacesList = new ObservableCollection<PLACE>();
            InitUserList();
            InitPlaces();
            DataContext = this;
        }
        //нажатие на кнопку выход
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CurrentUser.UserRef = null;
            mwnd.Mainframe.Content = new EnterPage(mwnd);
        }
        void InitUserList()
        {
            try
            {
                using (var db = new ParkingDBEntities())
                {
                    foreach (var x in db.OWNER)
                    {
                        if (x.ID_Owner == CurrentUser.UserRef.ID_Owner)
                        {
                            continue;
                        }
                        UsersList.Add(x);
                    }

                }
            }
            catch { MessageBox.Show("Проблемы с доступом к БД"); }
        }
        void InitPlaces()
        {
            try
            {
                using (var db = new ParkingDBEntities())
                {
                    foreach (var x in db.PLACE)
                    {
                        if (x.Occupation == true)
                        {
                            PlacesList.Add(x);
                        }
                    }

                }
            }
            catch { MessageBox.Show("Проблемы с доступом к БД"); }
        }
        //Перевод пользователя в строку для поиска
        string PLACEToString(PLACE place)
        {
            return place.ID_Place + " " + place.Occupation + " " + place.ID_Owner + " " + place.ID_PASS;
        }
        string OWNERToString(OWNER owner)
        {
            return owner.ID_Owner + " " + owner.Full_name + " " + owner.Adress + " " + owner.Tel_number + " " + owner.Debt;
        }

        //Поиск пользователя
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex reg = new Regex(TextBoxSearch.Text.ToString());
                UsersList.Clear();
                using (var db = new ParkingDBEntities())
                {
                    foreach (var x in db.OWNER)
                    {
                        if (reg.IsMatch(OWNERToString(x)))
                        {
                            if (x.ID_Owner == CurrentUser.UserRef.ID_Owner)
                            {
                                continue;
                            }
                            UsersList.Add(x);
                        }

                    }

                }
            }
            catch { MessageBox.Show("Неверная последовательность в поисковой строке"); }
        }
        //Добавление бабок
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (SelectedOwner == null) { MessageBox.Show("Пользователь не выбран"); return; }
            try
            {
                using(var db = new ParkingDBEntities())
                {
                    var selectedUser = db.OWNER.FirstOrDefault(x=>x.ID_Owner==SelectedOwner.ID_Owner);
                    selectedUser.Debt += (decimal)Convert.ToDouble(TextBoxAddMoney.Text);
                    db.SaveChanges();
                    mwnd.Mainframe.Content = new AdminPage(mwnd);
                }
            }
            catch { MessageBox.Show("Неверный формат суммы"); return; }
        }
        //снятие бабок
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (SelectedOwner == null) { MessageBox.Show("Пользователь не выбран"); return; }
            try
            {
                using (var db = new ParkingDBEntities())
                {
                    var selectedUser = db.OWNER.FirstOrDefault(x => x.ID_Owner == SelectedOwner.ID_Owner);
                    if ((decimal)Convert.ToDouble(TextBoxAddMoney.Text) <= selectedUser.Debt)
                    {
                        selectedUser.Debt -= (decimal)Convert.ToDouble(TextBoxAddMoney.Text);
                        db.SaveChanges();
                        mwnd.Mainframe.Content = new AdminPage(mwnd);
                    }
                    else { MessageBox.Show("Баланс не может быть отрицательным"); return; }
                }
            }
            catch { MessageBox.Show("Неверный формат суммы"); return; }
        }
        //Поиск места
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            try
            {
                Regex reg = new Regex(TextBoxSearchPlace.Text.ToString());
                PlacesList.Clear();
                using (var db = new ParkingDBEntities())
                {
                    foreach (var x in db.PLACE)
                    {
                        if (reg.IsMatch(PLACEToString(x)))
                        {
                            if (x.Occupation ==false)
                            {
                                continue;
                            }
                            PlacesList.Add(x);
                        }

                    }

                }
            }
            catch { MessageBox.Show("Неверная последовательность в поисковой строке"); }
        }
        //Освобождение места
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            try
            {
                if(SelectedPlace == null) { MessageBox.Show("Место для освобождения не выбрано"); return; }
                using (var db = new ParkingDBEntities())
                {
                    var place = db.PLACE.FirstOrDefault(x=>x.ID_Place == SelectedPlace.ID_Place);
                    place.Occupation = false;
                    place.ID_PASS = null;
                    place.ID_Owner = null;
                    place.ID_Vehicle = null;
                    db.SaveChanges();
                    mwnd.Mainframe.Content = new AdminPage(mwnd);
                    MessageBox.Show("Место успешно освобождено");
                }

            }
            catch 
            {
                MessageBox.Show("Непредвиденная ошибка"); return;
            }
        }
    }
}
