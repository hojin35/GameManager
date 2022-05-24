using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Core;

namespace WpfApp2.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand RealTimeViewCommand { get; set; }
        public RelayCommand RecordViewCommand { get; set; }
        public RelayCommand DrawTeamViewcommand { get; set; }
        public RecordViewModel RecordVM { get; set; }
        public RealTimeViewModel RealTimeVM { get; set; }
        public DrawTeamViewModel DrawTeamVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            RecordVM = new RecordViewModel();
            RealTimeVM = new RealTimeViewModel();
            DrawTeamVM = new DrawTeamViewModel();
            CurrentView = RealTimeVM;

            RecordViewCommand = new RelayCommand(o =>
            {
                CurrentView = RecordVM;
            });

            RealTimeViewCommand = new RelayCommand(o =>
            {
                CurrentView = RealTimeVM;
            });

            DrawTeamViewcommand = new RelayCommand(o =>
            {
                CurrentView = DrawTeamVM;
            });
        }
    }
}
