using RoomM.DeskApp.UIHelper;
using RoomM.Models.Assets;
using RoomM.Models.Rooms;
using RoomM.DeskApp.Views;
using RoomM.Repositories.RepositoryFramework;
using RoomM.Repositories.Rooms;
using RoomM.Repositories.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Data;
using System.ComponentModel;

namespace RoomM.DeskApp.ViewModels
{
    class AssetManagementViewModel : EditableViewModel<Asset>
    {

        private IAssetRepository assRepo = RepositoryFactory.GetRepository<IAssetRepository, Asset>();
        private IRoomRepository roomRepo = RepositoryFactory.GetRepository<IRoomRepository, Room>();
        private IRoomTypeRepository roomTypeRepo = RepositoryFactory.GetRepository<IRoomTypeRepository, RoomType>();
        private IRoomAssetRepository roomAssRepo = RepositoryFactory.GetRepository<IRoomAssetRepository, RoomAsset>();

        public AssetManagementViewModel()
            : base() 
        {
            this.roomFilter = "";
            this.roomAssetViewFilterIsCheck = false;
            this.ravRoomNameFilter = "";
            List<RoomType> roomTypeList = new List<RoomType>(this.roomTypeRepo.GetAll());
            roomTypeList.Add(new RoomType("Tất cả"));
            this.roomTypeFilters = new CollectionView(roomTypeList);
            this.roomTypeFilter1 = roomTypeList[roomTypeList.Count - 1];
            this.roomTypeFilter2 = roomTypeList[roomTypeList.Count - 1];
        }

        private NewAsset newAssetDialog;
        private string roomFilter;
        private ICollectionView currentRoomAssetView;
        private bool roomAssetViewFilterIsCheck;
        private string ravRoomNameFilter;
        private RoomType roomTypeFilter1;
        private RoomType roomTypeFilter2;
        private CollectionView roomTypeFilters;

        protected override List<Asset> GetEntitiesList()
        {
            return new List<Asset>(this.assRepo.GetAll());
        }

        protected override void SaveCurrentEntity()
        {
            try
            {
                if (this.CurrentEntity.ID > 0)
                    this.assRepo.Edit(this.CurrentEntity);
                else
                    this.assRepo.Add(this.CurrentEntity);
                MessageBox.Show("Cập nhật dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }
        }

        protected override void DeleteCurrentEntity()
        {
            this.CurrentEntity.IsUsing = false;
            this.SaveCurrentEntity();
        }

        protected override bool IsUsing(Asset entity)
        {
            return entity.IsUsing;
        }

        protected override bool GeneralFilter(Asset entity)
        {
            bool filter = true;
            filter = filter && (entity.Name.Contains(this.NameFilter));
            filter = filter && (entity.AllRoomName.Contains(this.RoomFilter));
            return filter;
        }

        public string RoomFilter
        {
            get { return this.roomFilter; }
            set { this.roomFilter = value; }
        }

        public CollectionView RoomTypeFilters
        {
            get { return this.roomTypeFilters; }
        }

        public RoomType RoomTypeFilter1
        {
            get { return this.roomTypeFilter1; }
            set { this.roomTypeFilter1 = value; }
        }

        public RoomType RoomTypeFilter2
        {
            get { return this.roomTypeFilter2; }
            set { this.roomTypeFilter2 = value; }
        }

        protected override void NewDialogCommandHandler()
        {
            this.newEntityViewModel = new NewEntityViewModel<Asset>();
            this.newEntityViewModel.NewCommand = this.NewCommand;
            this.newAssetDialog = new NewAsset(this.newEntityViewModel);
            this.newAssetDialog.ShowDialog();
        }

        protected override void CloseNewEntityDialog()
        {
            this.newAssetDialog.Close();
        }

        protected override void EntitySelectionChanged(object sender, EventArgs e)
        {
            this.OnPropertyChanged("CurrentRoomAssetView");
        }

        protected override void SetAdditionViewChange()
        {
            if (this.CurrentEntity == null)
                this.currentRoomAssetView = CollectionViewSource.GetDefaultView(new List<RoomAsset>());
            else
                this.currentRoomAssetView = CollectionViewSource.GetDefaultView(this.CurrentEntity.RoomAssets);
            this.currentRoomAssetView.Filter += RoomAssetViewFilter;
        }

        public ICollectionView CurrentRoomAssetView
        {
            get { return this.currentRoomAssetView; }
        }

        private bool RoomAssetViewFilter(object obj)
        {
            RoomAsset entity = obj as RoomAsset;
            bool filter = true;
            if (this.roomAssetViewFilterIsCheck)
            {
                filter = filter && entity.Room.Name.Contains(this.RavRoomNameFilter);
            }
            return filter;
        }

        public ICommand RoomAssetViewFilterCommand { get { return new RelayCommand(RoomAssetViewFilterCommandHandler, CanExecute); } }
        public ICommand RoomAssetViewFilterAllCommand { get { return new RelayCommand(RoomAssetViewFilterAllCommandHandler, CanExecute); } }

        private void RoomAssetViewFilterCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = true;
            this.currentRoomAssetView.Refresh();
        }

        private void RoomAssetViewFilterAllCommandHandler()
        {
            this.roomAssetViewFilterIsCheck = false;
            this.currentRoomAssetView.Refresh();
        }

        public string RavRoomNameFilter
        {
            get { return this.ravRoomNameFilter; }
            set { this.ravRoomNameFilter = value; }
        }
    }
}
