using Microsoft.AspNetCore.SignalR.Client;
using MyChat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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

namespace RegistrationWindow
{
    /// <summary>
    /// Interaction logic for Lobby.xaml
    /// </summary>
    public partial class Lobby : Window
    {
        static string user;
        HubConnection connection;

       

        public Lobby(string user2)
        {
            InitializeComponent();
            user = user2;

            connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7158/chat")
            .Build();

            connection.On<string, string>("Receive", (userName, message) =>
            Dispatcher.Invoke(() =>
            {
                chatListBox.Items.Insert(0, userName + ":" + message);
                onlineListBox.Items.Add(userName);
            }));

            this.Loaded += MainWindow_loaded;
        }

        private async void MainWindow_loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.StartAsync();
                chatListBox.Items.Add("You entered the chat room");

            }
            catch (Exception ex)
            {
                chatListBox.Items.Add($"{ex.Message}");
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.InvokeAsync("Send message", user, textBox1.Text);
            }
            catch (Exception ex)
            {
                chatListBox.Items.Add(ex.Message);
            }
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            chatListBox.Items.Remove(chatListBox.SelectedItem);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           

            this.Close();
        }



        private void chatListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
    

