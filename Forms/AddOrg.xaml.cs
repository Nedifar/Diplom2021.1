using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net.Http;
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
    /// Логика взаимодействия для AddOrg.xaml
    /// </summary>
    public partial class AddOrg : UserControl
    {
        Models.Room room = new Models.Room();
        string image;
        public AddOrg(Models.Room roomi)
        {
            InitializeComponent();
            if (roomi != null)
            {
                room = roomi;
            }
            List<int> list = new List<int>();
            for (int i = 1; i < 20; i++)
            {
                list.Add(i);
            }
            DataContext = room;
            tb_floor.ItemsSource = list;
        }

        private void cl_toAdd(object sender, RoutedEventArgs e)
        {
            string errors = "";
            var result = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(room);
            if(!Validator.TryValidateObject(room, context, result, true))
            {
                foreach(var error in result)
                {
                    errors += error + "\n";
                }
                MessageBox.Show(errors, "Error");
                return;
            }
            if(room.Id_Room==0)
            Models.context.AgetDB().Rooms.Add(room);
            Models.context.AgetDB().SaveChanges();
        }

        private void cl_toImage(object sender, RoutedEventArgs e)
        {
            var str = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = @"c:\temp\";
            if (openFileDialog.ShowDialog() == true)
            {
                str = openFileDialog.FileName.Split(new[] { '\\' }).Last();
                File.Copy(openFileDialog.FileName, System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources", str), true);
                image = str;
                room.Image = image;
            }
        }

        private void tb_floor_DropDownOpened(object sender, EventArgs e)
        {
            tb_floor.Foreground = Brushes.Black;
        }

        private void tb_floor_DropDownClosed(object sender, EventArgs e)
        {
            tb_floor.Foreground = Brushes.White;
            
        }
    }
}
