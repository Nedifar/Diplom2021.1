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
    /// Логика взаимодействия для Сatalog.xaml
    /// </summary>
    public partial class Сatalog : UserControl
    {
        public Сatalog()
        {
            InitializeComponent();
            if (DifferentsOddities.admin)
            {
                admin.IsChecked = true;
            }
            LCom.ItemsSource = context.AgetDB().Rooms.Where(p => p.Id_Contract == null).ToList();
        }

        private void cl_toDel(object sender, RoutedEventArgs e)
        {
            context.AgetDB().Rooms.Remove((sender as Button).DataContext as Room);
            context.AgetDB().SaveChanges();
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        private void cl_toBuy(object sender, RoutedEventArgs e)
        {
            if (admin.IsChecked == true)
                MessageBox.Show("А вот нет, а вот незя тебе туда нажимать, с уважением.");
            else
                DifferentsOddities.MainWindow.begindogovor((sender as Button).DataContext as Room);
        }
        private void Search(object sender, TextChangedEventArgs e)
        {
            LCom.ItemsSource = context.AgetDB().Rooms.Where(p => p.Id_Contract == null).Where(p => p.Room_Name.Contains(tb_Email.Text)).ToList();
            if (tb_Email.Text == "")
            {
                LCom.ItemsSource = context.AgetDB().Rooms.Where(p => p.Id_Contract == null).ToList();
                tb_Emai.Visibility = Visibility.Collapsed;
            }
                
            else if (context.AgetDB().Rooms.Where(p => p.Id_Contract == null).Where(p => p.Room_Name.Contains(tb_Email.Text)).Count() == 0)
                tb_Emai.Visibility = Visibility.Visible;
            else
                tb_Emai.Visibility = Visibility.Collapsed;

        }
        private void cl_toEdit(object sender, RoutedEventArgs e)
        {
            DifferentsOddities.MainWindow.gridM.Children.Clear();
            DifferentsOddities.MainWindow.gridM.Children.Add(new Forms.AddOrg((sender as Button).DataContext as Room));
        }
    }
}
