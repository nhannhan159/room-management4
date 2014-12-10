using RoomM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace RoomM.DeskApp.UIHelper
{
    public abstract class EditableViewModel<T> 
        : ViewModel where T : EntityBase
    {

        private const string currentEntityPropertyName = "CurrentEntity";

        private T currentEntity;
        private List<T> entitiesList;
        private ICollectionView entitiesView;
        private string _filterString;
        private bool _allSelected;
        protected bool canExecuteSaveCommand = true;
        protected bool canExecuteNewCommand = true;
        protected bool canExecuteDelCommand = true;

        protected EditableViewModel()
            : base()
        {
            this.currentEntity = default(T);
            this.entitiesList = this.GetEntitiesList();
            this.entitiesView = CollectionViewSource.GetDefaultView(this.entitiesList);
            this.entitiesView.CurrentChanged += EntitySelectionChanged;
            this.entitiesView.Filter += EntityFilter;
            this.canExecuteSaveCommand = false;
            this.canExecuteDelCommand = false;
        }

        protected abstract T BuildNewEntity();
        protected abstract List<T> GetEntitiesList();
        protected abstract void SaveCurrentEntity();
        protected abstract void SetCurrentEntity(T entity);
        protected abstract bool EntityFilter(object obj);

        public virtual T CurrentEntity
        {
            get { return this.currentEntity; }
            set
            {
                if (this.currentEntity != value)
                {
                    this.currentEntity = value;
                    this.SetCurrentEntity(value);
                    this.canExecuteSaveCommand = (this.currentEntity != null);
                    this.OnPropertyChanged(EditableViewModel<T>.currentEntityPropertyName);
                }
                this.canExecuteDelCommand = GetNumSelected() > 0;
            }
        }

        protected virtual void EntitySelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("CHANGED...");
        }

        public string Filter
        {
            get { return this._filterString; }
            set
            {
                this._filterString = value;
                OnPropertyChanged("Filter");
                this.entitiesView.Refresh();
            }
        }

        protected virtual int GetNumSelected() {
            return 0;
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
        public ICommand DelCommand { get { return new RelayCommand(DeleteCommandHandler, CanExecuteDelCommand); } }
       
        private bool CanExecuteSaveCommand() { return canExecuteSaveCommand; }
        protected bool CanExecuteNewCommand() { return canExecuteNewCommand; }
        private bool CanExecuteDelCommand() { return canExecuteDelCommand; }

        public int NumRowRecord
        {
            get
            {
                return this.entitiesList.Count;
            }

        }

        private void SaveCommandHandler()
        {
            this.SaveCurrentEntity();
        }

        protected void NewCommandHandler()
        {
            this.currentEntity = this.BuildNewEntity();
            this.SaveCurrentEntity();
            this.entitiesList.Add(this.currentEntity);
            this.entitiesView.Refresh();
            this.entitiesView.MoveCurrentToLast();
        }

        private void DeleteCommandHandler()
        {
            this.entitiesView.Refresh();
        }

    }
}
