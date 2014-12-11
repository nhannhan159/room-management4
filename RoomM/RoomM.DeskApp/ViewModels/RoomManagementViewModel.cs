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
        private CollectionView chatLuongFilters;
        private CollectionView hangXeFilters;

        private RoomType roomTypeFilter;
        private RoomFilter roomFilter;

        enum RoomFilter
        {
            RoomType,
            All
        };

        protected override List<Room> GetEntitiesList()
        {
            return new List<Room>(RoomService.GetAll());
        }

        protected override void SaveCurrentEntity()
        {
            try
            {
                RoomService.AddOrEdit(this.CurrentEntity);
                RoomService.Save();
                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override bool EntityFilter(object obj)
        {
            return true;
        }

        protected override void NewDialogCommandHandler()
        {
            this.newEntityViewModel = new NewEntityViewModel<Room>();
            this.newEntityViewModel.NewCommand = this.NewCommand;
            this.newRoomDialog = new NewRoom(this.newEntityViewModel);
            this.newRoomDialog.roomTypeCB.ItemsSource = RoomTypesView;
            this.newRoomDialog.ShowDialog();
        }

        protected override void CloseNewEntityDialog()
        {
            this.newRoomDialog.Close();
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
