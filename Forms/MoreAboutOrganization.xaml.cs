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
    /// Логика взаимодействия для MoreAboutOrganization.xaml
    /// </summary>
    public partial class MoreAboutOrganization : UserControl
    {
        public MoreAboutOrganization(Models.Organization org)
        {
            InitializeComponent();
            DataContext = org;
            LCom.ItemsSource = org.Contracts.ToList();
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            DifferentsOddities.MainWindow.Back(new OrganizationControl());
        }

        private void formContr(object sender, RoutedEventArgs e)
        {
            Models.Contract contract = (sender as Button).DataContext as Models.Contract;

            object path = $@"{System.AppDomain.CurrentDomain.BaseDirectory}Contracts\contract №{contract.Id_Contract}.doc";
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
            app.Visible = true;
            app.Documents.Open(path);
        }
    }
}
