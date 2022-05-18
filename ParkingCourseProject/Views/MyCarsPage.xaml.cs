using Microsoft.Win32;
using ParkingCourseProject.DB;
using ParkingCourseProject.Logic;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace ParkingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для MyCarsPage.xaml
    /// </summary>
    public partial class MyCarsPage : Page
    {
        byte[] editImg;
        byte[] saveImg;
        string defaultCarImg = "pack://application:,,,/Styles/Images/YourCarDefault.png";
        Regex carNumber;
        StreamResourceInfo img;
        MainWindow mwnd;
        public ObservableCollection<CarViewLogic> CarsViews { get; set; }
        public CarViewLogic SelectedCar { get; set; }
        public MyCarsPage(MainWindow mwnd)
        {
            InitializeComponent();
            carNumber = new Regex(@"^\d{4}[A-Z]{2}-(\d){1}$");
            CarsViews = new ObservableCollection<CarViewLogic>();
            InitImg();
            InitCars();
            DataContext = this;
            this.mwnd = mwnd;
        }
        //загрузка картинки в кругалёк
        void InitImg()
        {
            try
            {
                CarImage.ImageSource = new BitmapImage(new Uri(defaultCarImg));
                img = System.Windows.Application.GetResourceStream(new Uri(defaultCarImg));
                editImg = SaveAndLoadPicture.ReadFully(img.Stream);
                saveImg = SaveAndLoadPicture.ReadFully(img.Stream);
            }
            catch
            {
                MessageBox.Show("Ошибка инициализации изображения"); return;
            }
        }
        //добавление тачки
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool isSpecial;
                if (!carNumber.IsMatch(TextBoxNumber.Text)) { ErrorMessage.Content = "Неверный формат номера авто(1111АА-1)"; return; }
                using (var db = new ParkingDBEntities())
                {
                    int countOfCurrVeh = db.VEHICLE.Count(x => x.Vehicle_number == TextBoxNumber.Text);
                    if (countOfCurrVeh != 0) { ErrorMessage.Content = "Транспорт с таким номером уже зарегистрирован"; return; }
                }
                if (IsSpecial.IsChecked==true) { isSpecial = true; } else { isSpecial = false; }
                if (TextBoxColor.Text == "" || TextBoxBrand.Text == "") { ErrorMessage.Content = "Пустые поля не должны быть"; return; }
                using (var db = new ParkingDBEntities())
                {
                    var newCar = new DB.VEHICLE();
                    newCar.ID_Owner = CurrentUser.UserRef.ID_Owner;
                    newCar.Color = TextBoxColor.Text;
                    newCar.Vehicle_number = TextBoxNumber.Text;
                    newCar.Special_vehicle = isSpecial;
                    newCar.Vehicle_name = TextBoxBrand.Text;
                    newCar.IMG = editImg;
                    db.VEHICLE.Add(newCar);
                    CarsViews.Add(new CarViewLogic(newCar));
                    db.SaveChanges();
                    MessageBox.Show("Автомобиль успешно зарегистрирован");
                    mwnd.Mainframe.Content = new MyCarsPage(mwnd);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка добавления авто"); return;
            }
        }
        //Выбор картинки при нажатии на картинку0_о
        private void EllipsePicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {   //открытие диалоговог окна
                OpenFileDialog openwnd = new OpenFileDialog
                {
                    Filter = "Image files(*.png)|*.png|Image files(*.jpg)|*.jpg"
                };
                openwnd.ShowDialog();
                editImg = SaveAndLoadPicture.PictureToByte(openwnd.FileName);
                CarImage.ImageSource = new BitmapImage(new Uri(openwnd.FileName));
            }
            catch
            {
                editImg = saveImg;
                return;
            }
        }
        //Загрузка списка с авто
        void InitCars()
        {
            using (var db = new ParkingDBEntities())
            {
                foreach(var x in db.VEHICLE.Where(x => x.ID_Owner == CurrentUser.UserRef.ID_Owner))
                {
                    CarsViews.Add(new CarViewLogic(x));
                }
            }
        }
        //Удаление тачки
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (SelectedCar == null) { return; }
            using (var db = new ParkingDBEntities())
            {
                try
                {
                    var linq = db.VEHICLE.FirstOrDefault(x => x.ID_Vehicle == SelectedCar.ID_Vehicle);
                    if (linq == null) { return; }
                    db.VEHICLE.Remove(linq);
                    db.SaveChanges();
                    CarsViews.Remove(SelectedCar);
                    MessageBox.Show("Транспорт удалён");
                }
                catch { MessageBox.Show("Нельзя удалить авто из списка пока оно привязано к стоянке"); return; }
            }
        }
    }
}
