using ParkingCourseProject.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ParkingCourseProject.Logic
{
    public class CarViewLogic
    {
        public int ID_Vehicle { get; set; }
        public string Vehicle_name { get; set; }
        public string Vehicle_number { get; set; }
        public string Color { get; set; }
        public Nullable<bool> Special_vehicle { get; set; }
        public Nullable<int> ID_Owner { get; set; }
        public string isSpecialVehicle { get; set; }
        public BitmapImage img { get; set; }
        public CarViewLogic(VEHICLE vehicle)
        {
            img = SaveAndLoadPicture.LoadImage(vehicle.IMG);
            if (vehicle.Special_vehicle == true) { isSpecialVehicle = "да"; }
            if (vehicle.Special_vehicle == false) { isSpecialVehicle = "нет"; }
            this.ID_Vehicle = vehicle.ID_Vehicle;
            this.Vehicle_name = vehicle.Vehicle_name;
            this.Vehicle_number = vehicle.Vehicle_number;
            this.Color = vehicle.Color;
            this.Special_vehicle = vehicle.Special_vehicle;
            this.ID_Owner = vehicle.ID_Owner;
        }
    }
}
