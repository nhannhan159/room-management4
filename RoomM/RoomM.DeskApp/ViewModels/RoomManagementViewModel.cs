using RoomM.DeskApp.UIHelper;
using RoomM.Models.Rooms;
using RoomM.Business;
using RoomM.DeskApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;

namespace RoomM.DeskApp.ViewModels
{
    class RoomManagementViewModel : EditableViewModel<Room>
    {
        public RoomManagementViewModel()
            : base()
        {
        }

        private NewRoom newRoomDialog;
        private NewRoomViewModel newRoomViewModel { get; set; }

        protected override List<Room> GetEntitiesList()
        {
            return new List<Room>(RoomService.GetAll());
        }

        protected override Room BuildNewEntity()
        {
            this.newRoomDialog.Close();
            return newRoomViewModel.NewRoom;
        }

        protected override void SaveCurrentEntity()
        {
            try
            {
                RoomService.Add(this.CurrentEntity);
                MessageBox.Show("Tạo phòng mới thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo phòng mới thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override void SetCurrentEntity(Room entity)
        {
        }

        protected override bool EntityFilter(object obj)
        {
            return true;
        }

        public ICommand NewRoomCommand { get { return new RelayCommand(newRoomCommand, canExecute); } }
        private void newRoomCommand()
        {
            this.newRoomViewModel = new NewRoomViewModel();
            this.newRoomViewModel.NewCommand = new RelayCommand(NewCommandHandler, CanExecuteNewCommand);
            this.newRoomDialog = new NewRoom(this.newRoomViewModel);
            this.newRoomDialog.ShowDialog();
        }
        private bool canExecute()
        {
            return true;
        }

        protected override void EntitySelectionChanged(object sender, EventArgs e)
        {
            this.OnPropertyChanged("CurrentRoomCalendarView");
            this.OnPropertyChanged("CurrentRoomAssetView");
            this.OnPropertyChanged("CurrentRoomHistoryView");
        }

        public ICollectionView RoomTypesView
        {
            get { return CollectionViewSource.GetDefaultView(RoomService.GetAllRoomType()); }
        }

        public ICollectionView CurrentRoomCalendarView
        {
            get { return CollectionViewSource.GetDefaultView(CurrentEntity.RoomCalendars); }
        }

        public ICollectionView CurrentRoomAssetView
        {
            get { return CollectionViewSource.GetDefaultView(CurrentEntity.RoomAssets); }
        }

        public ICollectionView CurrentRoomHistoryView
        {
            get { return CollectionViewSource.GetDefaultView(CurrentEntity.AssetHistories); }
        }

    }
}
