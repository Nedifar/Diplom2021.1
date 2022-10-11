using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        public Registr()
        {
            InitializeComponent();
            
        }

        private void toSign(object sender, RoutedEventArgs e)
        {
            Models.User user = new Models.User() { Id_Role = 2, Login = login.Text, Password = password.Password };
            string errors = "";
            var result = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(user);
            if(!Validator.TryValidateObject(user, context, result, true))
            {
                foreach (var error in result)
                {
                    errors += error.ErrorMessage + "\n";
                }
            }
            if (errors != "")
            {
                MessageBox.Show( errors, "Error");
                return;
            }
            Models.context.AgetDB().Users.Add(user);
            Models.context.AgetDB().SaveChanges();
            Models.Organization org = new Models.Organization()
            {
                Leader_Last_Name = leadLast.Text,
                Leader_First_Name = leadFi.Text,
                Leader_Middle_Name = leadmed.Text,
                Id_User = Models.context.AgetDB().Users.Where(p=>p.Login == login.Text && p.Password == password.Password).FirstOrDefault().Id_User,
                INN = inn.Text,
                OGRN = ogrn.Text,
                Org_Name = nameorg.Text,
                Org_Telephone = telephone.Text
            };
            var result1 = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context1 = new ValidationContext(org);
            if (!Validator.TryValidateObject(org, context1, result1, true))
            {
                foreach (var error in result1)
                {
                    errors += error.ErrorMessage + "\n";
                }
            }
            if (errors != "")
            {
                MessageBox.Show(errors, "Error");
                try
                {
                    Models.context.AgetDB().Users.Remove(user);
                    Models.context.AgetDB().SaveChanges();
                }
                catch { }
                return;
            }
            Models.context.AgetDB().Organizations.Add(org);
            Models.context.AgetDB().SaveChanges();
            SignIn signIn = new SignIn();
            signIn.Show();
            Close();
        }

        private void Click_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void cl_Back(object sender, RoutedEventArgs e)
        {
            SignIn signIn = new SignIn();
            signIn.Show();
            Close();
        }
    }
}
