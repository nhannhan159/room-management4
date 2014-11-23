using RoomM.DeskApp.UIHelper;
using RoomM.Models.Rooms;
using RoomM.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.DeskApp.ViewModels
{
    class RoomManagementViewModel : EditableViewModel<Room>
    {
        public RoomManagementViewModel() : base() 
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
    }
}
