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
using System.ServiceModel;
using SimpleCRUD;

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // 
        IService service;
        int selectedLang = 0;
        // resources IDs
        /*
         * 0 app title
         * 1 grand title
         * 2 
         * 3
         * 4
         * 5
         * 6
         * 7
         * 8
         * 9
         * 10
         */
        public MainWindow()
        {
            InitializeComponent();

            // init service connection
            Uri httpAddr = new Uri("http://127.0.0.1:9998/SimpleCRUD/Service");
            var channel = new ChannelFactory<IService>(new WSHttpBinding());
            var ep = new EndpointAddress(httpAddr);
            service = channel.CreateChannel(ep);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // prevent empty fields
            if (string.IsNullOrEmpty(txtb_username.Text))
            {
                //MessageBox.Show(service.getResource(10, selectedLang));
                MessageBox.Show("Please enter a username!");
                return;
            }

            if (string.IsNullOrEmpty(txtb_password.Password))
            {
                //MessageBox.Show(service.getResource(11, selectedLang));
                MessageBox.Show("Please enter a password!");
                return;
            }

            switch (service.login(txtb_username.Text, txtb_password.Password))
            {
                // loging success
                case 0:
                    //MessageBox.Show(service.getResource(12, selectedLang));
                    MessageBox.Show("Login successfully :)");
                    break;

                // user name doesn't exist
                case 1:
                    //MessageBox.Show(service.getResource(12, selectedLang));
                    MessageBox.Show("username error!");
                    return;

                // password doesn't match
                case 2:
                    //MessageBox.Show(service.getResource(12, selectedLang));
                    MessageBox.Show("password error!");
                    return;

                // other
                default:
                    //MessageBox.Show(service.getResource(15, selectedLang));
                    MessageBox.Show("error!");
                    return;
            }

            
        }
    }
}
