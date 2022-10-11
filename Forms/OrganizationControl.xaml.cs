using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для OrganizationControl.xaml
    /// </summary>
    public partial class OrganizationControl : UserControl
    {
        public OrganizationControl()
        {
            InitializeComponent();
            LCom.ItemsSource = context.AgetDB().Organizations.Include(p=>p.Contracts).ToList();
        }

        private void cl_More(object sender, RoutedEventArgs e)
        {
            DifferentsOddities.MainWindow.More((sender as Button).DataContext as Models.Organization);
        }
    }
}
