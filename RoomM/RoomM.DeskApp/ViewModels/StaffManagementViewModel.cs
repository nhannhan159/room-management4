using RoomM.DeskApp.UIHelper;
using RoomM.DeskApp.Views;
using RoomM.Models.Staffs;
using RoomM.Models.Rooms;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories.Staffs;
using RoomM.Repositories.Rooms;
using System;
using System.Windows;
using System.Windows.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RoomM.DeskApp.ViewModels
{
    public class StaffManagementViewModel : EditableViewModel<Staff>
    {

        private IStaffRepository staffRepo = RepositoryFactory.GetRepository<IStaffRepository, Staff>();
        private IRoomCalendarStatusRepository roomCalStatusRepo = RepositoryFactory.GetRepository<IRoomCalendarStatusRepository, RoomCalendarStatus>();

        public StaffManagementViewModel()
            : base() 
        {
            this.sexFilter = 0;
            this.roomCalendarViewFilterIsCheck = false;
            this.rcvRoomFilter = "";
            this.rcvDateFromFilter = new DateTime(2000, 1, 1);
            this.rcvDateToFilter = DateTime.Now;
            this.rcvPeriodsFilter = 0;
            this.rcvBeginTimeFilter = 0;
            List<RoomCalendarStatus> rcvStatusList = new List<RoomCalendarStatus>(this.roomCalStatusRepo.GetAll());
            rcvStatusList.Add(new RoomCalendarStatus("Tất cả"));
            this.rcvStatusFilters = new CollectionView(rcvStatusList);
            this.rcvStatusFilter = rcvStatusList[rcvStatusList.Count - 1];
        }

        private NewStaff newStaffDialog;
        private int sexFilter;
        private ICollectionView currentRoomCalendarView;
        private bool roomCalendarViewFilterIsCheck;
        private string rcvRoomFilter;
        private DateTime rcvDateFromFilter;
        private DateTime rcvDateToFilter;
        private int rcvPeriodsFilter;
        private int rcvBeginTimeFilter;
        private RoomCalendarStatus rcvStatusFilter;
        private CollectionView rcvStatusFilters;

        protected override List<Staff> GetEntitiesList()
        {
            return new List<Staff>(this.staffRepo.GetAll());
        }

        protected override void SaveCurrentEntity()
        {
            try
            {
                if (this.CurrentEntity.ID > 0)
                    this.staffRepo.Edit(this.CurrentEntity);
                else
                    this.staffRepo.Add(this.CurrentEntity);
                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override void DeleteCurrentEntity()
        {
            this.CurrentEntity.IsWorking = false;
            this.SaveCurrentEntity();
        }

        protected override bool IsUsing(Staff entity)
        {
            return entity.IsWorking;
        }

        protected override bool GeneralFilter(Staff entity)
        {
            bool filter = true;
            filter = filter && (entity.Name.Contains(this.NameFilter));
            if (this.SexFilter != 0)
                filter = filter && (this.SexFilter == 1 ? (entity.Sex == true) : (entity.Sex == false));
            return filter;
        }

        public int SexFilter
        {
            get { return this.sexFilter; }
            set { this.sexFilter = value; }
        }

        protected override void NewDialogCommandHandler()
        {
            this.newEntityViewModel = new NewEntityViewModel<Staff>();
            this.newEntityViewModel.NewCommand = this.NewCommand;
            this.newStaffDialog = new NewStaff(this.newEntityViewModel);
            this.newStaffDialog.ShowDialog();
        }

        protected override void CloseNewEntityDialog()
        {
            this.newStaffDialog.Close();
        }

        protected override void EntitySelectionChanged(object sender, EventArgs e)
        {
            this.OnPropertyChanged("CurrentRoomCalendarView");
        }

        protected override void SetAdditionViewChange()
        {
            if (this.CurrentEntity == null)
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(new List<RoomCalendar>());
            else
                this.currentRoomCalendarView = CollectionViewSource.GetDefaultView(this.CurrentEntity.RoomCalendars);
            this.currentRoomCalendarView.Filter += RoomCalendarViewFilter;
        }

        public ICollectionView CurrentRoomCalendarView
        {
            get { return this.currentRoomCalendarView; }
        }

        public CollectionView RcvStatusFilters
        {
            get { return this.rcvStatusFilters; }
        }

        private bool RoomCalendarViewFilter(object obj)
        {
            RoomCalendar entity = obj as RoomCalendar;
            bool filter = true;
            if (this.roomCalendarViewFilterIsCheck)
            {
                filter = filter && entity.Room.Name.Contains(this.RcvRoomFilter);
                filter = filter && (entity.Date >= this.RcvDateFromFilter);
                filter = filter && (entity.Date <= this.RcvDateToFilter);
                if (this.RcvPeriodsFilter > 0)
                    filter = filter && (entity.Length == this.RcvPeriodsFilter);
                if (this.RcvBeginTimeFilter > 0)
                    filter = filter && (entity.Start == this.RcvBeginTimeFilter);
                if (this.RcvStatusFilter.Name != "Tất cả")
                    filter = filter && (entity.RoomCalendarStatus.Name == this.RcvStatusFilter.Name);
            }
            return filter;
        }

        public ICommand RoomCalendarViewFilterCommand { get { return new RelayCommand(RoomCalendarViewFilterCommandHandler, CanExecute); } }
        public ICommand RoomCalendarViewFilterAllCommand { get { return new RelayCommand(RoomCalendarViewFilterAllCommandHandler, CanExecute); } }

        private void RoomCalendarViewFilterCommandHandler()
        {
            this.roomCalendarViewFilterIsCheck = true;
            this.currentRoomCalendarView.Refresh();
        }

        private void RoomCalendarViewFilterAllCommandHandler()
        {
            this.roomCalendarViewFilterIsCheck = false;
            this.currentRoomCalendarView.Refresh();
        }

        public string RcvRoomFilter
        {
            get { return this.rcvRoomFilter; }
            set { this.rcvRoomFilter = value; }
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

        public RoomCalendarStatus RcvStatusFilter
        {
            get { return this.rcvStatusFilter; }
            set { this.rcvStatusFilter = value; }
        }
    }
}
