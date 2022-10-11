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
using Project.Models;

namespace Project.Forms
{
    /// <summary>
    /// Логика взаимодействия для AddContract.xaml
    /// </summary>
    public partial class AddContract : UserControl
    {
        Room room;
        public AddContract(Room roomi)
        {
            InitializeComponent();
            room = roomi;
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            tb_srok.ItemsSource = list;
        }
        private void cl_Back(object sender, RoutedEventArgs e)
        {
            DifferentsOddities.MainWindow.Back(new Сatalog());
        }
         private void cl_toSave(object sender, RoutedEventArgs e)
        {
            if(NameS.Text.Trim() == "" || tb_srok.Text.Trim() =="" || tb_bik.Text.Trim()== "" || tb_kpp.Text.Trim() =="" || tb_ks.Text.Trim()=="" || tb_rs.Text.Trim()=="")
            {
                MessageBox.Show("Проверьте заполненность всех строк, с уважением.", "Error");
                return;
            }
            string nameRP = NameS.Text;
            int srok = int.Parse(tb_srok.Text);
            DateTime selectedDate = (DateTime)date.SelectedDate;
            string fullinfo = $"{DifferentsOddities.org.fullName}. ИНН {DifferentsOddities.org.INN}, КПП {tb_kpp.Text}, р/с {tb_rs.Text}, к/с {tb_ks.Text}, БИК {tb_bik.Text}";
            DifferentsOddities.Contract(room, fullinfo, nameRP, srok, selectedDate);
        }

        private void tb_srok_DropDownOpened(object sender, EventArgs e)
        {
            tb_srok.Foreground = Brushes.Black;
        }

        private void tb_srok_DropDownClosed(object sender, EventArgs e)
        {
            tb_srok.Foreground = Brushes.White;

        }

        private void date_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            tb_srok.Foreground = Brushes.Black;

        }

        private void date_ToolTipClosing(object sender, ToolTipEventArgs e)
        {
            tb_srok.Foreground = Brushes.White;

        }

        private void date_CalendarClosed(object sender, RoutedEventArgs e)
        {
            date.Foreground = Brushes.White;
        }

        private void date_CalendarOpened(object sender, RoutedEventArgs e)
        {
            date.Foreground = Brushes.Black;
        }
    }
}
