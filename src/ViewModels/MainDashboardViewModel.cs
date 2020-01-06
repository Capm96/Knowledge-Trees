using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class MainDashboardViewModel
    {
        public MainDashboardViewModel()
        {

        }

        public ObservableCollection<string> Trees { get; set; }
        public ObservableCollection<string> Leaves { get; set; }

        internal void OpenCreateNewTreeWindow()
        {
            throw new NotImplementedException();
        }
    }
}
