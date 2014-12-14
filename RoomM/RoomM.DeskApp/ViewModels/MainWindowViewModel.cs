using RoomM.DeskApp.UIHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;

namespace RoomM.DeskApp.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        public static MainWindowViewModel instance;
        public const string READY = "Sẵn sàng";
        public const string WAIT = "Xin đợi...";
        public const string COMPLETE = "Hoàn thành";


        public string statusState;
        public string statusExpend;


        public MainWindowViewModel() : base()
        {
            instance = this;
            StatusState = READY;
            StatusExpend = "Lưu tại C:\\Users\\le quoc vu\\Downloads\\Compressed\\NPOI.Examples 20101112 package\\20101112";


            // Properties.Settings.Default.yahoo = "yahoo.com";
            // Properties.Settings.Default.Save();


            Console.WriteLine("###" + Properties.Settings.Default.yahoo);

        }

        protected bool CanExecute() { return true; }

        public string StatusState 
        {
            get { return statusState; }
            set 
            {
                if (statusState != value)
                {
                    Console.WriteLine("change: " + value);

                    statusState = value;
                    this.OnPropertyChanged("StatusState");
                }
            }
        }

        public string StatusExpend
        {
            get { return statusExpend; }
            set
            {
                if (statusExpend != value)
                {
                    statusExpend = value;
                    this.OnPropertyChanged("StatusExpend");
                }
            }
        }

        public void ChangeStateToReady(string expend = "")
        {
            StatusState = READY;
            StatusExpend = expend;
        }

        public void ChangeStateToComplete(string expend = "")
        {
            StatusState = COMPLETE;
            StatusExpend = expend;
        }

        public void ChangeStateToWait(string expend = "")
        {
            StatusState = WAIT;
            StatusExpend = expend;
        }

        //command

        public ICommand FakeCommand { get { return new RelayCommand(FakeCommandHandler, CanExecute); } }

        private void FakeCommandHandler()
        {
            Console.WriteLine("click");
            StatusExpend = "asbdjbakjsdkasndknaskdnklasdkl";
        }

    }
}
