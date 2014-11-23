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
        public enum ObjectState { 
            New,
            Existing,
            Deleted
        }

        private const string currentObjectStatePropertyName = "CurrentObjectState";
        private const string currentEntityPropertyName = "CurrentEntity";

        private ObjectState currentObjectState;
        private T currentEntity;
        private List<T> entitiesList;
        private ICollectionView entitiesView;
        private string _filterString;
        private bool _allSelected;
        private bool canExecuteSaveCommand = true;
        private bool canExecuteNewCommand = true;
        private bool canExecuteDelCommand = true;

        protected EditableViewModel()
            : base()
        {
            this.currentObjectState = ObjectState.Existing;
            this.currentEntity = default(T);
            this.entitiesList = this.GetEntitiesList();
            this.entitiesView = CollectionViewSource.GetDefaultView(this.entitiesList);
            this.entitiesView.CurrentChanged += EntitySelectionChanged;
            this.entitiesView.Filter += EntityFilter;
            this.canExecuteSaveCommand = false;
            this.canExecuteDelCommand = false;
        }

        protected abstract bool EntityFilter(object obj);

        private void EntitySelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("CHANGED...");
            // throw new NotImplementedException();
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

        protected abstract T BuildNewEntity();
        protected abstract List<T> GetEntitiesList();
        protected abstract void SaveCurrentEntity();
        protected abstract void SetCurrentEntity(T entity);

        public ObjectState CurrentObjectState
        {
            get { return this.currentObjectState; }
            set
            {
                if (this.currentObjectState != value)
                {
                    this.currentObjectState = value;
                    this.OnPropertyChanged(
                        EditableViewModel<T>.currentObjectStatePropertyName);
                }
            }
        }

        public T CurrentEntity
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
                    this.OnPropertyChanged(
                        EditableViewModel<T>.currentEntityPropertyName);
                }
                //Console.WriteLine("Number selected: " + GetNumSelected());
                this.canExecuteDelCommand = GetNumSelected() > 0;
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
        public ICommand NewCommand { get { return new RelayCommand(NewCommandHandler, CanExecuteNewCommand); } }
        public ICommand DelCommand { get { return new RelayCommand(DeleteCommandHandler, CanExecuteDelCommand); } }
       
        private bool CanExecuteSaveCommand() { return canExecuteSaveCommand; }
        private bool CanExecuteNewCommand() { return canExecuteSaveCommand; }
        private bool CanExecuteDelCommand() { return canExecuteSaveCommand; }

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
            this.CurrentObjectState = ObjectState.Existing;
        }

        private void NewCommandHandler()
        {
            this.CurrentObjectState = ObjectState.New;
            this.currentEntity = this.BuildNewEntity();
            this.entitiesList.Add(this.currentEntity);

            // this.entitiesList.Add(this.BuildNewEntity());
            // this.currentEntity = null;
            this.entitiesView.Refresh();
            this.entitiesView.MoveCurrentToLast();
            Console.WriteLine("New: " + this.currentEntity.ID);
        }

        private void DeleteCommandHandler()
        {
            this.entitiesView.Refresh();
        }

    }
}
