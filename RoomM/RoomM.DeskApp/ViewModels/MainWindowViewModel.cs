using RoomM.DeskApp.UIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace RoomM.DeskApp.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private const string RoomPage = "/Views/RoomManagement.xaml";
        private const string AssetPage = "/Views/AssetManagement.xaml";
        private const string StaffPage = "/Views/StaffManagement.xaml";

        public ICommand SelectRoomPage0 { get { return new RelayCommand(selectRoomPageCommand0, canExecuteTreeViewSelect); } }
        public ICommand SelectRoomPage1 { get { return new RelayCommand(selectRoomPageCommand0, canExecuteTreeViewSelect); } }
        public ICommand SelectRoomPage2 { get { return new RelayCommand(selectRoomPageCommand0, canExecuteTreeViewSelect); } }
        public ICommand SelectRoomPage3 { get { return new RelayCommand(selectRoomPageCommand0, canExecuteTreeViewSelect); } }
        public ICommand SelectAssetPage { get { return new RelayCommand(selectAssetPageCommand, canExecuteTreeViewSelect); } }
        public ICommand SelectStaffPage { get { return new RelayCommand(selectStaffPageCommand, canExecuteTreeViewSelect); } }

        private string sourcePage;
        public string SourcePage
        {
            get { return sourcePage; }
            set
            {
                sourcePage = value;
                OnPropertyChanged("SourcePage");
            }
        }

        private void selectRoomPageCommand0()
        {
            SourcePage = RoomPage;
        }

        private void selectAssetPageCommand()
        {
            SourcePage = AssetPage;
        }

        private void selectStaffPageCommand()
        {
            SourcePage = StaffPage;
        }

        private bool canExecuteTreeViewSelect()
        {
            return true;
        }
    }
}
