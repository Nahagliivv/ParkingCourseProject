using ParkingCourseProject.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCourseProject.Models
{
 //контейнер для взаимодействия с текущим пользователем
    internal static class CurrentUser
    {
        public static OWNER UserRef { get; set; }
    }
}
