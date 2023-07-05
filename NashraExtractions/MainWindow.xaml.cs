using NashraExtractions.JsonFiles;
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

namespace NashraExtractions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ValidationAsync();


        }
        private async void ValidationAsync()
        {
            while (true)
            {
                await Task.Delay(1000);
                if (string.IsNullOrWhiteSpace(username.Text) || string.IsNullOrWhiteSpace(password.Password))
                    Login.IsEnabled = false;
                else
                    Login.IsEnabled = true;

            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            DbAPI.LoginAuthn(username.Text, password.Password,this);
        }
    }
}
