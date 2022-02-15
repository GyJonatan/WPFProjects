﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gallery
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                Environment.Exit(0);
            }

            foreach (var path in Directory.GetFiles(fbd.SelectedPath, "*.jpg"))
            {
                Image img = new Image();
                img.Height = ActualWidth / 4;
                img.Margin = new Thickness(20);
                img.Source = new BitmapImage(new Uri(path));
                panel.Children.Add(img);
            }
        }

    }
}
