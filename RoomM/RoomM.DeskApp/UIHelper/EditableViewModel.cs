using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace RoomM.DeskApp.UIHelper
{
    public abstract class EditableViewModel<T> 
        : ViewModel where T : EntityBase, new()
    {

        private bool allPlusIsCheck;
        private bool filterIsCheck;
        private T currentEntity;
        private List<T> entitiesList;
        private ICollectionView entitiesView;
        private string namefilter;
        protected bool canExecuteSaveCommand;
        protected bool canExecuteNewCommand;
        protected bool canExecuteDelCommand;
        protected NewEntityViewModel<T> newEntityViewModel;

        protected EditableViewModel()
            : base()
        {
            this.currentEntity = default(T);
            this.entitiesList = this.GetEntitiesList();
            this.entitiesView = CollectionViewSource.GetDefaultView(this.entitiesList);
            this.entitiesView.CurrentChanged += EntitySelectionChanged;
            this.NameFilter = "";
            this.allPlusIsCheck = false;
            this.filterIsCheck = false;
            this.entitiesView.Filter += EntityFilter;
            this.canExecuteNewCommand = true;
            this.canExecuteSaveCommand = false;
            this.canExecuteDelCommand = false;
        }

        protected abstract List<T> GetEntitiesList();
        protected abstract void SaveCurrentEntity();
        protected abstract void CloseNewEntityDialog();

        public T CurrentEntity
        {
            get { return this.currentEntity; }
            set
            {
                if (this.currentEntity != value)
                {
                    this.currentEntity = value;
                    this.canExecuteSaveCommand = (this.currentEntity != null);
                    this.OnPropertyChanged("CurrentEntity");
                }
            }
        }

        protected virtual void EntitySelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("CHANGED...");
        }

        protected virtual bool FilterAll(T entity) { return true; }
        protected virtual bool FilterNormal(T entity) { return true; }

        private bool EntityFilter(object obj)
        {
            T entity = obj as T;
            bool filter=true;
            if (!this.allPlusIsCheck)
                filter = filter && this.FilterAll(entity);
            if (this.filterIsCheck)
                filter = filter && this.FilterNormal(entity);
            return filter;
        }

        public bool AllPlusIsCheck
        {
            get { return this.allPlusIsCheck; }
            set
            {
                this.allPlusIsCheck = value;
                OnPropertyChanged("AllPlusIsCheck");
            }
        }

        public string NameFilter
        {
            get { return this.namefilter; }
            set { this.namefilter = value; }
        }

        protected List<T> EntitiesList
        {
            get { return this.entitiesList; }
            set { this.entitiesList = value; }
        }

        public ICollectionView EntitiesView
        {
            get { return this.entitiesView; }
        }

        public ICommand SaveCommand { get { return new RelayCommand(SaveCommandHandler, CanExecuteSaveCommand); } }
        public ICommand NewCommand { get { return new RelayCommand(NewCommandHandler, CanExecuteNewCommand); } }
        public ICommand NewDialogCommand { get { return new RelayCommand(NewDialogCommandHandler, CanExecute); } }
        public ICommand DelCommand { get { return new RelayCommand(DeleteCommandHandler, CanExecuteDelCommand); } }
        public ICommand FilterCommand { get { return new RelayCommand(FilterCommandHandler, CanExecute); } }
        public ICommand FilterAllCommand { get { return new RelayCommand(FilterAllCommandHandler, CanExecute); } }
        public ICommand FilterAllPlusCommand { get { return new RelayCommand(FilterAllPlusCommandHandler, CanExecute); } }
       
        private bool CanExecuteSaveCommand() { return canExecuteSaveCommand; }
        private bool CanExecuteNewCommand() { return canExecuteNewCommand; }
        private bool CanExecuteDelCommand() { return canExecuteDelCommand; }
        private bool CanExecute() { return true; }

        public int NumRowRecord
        {
            get { return this.entitiesList.Count; }
        }

        private void SaveCommandHandler()
        {
            MessageBoxResult result = MessageBox.Show("Bạn muốn sửa thong tin phòng?", "Xác nhận sửa thông tin", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                this.SaveCurrentEntity();
            this.entitiesView.Refresh();
        }

        private void NewCommandHandler()
        {
            this.CloseNewEntityDialog();
            this.CurrentEntity = this.newEntityViewModel.NewEntity;
            this.entitiesList.Add(this.currentEntity);
            this.entitiesView.Refresh();
            this.entitiesView.MoveCurrentToLast();
            this.SaveCurrentEntity();
        }

        private void DeleteCommandHandler()
        {
            this.entitiesView.Refresh();
        }

        protected virtual void NewDialogCommandHandler() { }

        private void FilterCommandHandler()
        {
            this.filterIsCheck = true;
            this.entitiesView.Refresh();
        }

        private void FilterAllCommandHandler()
        {
            this.filterIsCheck = false;
            this.entitiesView.Refresh();
        }

        private void FilterAllPlusCommandHandler()
        {
            this.entitiesView.Refresh();
        }

    }
}
