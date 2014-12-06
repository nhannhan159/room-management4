using System;
using RoomM.DeskApp.UIHelper;
using RoomM.Models.Assets;
using RoomM.Business;
using RoomM.DeskApp.Views;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RoomM.DeskApp.ViewModels
{
    class AssetManagementViewModel : EditableViewModel<Asset>
    {

        public AssetManagementViewModel()
            : base() 
        { 
        }

        protected override List<Asset> GetEntitiesList()
        {
            return new List<Asset>(RoomAssetService.GetAllAsset());
        }

        protected override Asset BuildNewEntity()
        {
            return new Asset();
        }

        protected override void SaveCurrentEntity()
        {
            /*try
            {
                BaoTriService.SaveBaoTri(this.CurrentEntity);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu dữ liệu thất bại! \nMã lỗi: " + ex.Message);
            }

            MessageBox.Show("Lưu dữ liệu thành công!");*/
        }

        protected override void SetCurrentEntity(Asset entity)
        {
            // throw new NotImplementedException();
        }

        protected override bool EntityFilter(object obj)
        {
            return true;
            /*Baotri bt = obj as Baotri;
            if (string.IsNullOrWhiteSpace(this.Filter) || this.Filter.Length == 0)
            {
                return true;
            }
            else
            {
                switch (this._typeFilter)
                {
                    case TypeFilter.NgayBT:
                        return bt.NgayBTString.Equals(_ngayBTFilter.ToShortDateString());
                    default:
                        return bt.Mota.Contains(Filter) || bt.Xe.ToString().Contains(Filter);
                }
            }*/
        }

        public ICommand NewAssetCommand { get { return new RelayCommand(newAssetCommand, canExecute); } }
        private void newAssetCommand()
        {
            var newAsset = new NewAsset();
            newAsset.ShowDialog();
        }
        private bool canExecute()
        {
            return true;
        }
    }
}
