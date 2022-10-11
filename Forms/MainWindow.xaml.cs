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

namespace Project
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User prUser;
        public MainWindow(User user)
        {
            InitializeComponent();
            prUser = user;
            if(user != null)
            {
                Settings.Visibility = Visibility.Visible;
                btAdd.Visibility = Visibility.Collapsed;
                btOrg.Visibility = Visibility.Collapsed;
            }
            gridM.Children.Add(new Forms.MainMenuControl(user));
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void clExit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void clOrgMenu(object sender, RoutedEventArgs e)
        {
            gridM.Children.Clear();
            gridM.Children.Add(new Forms.UserMenu());
        }

        private void clOrg(object sender, RoutedEventArgs e)
        {

            btOrg.Foreground = Brushes.White;
            btAbout.Foreground = Brushes.LightGray;
            btAdd.Foreground = Brushes.LightGray;
            btCatalog.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new Forms.OrganizationControl());
        }
        public void More(Models.Organization org)
        {
            gridM.Children.Clear();
            gridM.Children.Add(new Forms.MoreAboutOrganization(org));
        }
        public void Back(ContentControl cont)
        {
            gridM.Children.Clear();
            gridM.Children.Add(cont);
        }
        public void begindogovor(Room room)
        {
            gridM.Children.Clear();
            gridM.Children.Add(new Forms.AddContract(room));
        }

        private void clCatalog(object sender, RoutedEventArgs e)
        {
            btOrg.Foreground = Brushes.LightGray;
            btAbout.Foreground = Brushes.LightGray;
            btAdd.Foreground = Brushes.LightGray;
            btCatalog.Foreground = Brushes.White;
            btEvrazia.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new Forms.Сatalog());
        }

        private void clAbout(object sender, RoutedEventArgs e)
        {
            btOrg.Foreground = Brushes.LightGray;
            btAbout.Foreground = Brushes.White;
            btAdd.Foreground = Brushes.LightGray;
            btCatalog.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new Forms.About());
        }

        private void clAdd(object sender, RoutedEventArgs e)
        {
            btOrg.Foreground = Brushes.LightGray;
            btAbout.Foreground = Brushes.LightGray;
            btAdd.Foreground = Brushes.White;
            btCatalog.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.LightGray;
            gridM.Children.Clear();
            gridM.Children.Add(new Forms.AddOrg(null));
        }

        private void clEvrazia(object sender, RoutedEventArgs e)
        {
            btOrg.Foreground = Brushes.LightGray;
            btAbout.Foreground = Brushes.LightGray;
            btAdd.Foreground = Brushes.LightGray;
            btCatalog.Foreground = Brushes.LightGray;
            btEvrazia.Foreground = Brushes.White;
            gridM.Children.Clear();
            gridM.Children.Add(new Forms.MainMenuControl(prUser));
        }
    }
}
