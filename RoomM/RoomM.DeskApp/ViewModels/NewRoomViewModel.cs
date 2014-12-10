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
    public class NewRoomViewModel
    {
        private Room newRoom;

        public NewRoomViewModel()
        {
            newRoom = new Room();
        }

        public Room NewRoom
        {
            get { return this.newRoom; }
            set { this.newRoom = value; }
        }

        public ICollectionView RoomTypesView
        {
            get { return CollectionViewSource.GetDefaultView(RoomService.GetAllRoomType()); }
        }

        public ICommand NewCommand { get; set; }

    }
}
