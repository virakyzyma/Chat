using RegistrationWindow;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public  MainWindow()
        {
            InitializeComponent();
           

        }

        private  async void Button_Click(object sender, RoutedEventArgs e)
        {



            Lobby lobby = new Lobby(textBox1.Text);
            lobby.Show();
            this.Hide();


        }


     
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
          
        }
    }
}