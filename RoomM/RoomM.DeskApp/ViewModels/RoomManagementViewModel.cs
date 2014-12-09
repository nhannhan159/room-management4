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

        protected override List<Room> GetEntitiesList()
        {
            return new List<Room>(RoomService.GetAll());
        }

        protected override Room BuildNewEntity()
        {
            return new Room();
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

        protected override void SetCurrentEntity(Room entity)
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

        public ICommand NewRoomCommand { get { return new RelayCommand(newRoomCommand, canExecute); } }
        private void newRoomCommand()
        {
            var newRoom = new NewRoom();
            newRoom.ShowDialog();
        }
        private bool canExecute()
        {
            return true;
        }

        public override Room CurrentEntity
        {
            get { return this.currentEntity; }
            set
            {
                if (this.currentEntity != value)
                {
                    Console.WriteLine("hit me!");

                    this.currentEntity = value;
                    this.SetCurrentEntity(value);
                    this.canExecuteSaveCommand = (this.currentEntity != null);
                    this.OnPropertyChanged(EditableViewModel<Room>.currentEntityPropertyName);
                    this.OnPropertyChanged("CurrentRoomCalendarView");
                    this.OnPropertyChanged("CurrentRoomAssetView");
                    this.OnPropertyChanged("CurrentRoomHistoryView");
                }
                //Console.WriteLine("Number selected: " + GetNumSelected());
                this.canExecuteDelCommand = GetNumSelected() > 0;
            }
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
