﻿using RoomM.Models.Assets;
using RoomM.DeskApp.UIHelper;
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

namespace RoomM.DeskApp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class NewAsset : Window
    {
        public NewAsset()
        {
            InitializeComponent();
        }

        public NewAsset(NewEntityViewModel<Asset> context)
            : this()
        {
            this.DataContext = context;
        }


    }
}
