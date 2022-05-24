using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Core;

namespace WpfApp2.MVVM.ViewModel
{
    class DrawTeamViewModel : ObservableObject
    {
        public RelayCommand DrawTeamCommand { get; set; }

        private int numOfTeam;

        public int NumOfTeam
        {
            get { return numOfTeam; }
            set
            {
                numOfTeam = value;
                OnPropertyChanged("NumOfTeam");
            }
        }

        private int numOfMembers;

        public int NumOfMembers
        {
            get { return numOfMembers; }
            set
            {
                numOfMembers = value;
                OnPropertyChanged("NumOfMembers");
            }
        }
        private DataTable _resultDT = null;
        public DataTable ResultDataTable
        {
            get { return _resultDT; }
            set
            {
                _resultDT = value;
                OnPropertyChanged("ResultDataTable");
            }
        }

        public DrawTeamViewModel()
        {
            DrawTeamCommand = new RelayCommand(o =>
            {
                DataTable dt = new DataTable();
                for (int i = 0; i < numOfTeam; i++)
                {
                    dt.Columns.Add(i + 1 + "팀", typeof(int));
                }
                int[,] _teamResult = new int[numOfTeam, numOfMembers];
                //TODO : Make Funtion input Data
                MakeTeamDataTable(ref _teamResult);
                
                for (int i = 0; i < numOfMembers; i++)
                {
                    var row = dt.NewRow();
                    for (int j = 0; j < NumOfTeam; j++)
                    {
                        row[j] = _teamResult[j,i]; 
                    }
                    dt.Rows.Add(row);
                }
                ResultDataTable = dt;
            });
        }

        private void MakeTeamDataTable(ref int[,] teamResult)
        {
            Random random = new Random();
            int[] teamNumbering = new int[numOfTeam];
            for (int i = 1; i <= numOfTeam * NumOfMembers; i++)
            {
                int team = random.Next(numOfTeam);
                if (teamNumbering[team] >= NumOfMembers)
                {
                    i--;
                    continue;
                }
                teamResult[team, teamNumbering[team]] = i;
                teamNumbering[team]++;
            }
        }
    }

}
