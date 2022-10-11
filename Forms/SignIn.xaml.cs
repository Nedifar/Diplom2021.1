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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.Forms
{
    /// <summary>
    /// Логика взаимодействия для SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void toSign(object sender, RoutedEventArgs e)
        {
            Models.context.AgetDB().Organizations.Include(p => p.Contracts);
            var user = Models.context.AgetDB().Users.Include(p=>p.Organizations).Where(p => p.Login == login.Text && p.Password == password.Password).FirstOrDefault();
            if(user!= null)
            {
                if(user.Id_Role == 1)
                {
                    DifferentsOddities.MainWindow = new MainWindow(null);
                    DifferentsOddities.MainWindow.Show();
                    DifferentsOddities.admin = true;
                }
                else
                {
                    DifferentsOddities.MainWindow = new MainWindow(user);
                    DifferentsOddities.MainWindow.Show();
                    DifferentsOddities.org = Models.context.AgetDB().Organizations.Include(p => p.Contracts).Where(p => p.Id_User == user.Id_User).FirstOrDefault();
                }
                Close();
            }
        }

        private void Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cl_reg(object sender, RoutedEventArgs e)
        {
            Forms.Registr registr = new Registr();
            registr.Show();
            Close();
        }
    }
}
