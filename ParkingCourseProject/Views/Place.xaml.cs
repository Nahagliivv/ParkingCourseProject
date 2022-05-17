using ParkingCourseProject.DB;
using ParkingCourseProject.Logic;
using ParkingCourseProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Place.xaml
    /// </summary>
    public partial class Place : Page
    {
        public ObservableCollection<PlaceViewLogic> PlaceViews { get; set; }
        MainWindow mwnd;
        public PlaceViewLogic selectedPlace { get; set; }
        public Place(MainWindow mwnd)
        {
            InitializeComponent();
            PlaceViews = new ObservableCollection<PlaceViewLogic>();
            DataContext = this;
            initPlaceViews();
            this.mwnd = mwnd;
        }
        void initPlaceViews()
        {
            try
            {
                using (var db = new ParkingDBEntities())
                {
                    if (db.PLACE.Count() == 0)
                    {
                        for (int i = 1; i <= 21; i++)
                        {
                            PLACE newPlace = new PLACE();
                            newPlace.Occupation = false;
                            newPlace.ID_Place = i;
                            if (i % 7 == 0 || i % 7 == 1) { newPlace.Special_place = true; } else { newPlace.Special_place = false; }
                            db.PLACE.Add(newPlace);
                            db.SaveChanges();
                            PlaceViews.Add(new PlaceViewLogic(newPlace));
                        }
                    }
                    else
                    {
                        foreach (var x in db.PLACE)
                        {
                            PlaceViews.Add(new PlaceViewLogic(x));
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка инициализации графического представления парковочных мест"); return;
            }
        }
        //Забронировать
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new ParkingDBEntities())
                {
                    if (selectedPlace == null) { ErrorMessage.Content = "Место не выбрано"; return; }
                    var vehicleCount = db.VEHICLE.Count(x => x.Vehicle_number == TextBoxTransportNumber.Text && x.ID_Owner == CurrentUser.UserRef.ID_Owner);
                    if (vehicleCount == 0) { ErrorMessage.Content = "У вас нет транспорта с таким номером"; return; }
                    var vehicle = db.VEHICLE.FirstOrDefault(x => x.Vehicle_number == TextBoxTransportNumber.Text && x.ID_Owner == CurrentUser.UserRef.ID_Owner);
                    var passCount = db.PASS.Count(x => x.ID_Owner == CurrentUser.UserRef.ID_Owner && vehicle.Special_vehicle == x.Special_place);
                    var pass = db.PASS.Where(x => x.ID_Owner == CurrentUser.UserRef.ID_Owner && vehicle.Special_vehicle == x.Special_place);
                    if (passCount == 0) { ErrorMessage.Content = "У вас нет абонемента для такого типа авто"; return; }
                    PASS truePASS = null;
                    foreach (var x in pass)
                    {
                        if (db.PLACE.Count(z => z.ID_PASS == x.ID_PASS) == 0)
                        {
                            truePASS = x;
                        }
                    }
                    if (truePASS == null) { ErrorMessage.Content = "У вас нет подходящего абонемента"; return; }
                    if (selectedPlace.Occupation == true) { ErrorMessage.Content = "Место уже занято"; return; }
                    if (selectedPlace.Special_place != vehicle.Special_vehicle) { ErrorMessage.Content = "Автомобиль не подходит по типу для места"; return; }
                    if (selectedPlace.Special_place != truePASS.Special_place) { ErrorMessage.Content = "Абонемент не подходит по типу для места"; return; }

                    var editPlace = db.PLACE.FirstOrDefault(x => x.ID_Place == selectedPlace.ID_Place);
                    editPlace.ID_PASS = truePASS.ID_PASS;
                    editPlace.ID_Vehicle = vehicle.ID_Vehicle;
                    editPlace.ID_Owner = CurrentUser.UserRef.ID_Owner;
                    editPlace.Occupation = true;
                    db.SaveChanges();
                    MessageBox.Show("Место успешно забронированно");
                    mwnd.Mainframe.Content = new Place(mwnd);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка бронирования места"); return;
            }
        }
    }
}
