using RoomM.DeskApp.UIHelper;
using RoomM.Models.Rooms;
using RoomM.Models.Assets;
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
using System.Windows.Forms;




namespace RoomM.DeskApp.ViewModels
{
    class RoomManagementViewModel : EditableViewModel<Room>
    {
        

        public RoomManagementViewModel()
            : base()
        {
            List<RoomType> roomTypeList = new List<RoomType>(RoomService.GetAllRoomType());
            roomTypeList.Add(new RoomType("Tất cả"));
            this.roomTypeFilters = new CollectionView(roomTypeList);
            this.RoomTypeFilter = roomTypeList[roomTypeList.Count - 1];
        }

        private NewRoom newRoomDialog;
        private RoomType roomTypeFilter;
        private CollectionView roomTypeFilters;

        public CollectionView RoomTypeFilters
        {
            get { return this.roomTypeFilters; }
        }

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
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override void DeleteCurrentEntity()
        {
            this.CurrentEntity.IsUsing = false;
            this.SaveCurrentEntity();
        }

        protected override bool FilterAll(Room entity)
        {
            return entity.IsUsing;
        }

        protected override bool FilterNormal(Room entity)
        {
            bool filter = true;
            filter = filter && (entity.Name.Contains(this.NameFilter));
            if (this.RoomTypeFilter.Name != "Tất cả")
                filter = filter && (entity.RoomType.Name == this.RoomTypeFilter.Name);
            return filter;
        }

        public RoomType RoomTypeFilter
        {
            get { return this.roomTypeFilter; }
            set { this.roomTypeFilter = value; }
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
            get
            {
                if (CurrentEntity == null)
                    return CollectionViewSource.GetDefaultView(new List<RoomCalendar>());
                return CollectionViewSource.GetDefaultView(CurrentEntity.RoomCalendars);
            }
        }

        public ICollectionView CurrentRoomAssetView
        {
            get
            {
                if (CurrentEntity == null)
                    return CollectionViewSource.GetDefaultView(new List<RoomAsset>());
                return CollectionViewSource.GetDefaultView(CurrentEntity.RoomAssets);
            }
        }

        public ICollectionView CurrentRoomHistoryView
        {
            get
            {
                if (CurrentEntity == null)
                    return CollectionViewSource.GetDefaultView(new List<RoomAssetHistory>());
                return CollectionViewSource.GetDefaultView(CurrentEntity.AssetHistories);
            }
        }



        // commands
        public ICommand ExportToExcelCommand { get { return new RelayCommand(ExportToExcelCommandHandler, CanExecute); } }

        private void ExportToExcelCommandHandler()
        {
            RoomsReportToExcel report = new RoomsReportToExcel("sgu university", "roomM", "templates/roomlist_tmp.xls");

            List<Room> dataList = new List<Room>();
            if (AllPlusIsCheck)
                dataList = EntitiesList;
            else
            {
                foreach (Room r in EntitiesList)
                    if (r.IsUsing)
                        dataList.Add(r);
            }

            report.setupExport(dataList);
            report.save();
        }

        public ICommand ExportCalRegisterToExcelCommand { get { return new RelayCommand(ExportCalRegisterToExcelCommandHandler, CanExecute); } }

        private void ExportCalRegisterToExcelCommandHandler()
        {
            List<RoomCalendar> dataList = new List<RoomCalendar>();
            dataList = CurrentEntity.RoomCalendars.ToList();

            RoomCalendarsReportToExcel report = new RoomCalendarsReportToExcel("sgu university", "roomM", "templates/roomcalendar_tmp.xls");

            report.setupExport(dataList, CurrentEntity);
            report.save();
        }


        public ICommand ExportAssetsToExcelCommand { get { return new RelayCommand(ExportAssetsToExcelCommandHandler, CanExecute); } }

        private void ExportAssetsToExcelCommandHandler()
        {
            List<RoomAsset> dataList = new List<RoomAsset>();
            dataList = CurrentEntity.RoomAssets.ToList();

            AssetsReportToExcel report = new AssetsReportToExcel("sgu university", "roomM", "templates/roomasset_tmp.xls");

            report.setupExport(dataList, CurrentEntity);
            report.save();
        }

        public ICommand ExportHistoriesToExcelCommand { get { return new RelayCommand(ExportHistoriesToExcelCommandHandler, CanExecute); } }

        private void ExportHistoriesToExcelCommandHandler()
        {
            

            List<RoomAssetHistory> dataList = new List<RoomAssetHistory>();
            dataList = CurrentEntity.AssetHistories.ToList();

            RoomHistoriesReportToExcel report = new RoomHistoriesReportToExcel("sgu university", "roomM", "templates/roomhistory_tmp.xls");

            report.setupExport(dataList, CurrentEntity);
            report.save();
        }

    }
}
