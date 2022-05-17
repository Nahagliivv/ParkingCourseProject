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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParkingCourseProject.Views
{
    /// <summary>
    /// Логика взаимодействия для BuyPassPage.xaml
    /// </summary>
    public partial class BuyPassPage : Page
    {
        MainWindow mwnd;
        //итоговая цена
        double Price { get; set; }
        //Цена на 1 день
        double BeginPrice { get; set; } = 2;
        //дни
        int Days { get; set; }
        //скидка
        double discount { get; set; } = 1;
        DateTime endDate;
        public BuyPassPage(MainWindow mwnd)
        {
            InitializeComponent();
            this.mwnd = mwnd;
            TextBoxBeginDate.Text = DateTime.Today.ToString();
        }
        //кнопка приобрести
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if(TextBoxEndDate.Text == "") { ErrorMessage.Content = "Не выбрана дата окончания"; return; }
            endDate = DateTime.Parse(TextBoxEndDate.Text);
            if(endDate< DateTime.Today)
            {
                ErrorMessage.Content = "Дата окончания действия не может быть меньше даты начала ";
                return;
            }
            ErrorMessage.Content = "";
                using (var db = new ParkingDBEntities())
                {
                    PASS newPass = new PASS() { ID_Owner = CurrentUser.UserRef.ID_Owner, End_date = endDate, Special_place = CheckBoxIsSpecial.IsChecked, Start_date = DateTime.Today };
                    var curUser = db.OWNER.FirstOrDefault(x => x.ID_Owner == CurrentUser.UserRef.ID_Owner);
                    if (curUser.Debt < (decimal)Price) { ErrorMessage.Content = "не хватает средств на балансе"; return; }
                    curUser.Debt = curUser.Debt - (decimal)Price;
                    db.PASS.Add(newPass);
                    db.SaveChanges();
                    CurrentUser.UserRef = curUser;
                    MessageBox.Show("Абонемент успешно приобретён");
                    mwnd.Mainframe.Content = new BuyPassPage(mwnd);
                }
            }
            catch
            {
                MessageBox.Show("Введены некорректные данные!"); return;
            }
            }


        private void UpdatePrice()
        {
            try
            {
                Price = 0;
                discount = 1;
                double DateDifInSecond = endDate.Subtract(DateTime.Today).TotalDays;
                Days = (int)(Math.Ceiling(DateDifInSecond));
                for (int i = 1; i <= Days; i++)
                {
                    Price += BeginPrice * discount;
                    if (discount > 0.4f)
                    {
                        discount -= 0.05;
                    }
                }
                if (CheckBoxIsSpecial.IsChecked == true) { Price = Price * 0.8; }
                TextBoxPrice.Text = Price.ToString();
            }
            catch { MessageBox.Show("Ошибка при расчете цены"); return; }
        }

        private void TextBoxEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (TextBoxEndDate.Text == "") return;
                endDate = DateTime.Parse(TextBoxEndDate.Text);
                if (endDate < DateTime.Now)
                {
                    ErrorMessage.Content = "Дата окончания действия не может быть меньше даты начала ";
                    return;
                }
                UpdatePrice();
            }
            catch
            {
                MessageBox.Show("Ошибка при выборе даты"); return;
            }
        }
        private void CheckBoxIsSpecial_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TextBoxEndDate.Text == "") return;
                endDate = DateTime.Parse(TextBoxEndDate.Text);
                if (endDate < DateTime.Now)
                {
                    ErrorMessage.Content = "Дата окончания действия не может быть меньше даты начала ";
                    return;
                }
                UpdatePrice();
            }
            catch
            {
                MessageBox.Show("Ошибка при выборе даты"); return;
            }
        }
    }
}
