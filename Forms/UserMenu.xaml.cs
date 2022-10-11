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

namespace Project.Forms
{
    /// <summary>
    /// Логика взаимодействия для UserMenu.xaml
    /// </summary>
    public partial class UserMenu : UserControl
    {
        public UserMenu()
        {
            InitializeComponent();
            List<Models.Contract> ints = DifferentsOddities.org.Contracts.ToList();
            List<Models.Room> list = new List<Models.Room>();
            for (int i = 0; i < ints.Count; i++)
            {
                int b = ints[i].Id_Contract;
                list.Add(Models.context.AgetDB().Rooms.Where(p => p.Id_Contract == b).FirstOrDefault());
            }
            LCom.ItemsSource = list;
        }
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
        private void cl_toBuy(object sender, RoutedEventArgs e)
        {
            Models.Room property = (sender as Button).DataContext as Models.Room;
            object path = $@"{AppDomain.CurrentDomain.BaseDirectory}Contracts\contract №{property.Id_Contract}.doc";
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            app.Visible = true;
            app.Documents.Open(path);
        }
        private void cl_toProdlit(object sender, RoutedEventArgs e)
        {
            SrokDogovora srokDogovora = new SrokDogovora((sender as Button).DataContext as Models.Room);
            srokDogovora.Show();
        }
        private void cl_toRastor(object sender, RoutedEventArgs e)
        {
            Models.Room property = (sender as Button).DataContext as Models.Room;
            Models.Contract contract = Models.context.AgetDB().Contracts.Where(p => p.Id_Contract == property.Id_Contract).FirstOrDefault();
            property.Id_Contract = null;
            Models.context.AgetDB().Contracts.Remove(contract);
            Models.context.AgetDB().SaveChanges();
            MessageBox.Show("Операция выполнена");
            DifferentsOddities.MainWindow.gridM.Children.Clear();
            DifferentsOddities.MainWindow.gridM.Children.Add(new UserMenu());
        }
    }
}
