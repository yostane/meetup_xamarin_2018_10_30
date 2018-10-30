using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using SharpTrooper.Entities;
using SharpTrooper.Core;
using System.Windows.Input;
using Xamarin.Forms;
using RandomListXamarin.ViewModels;

namespace MonStarWars.ViewModels
{

    public class SWViewModel : BaseViewModel
    {
        public ObservableCollection<People> People { get; set; } = new ObservableCollection<People>();
        SharpTrooperCore sharpTrooperCore = new SharpTrooperCore();

        private ICommand _AddPageCommand = null;
        public ICommand AddPageCommand
        {
            get
            {
                return _AddPageCommand ?? (_AddPageCommand = new Command(ExecuteAddPageCommand));
            }
        }

        string nextPage = "1";
        private bool _HasMorePages = true;
        public bool HasMorePages
        {
            get => _HasMorePages;
            set
            {
                SetProperty(ref _HasMorePages, value);
            }
        }
        void ExecuteAddPageCommand()
        {
            if (!HasMorePages)
            {
                return;
            }
            var peopleResponse = sharpTrooperCore.GetAllPeople(nextPage);
            nextPage = peopleResponse.nextPageNo;
            HasMorePages = nextPage != null;
            peopleResponse.results.ForEach(person => People.Add(person));
        }

        public SWViewModel()
        {
            ExecuteAddPageCommand();
        }
    }
}
