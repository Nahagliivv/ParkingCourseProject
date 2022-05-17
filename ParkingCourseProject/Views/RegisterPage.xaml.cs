using Microsoft.Win32;
using ParkingCourseProject.DB;
using ParkingCourseProject.Logic;
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
    /// Логика взаимодействия для RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        EnterWindow mainwindow;
        //Регулярки
        Regex expName;
        Regex expPhoneNumber;
        Regex expPassword;
        StreamResourceInfo img;
        byte[] imgData;
        string defaultImg = "pack://application:,,,/Styles/Images/YourPhotoDefault.png";
        public RegisterPage(EnterWindow mainwindow)
        {
            InitializeComponent();
            YourImage.ImageSource = new BitmapImage(new Uri(defaultImg));
            this.mainwindow = mainwindow;
            expName = new Regex(@"([А-ЯЁ][а-яё]+[\-\s]?){3,}");
            expPhoneNumber = new Regex(@"^(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$");
            expPassword = new Regex(@"^(?=.{8,16}$)(?=.*?[a-z])(?=.*?[A-Z])(?=.*?[0-9]).*$");
            img = System.Windows.Application.GetResourceStream(new Uri(defaultImg));
            imgData = SaveAndLoadPicture.ReadFully(img.Stream);
        }
        //На главную
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.Mainframe.Content = new EnterPage(mainwindow);
        }
        //попытка регистрации
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!expName.IsMatch(TextBoxName.Text)) { TextBoxErrorMessage.Content = "Неверный формат ФИО"; return; }
                if (TextBoxAddr.Text.Length < 1) { TextBoxErrorMessage.Content = "Поле адреса не может быть пустым"; return; }
                if (!expPhoneNumber.IsMatch(TextBoxPhoneNumber.Text)) { TextBoxErrorMessage.Content = "Неверный формат номера телефона"; return; }
                using (var db = new ParkingDBEntities())
                {
                    foreach (var x in db.OWNER)
                    {
                        if (x.Tel_number == TextBoxPhoneNumber.Text)
                        {
                            TextBoxErrorMessage.Content = "Пользователь с таким номером телефона уже зарегистрирован"; return;
                        }
                    }
                }
                if (!expPassword.IsMatch(TextBoxPassword.Password)) { TextBoxErrorMessage.Content = "В пароле должны быть: цифра, буквы нижнего и верхнего \nрегистра, длина от 8 до 16 символов "; return; }
                if (TextBoxPassword.Password != TextBoxRepeatPassword.Password) { TextBoxErrorMessage.Content = "Пароли не совпадают"; return; }
                using (var db = new ParkingDBEntities())
                {
                    db.OWNER.Add(new OWNER() { Tel_number = TextBoxPhoneNumber.Text, Adress = TextBoxAddr.Text, Full_name = TextBoxName.Text, Password = HashPssword.Hash(TextBoxPassword.Password), Debt = 0, IMG = imgData });
                    db.SaveChanges();
                }
                mainwindow.Mainframe.Content = new EnterPage(mainwindow);
                MessageBox.Show("Регистрация успешно завершена");
            }
            catch
            {
                MessageBox.Show("Ошибка попытки регистрации"); return;
            }
        }

        private void EllipsePicture_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                OpenFileDialog openwnd = new OpenFileDialog
                {
                    Filter = "Image files(*.png)|*.png|Image files(*.jpg)|*.jpg"
                };
                openwnd.ShowDialog();
                imgData = SaveAndLoadPicture.PictureToByte(openwnd.FileName);
                YourImage.ImageSource = new BitmapImage(new Uri(openwnd.FileName));
            }
            catch
            {
                img = System.Windows.Application.GetResourceStream(new Uri(defaultImg));
                imgData = SaveAndLoadPicture.ReadFully(img.Stream);
                return;
            }
        }
    }
}
