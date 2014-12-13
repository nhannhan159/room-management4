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
            this.roomCalendarViewFilterIsCheck = false;
            this.roomAssetViewFilterIsCheck = false;
            this.roomHistoryViewFilterIsCheck = false;
            this.rcvDateFromFilter=new DateTime(2000,1,1);
            this.rcvDateToFilter=DateTime.Now;
            this.rcvPeriodsFilter=0;
            this.rcvBeginTimeFilter=0;
            this.rcvRegistrantFilter="";
            List<RoomCalendarStatus> rcvStatusList=new List<RoomCalendarStatus>(RoomCalendarService.GetAllStatus());
            rcvStatusList.Add(new RoomCalendarStatus("Tất cả"));
            this.rcvStatusFilters=new CollectionView(rcvStatusList);
            this.rcvStatusFilter=rcvStatusList[rcvStatusList.Count-1];
            this.ravAssetNameFilter="";
            this.rhvDateFromFilter=new DateTime(2000,1,1);
            this.rhvDateToFilter=DateTime.Now;
            this.rhvAssetNameFilter = "";
            List<HistoryType> rhvTypeList=new List<HistoryType>(RoomAssetService.GetAllAssetHistoryType());
            rhvTypeList.Add(new HistoryType("Tất cả"));
            this.rhvTypeFilters=new CollectionView(rhvTypeList);
            this.rhvTypeFilter=rhvTypeList[rhvTypeList.Count-1];
        }

        private NewRoom newRoomDialog;
        private RoomType roomTypeFilter;
        private CollectionView roomTypeFilters;
        private ICollectionView currentRoomCalendarView;
        private ICollectionView currentRoomAssetView;
        private ICollectionView currentRoomHistoryView;
        private bool roomCalendarViewFilterIsCheck;
        private bool roomAssetViewFilterIsCheck;
        private bool roomHistoryViewFilterIsCheck;
        private DateTime rcvDateFromFilter;
        private DateTime rcvDateToFilter;
        private int rcvPeriodsFilter;
        private string rcvRegistrantFilter;
        private int rcvBeginTimeFilter;
        private RoomCalendarStatus rcvStatusFilter;
        private CollectionView rcvStatusFilters;
        private string ravAssetNameFilter;
        private DateTime rhvDateFromFilter;
        private DateTime rhvDateToFilter;
        private string rhvAssetNameFilter;
        private HistoryType rhvTypeFilter;
        private CollectionView rhvTypeFilters;

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

        protected override bool IsUsing(Room entity) 
        {
            return entity.IsUsing;
        }

        protected override bool GeneralFilter(Room entity)
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

        protected override void SetAdditionViewChange()
        {
            if (this.CurrentEntity == null)
            {
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(new List<RoomCalendar>());
                this.currentRoomAssetView = CollectionViewSource.GetDefaultView(new List<RoomAsset>());
                this.currentRoomHistoryView = CollectionViewSource.GetDefaultView(new List<RoomAssetHistory>());
            }
            else
            {
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(this.CurrentEntity.RoomCalendars);
                this.currentRoomAssetView = CollectionViewSource.GetDefaultView(this.CurrentEntity.RoomAssets);
                this.currentRoomHistoryView = CollectionViewSource.GetDefaultView(this.CurrentEntity.AssetHistories);
            }
            this.currentRoomCalendarView.Filter += RoomCalendarViewFilter;
            this.currentRoomAssetView.Filter += RoomAssetViewFilter;
            this.currentRoomHistoryView.Filter += RoomHistoryViewFilter;
        }

        public ICollectionView RoomTypesView
        {
            get { return CollectionViewSource.GetDefaultView(RoomService.GetAllRoomType()); }
        }

        public ICollectionView CurrentRoomCalendarView
        {
            get { return this.currentRoomCalendarView; }
        }

        public ICollectionView CurrentRoomAssetView
        {
            get { return this.currentRoomAssetView; }
        }

        public ICollectionView CurrentRoomHistoryView
        {
            get { return this.currentRoomHistoryView; }
        }

        private bool RoomCalendarViewFilter(object obj)
        {
            RoomCalendar entity = obj as RoomCalendar;
            bool filter = true;
            if (this.roomCalendarViewFilterIsCheck)
            {
                filter = filter && (entity.Date >= this.RcvDateFromFilter);
                filter = filter && (entity.Date <= this.RcvDateToFilter);
                filter = filter && entity.Staff.Name.Contains(this.RcvRegistrantFilter);
                if (this.RcvPeriodsFilter > 0)
                    filter = filter && (entity.Length == this.RcvPeriodsFilter);
                if (this.RcvBeginTimeFilter > 0)
                    filter = filter && (entity.Start == this.RcvBeginTimeFilter);
                if (this.RcvStatusFilter.Name != "Tất cả")
                    filter = filter && (entity.RoomCalendarStatus.Name == this.RcvStatusFilter.Name);
            }
            return filter;
        }

        private bool RoomAssetViewFilter(object obj)
        {
            RoomAsset entity = obj as RoomAsset;
            bool filter = true;
            if (this.roomAssetViewFilterIsCheck)
            {
                filter = filter && entity.Asset.Name.Contains(this.RavAssetNameFilter);
            }
            return filter;
        }

        private bool RoomHistoryViewFilter(object obj)
        {
            RoomAssetHistory entity = obj as RoomAssetHistory;
            bool filter = true;
            if (this.roomHistoryViewFilterIsCheck)
            {
                filter = filter && (entity.Date >= this.RhvDateFromFilter);
                filter = filter && (entity.Date <= this.RhvDateToFilter);
                filter = filter && entity.Asset.Name.Contains(this.RhvAssetNameFilter);
                if (this.RhvTypeFilter.Name != "Tất cả")
                    filter = filter && (entity.HistoryType.Name == this.RhvTypeFilter.Name);
            }
            return filter;
        }

        public ICommand RoomCalendarViewFilterCommand { get { return new RelayCommand(RoomCalendarViewFilterCommandHandler, CanExecute); } }
        public ICommand RoomAssetViewFilterCommand { get { return new RelayCommand(RoomAssetViewFilterCommandHandler, CanExecute); } }
        public ICommand RoomHistoryViewFilterCommand { get { return new RelayCommand(RoomHistoryViewFilterCommandHandler, CanExecute); } }
        public ICommand RoomCalendarViewFilterAllCommand { get { return new RelayCommand(RoomCalendarViewFilterAllCommandHandler, CanExecute); } }
        public ICommand RoomAssetViewFilterAllCommand { get { return new RelayCommand(RoomAssetViewFilterAllCommandHandler, CanExecute); } }
        public ICommand RoomHistoryViewFilterAllCommand { get { return new RelayCommand(RoomHistoryViewFilterAllCommandHandler, CanExecute); } }

        private void RoomCalendarViewFilterCommandHandler()
        {
            this.roomCalendarViewFilterIsCheck = true;
            this.currentRoomCalendarView.Refresh();
        }

        private void RoomAssetViewFilterCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = true;
            this.currentRoomAssetView.Refresh();
        }

        private void RoomHistoryViewFilterCommandHandler()
        {
            this.roomHistoryViewFilterIsCheck = true;
            this.currentRoomHistoryView.Refresh();
        }

        private void RoomCalendarViewFilterAllCommandHandler()
        {
            this.roomCalendarViewFilterIsCheck = false;
            this.currentRoomCalendarView.Refresh();
        }

        private void RoomAssetViewFilterAllCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = false;
            this.currentRoomAssetView.Refresh();
        }

        private void RoomHistoryViewFilterAllCommandHandler()
        {
            this.roomHistoryViewFilterIsCheck = false;
            this.currentRoomHistoryView.Refresh();
        }

        public DateTime RcvDateFromFilter
        {
            get { return this.rcvDateFromFilter; }
            set { this.rcvDateFromFilter = value; }
        }

        public DateTime RcvDateToFilter
        {
            get { return this.rcvDateToFilter; }
            set { this.rcvDateToFilter = value; }
        }

        public int RcvPeriodsFilter
        {
            get { return this.rcvPeriodsFilter; }
            set { this.rcvPeriodsFilter = value; }
        }

        public int RcvBeginTimeFilter
        {
            get { return this.rcvBeginTimeFilter; }
            set { this.rcvBeginTimeFilter = value; }
        }

        public string RcvRegistrantFilter
        {
            get { return this.rcvRegistrantFilter; }
            set { this.rcvRegistrantFilter = value; }
        }

        public RoomCalendarStatus RcvStatusFilter
        {
            get { return this.rcvStatusFilter; }
            set { this.rcvStatusFilter = value; }
        }

        public string RavAssetNameFilter
        {
            get { return this.ravAssetNameFilter; }
            set { this.ravAssetNameFilter = value; }
        }

        public string RhvAssetNameFilter
        {
            get { return this.rhvAssetNameFilter; }
            set { this.rhvAssetNameFilter = value; }
        }

        public DateTime RhvDateFromFilter
        {
            get { return this.rhvDateFromFilter; }
            set { this.rhvDateFromFilter= value; }
        }

        public DateTime RhvDateToFilter
        {
            get { return this.rhvDateToFilter; }
            set { this.rhvDateToFilter = value; }
        }

        public HistoryType RhvTypeFilter
        {
            get { return this.rhvTypeFilter; }
            set { this.rhvTypeFilter = value; }
        }

        public CollectionView RcvStatusFilters
        {
            get { return this.rcvStatusFilters; }
        }

        public CollectionView RhvTypeFilters
        {
            get { return this.rhvTypeFilters; }
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
