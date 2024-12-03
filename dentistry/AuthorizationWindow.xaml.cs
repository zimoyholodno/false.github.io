﻿using System;
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
using System.Windows.Shapes;
using dentistry.Properties;

namespace dentistry
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Account(object sender, RoutedEventArgs e)
        {
            if (Authorization.GetRole(textBoxLogin.Text, textBoxPassword.Text) == null)
            {
                MessageBox.Show("Данные введены не корректно!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Button_click_out(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
