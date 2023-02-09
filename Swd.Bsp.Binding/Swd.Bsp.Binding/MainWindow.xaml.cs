using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace Swd.Bsp.Binding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBasicBinding_Click(object sender, RoutedEventArgs e)
        {
            // Variante 2: Konstruktor
            fBasicBinding f = new fBasicBinding(this);
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.Width = 1200;
            f.Height = 900;
            
            // Variante 1: Öffentliche Eigenschaft
            //f.CallerWindow = this;

            this.Hide();
            f.Show();
        }

        private void BtnObjectBinding_Click(object sender, RoutedEventArgs e)
        {
            // Variante 2: Konstruktor
            fObjectBinding f = new fObjectBinding(this);
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.Width = 1200;
            f.Height = 900;
            
            // Variante 1: Öffentliche Eigenschaft
            //f.CallerWindow = this;

            this.Hide();
            f.Show();
        }

        private void BtnCollectionBinding_OnClick(object sender, RoutedEventArgs e)
        {
            // Variante 2: Konstruktor
            fCollectionBinding f = new fCollectionBinding(this);
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.Width = 1200;
            f.Height = 900;
            
            // Variante 1: Öffentliche Eigenschaft
            //f.CallerWindow = this;

            //this.Hide();
            f.Show();
        }

        private void BtnTemplates_OnClick(object sender, RoutedEventArgs e)
        {
            // Variante 2: Konstruktor
            fTemplates f = new fTemplates(this);
            f.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            f.Width = 1200;
            f.Height = 900;
            
            // Variante 1: Öffentliche Eigenschaft
            //f.CallerWindow = this;

            //this.Hide();
            f.Show();
        }
    }
}