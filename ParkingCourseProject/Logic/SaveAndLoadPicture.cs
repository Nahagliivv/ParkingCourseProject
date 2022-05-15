using ParkingCourseProject.DB;
using ParkingCourseProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace ParkingCourseProject.Logic
{
    internal class SaveAndLoadPicture
    {
        public static byte[] PictureToByte(string filename) //преобразование картинки в байт по пути
        {
            try
            {
                byte[] pic;
                using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
                {
                    pic = new byte[fs.Length];
                    fs.Read(pic, 0, pic.Length);
                }
                return pic;
            }
            catch { return null; }
        }
        public static BitmapImage LoadImage(byte[] imageData)// преобразование байтов в картинку
        {
            try
            {
                if (imageData == null || imageData.Length == 0) return null;
                var image = new BitmapImage();
                using (var mem = new MemoryStream(imageData))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }
            catch
            {
                using (var db = new ParkingDBEntities())
                {
                    string imagePath = "pack://application:,,,/Styles/Images/YourPhotoDefault.png";//картинка по умолчанию
                    StreamResourceInfo imageInfo = System.Windows.Application.GetResourceStream(new Uri(imagePath));
                    var curUImg = db.OWNER.Where(x => x.ID_Owner == CurrentUser.UserRef.ID_Owner).First();
                    curUImg.IMG = SaveAndLoadPicture.ReadFully(imageInfo.Stream);
                    db.SaveChanges();
                    return SaveAndLoadPicture.LoadImage(curUImg.IMG);
                }
            }

        }
        public static byte[] ReadFully(Stream input)///преобразование потока в картинку, метод нужен для чтения изображения по умолчанию из проекта, а не из внешнего файла
        {
            byte[] buffer = new byte[16 * 128];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
