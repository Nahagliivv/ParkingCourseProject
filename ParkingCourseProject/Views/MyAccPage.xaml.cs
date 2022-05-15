using Microsoft.Win32;
using ParkingCourseProject.DB;
using ParkingCourseProject.Logic;
using ParkingCourseProject.Models;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MyAccPage.xaml
    /// </summary>
    public partial class MyAccPage : Page
    {
        MainWindow mainWindow;
        byte[] editImg;
        byte[] saveImg;
        public MyAccPage( MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            InitImg();
            TextBoxName.Text = CurrentUser.UserRef.Full_name;
            TextBoxAddres.Text = CurrentUser.UserRef.Adress;
            TextBoxPhoneNumber.Text = CurrentUser.UserRef.Tel_number;
        }
        //Нажате на картинку
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
                YourImage.ImageSource = new BitmapImage(new Uri(openwnd.FileName));
            }
            catch
            {
                editImg = saveImg;
                return;
            }
        }
        void InitImg()
        {
            YourImage.ImageSource = SaveAndLoadPicture.LoadImage(CurrentUser.UserRef.IMG);
            saveImg = CurrentUser.UserRef.IMG;
        }
        //нажатие на кнопку сохраненния
        private void Button_MouseDown(object sender, RoutedEventArgs e)
        {
            bool isPasswordChange = false;
            if(TextBoxRepeatNewPassword.Password!=""|| TextBoxNewPassword.Password != "" || TextBoxOldPassword.Password != "") { isPasswordChange = true; }
            using (var db = new ParkingDBEntities())
            {
                var user = db.OWNER.FirstOrDefault(q => q.Tel_number == CurrentUser.UserRef.Tel_number);
                if (HashPssword.VerifyHashedPassword(user.Password, TextBoxOldPassword.Password) || !isPasswordChange)
                {
                    var passExp = new Regex(@"^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");
                    if (!passExp.IsMatch(TextBoxNewPassword.Password) && isPasswordChange) { ErrorMessage.Content = "В пароле должны быть: цифра, буквы нижнего и верхнего \nрегистра, длина от 8 до 16 символов"; return; }
                    if(TextBoxNewPassword.Password!= TextBoxRepeatNewPassword.Password && !isPasswordChange) { ErrorMessage.Content = "Пароли не совпадают"; return; }
                    user.Adress = TextBoxAddres.Text;
                    if (isPasswordChange)
                    {
                        user.Password = HashPssword.Hash(TextBoxNewPassword.Password);
                    }
                    user.Full_name = TextBoxName.Text;
                    user.IMG = editImg;
                    user.Tel_number = TextBoxPhoneNumber.Text;
                    db.SaveChanges();
                    CurrentUser.UserRef = user;
                    MessageBox.Show("Данные успешно изменены");
                }
                else
                {
                    ErrorMessage.Content = "Неверный старый пароль";
                    return;
                }
            }
        }
    }
}
