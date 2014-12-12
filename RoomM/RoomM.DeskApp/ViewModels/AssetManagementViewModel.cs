using System;
using RoomM.DeskApp.UIHelper;
using RoomM.Models.Assets;
using RoomM.Business;
using RoomM.DeskApp.Views;
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

        public AssetManagementViewModel()
            : base() 
        { 
        }

        private NewAsset newAssetDialog;

        protected override List<Asset> GetEntitiesList()
        {
            return new List<Asset>(RoomAssetService.GetAllAsset());
        }

        protected override void SaveCurrentEntity()
        {
            try
            {
                RoomAssetService.AddOrEditAsset(this.CurrentEntity);
                RoomAssetService.Save();
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

        public ICollectionView CurrentRoomAssetView
        {
            get { return CollectionViewSource.GetDefaultView(CurrentEntity.RoomAssets); }
        }
    }
}
