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
using System.Windows.Shapes;

namespace Project.Forms
{
    /// <summary>
    /// Логика взаимодействия для SrokDogovora.xaml
    /// </summary>
    public partial class SrokDogovora : Window
    {
        Models.Room room = new Models.Room();
        public SrokDogovora(Models.Room roomi)
        {
            InitializeComponent();
            room = roomi;
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            tb_srok.ItemsSource = list;
        }

        private void cl_toSave(object sender, RoutedEventArgs e)
        {
            DifferentsOddities.prodlit(int.Parse(tb_srok.Text), room);
            DifferentsOddities.MainWindow.gridM.Children.Clear();
            DifferentsOddities.MainWindow.gridM.Children.Add(new UserMenu());
            Close();
        }

        private void tb_srok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tb_srok.SelectedIndex != -1)
                bt_srok.IsEnabled = true;
            else
                bt_srok.IsEnabled = false;
        }
    }
}
