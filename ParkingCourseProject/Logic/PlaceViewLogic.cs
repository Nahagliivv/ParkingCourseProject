using ParkingCourseProject.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace ParkingCourseProject.Logic
{
    public class PlaceViewLogic
    {
        public int ID_Place { get; set; }
        public bool? Special_place { get; set; }
        public bool? Occupation { get; set; }
        public int? ID_Vehicle { get; set; }
        public int? ID_Owner { get; set; }
        public BitmapImage IMG { get; set; }
        public PlaceViewLogic(PLACE place)
        {
            ID_Place = place.ID_Place;
            Special_place = place.Special_place;
            Occupation = place.Occupation;
            ID_Vehicle = place.ID_Vehicle;
            ID_Owner = place.ID_Owner;
            if (Special_place == true) IMG = new BitmapImage(new Uri("pack://application:,,,/Styles/Images/Special.png")); 
            if (Occupation == true) { IMG = new BitmapImage(new Uri("pack://application:,,,/Styles/Images/STOP.png")); }
        }
        public PlaceViewLogic()
        {

        }
    }
}
