using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Views.WindowFactory
{
    // TODO: MAKE THIS AS INTERFACE. INJECT ONTO VIEWMODELS.
    public class WindowFactory
    {
        public void OpenMainDashboard()
        {
            var mainDashboard = new MainDashboard();
            mainDashboard.DataContext = new MainDashboardViewModel();
            mainDashboard.Show();
        }

        public void OpenCreateNewTreeWindow()
        {
            var createNewTreeDashboard = new CreateNewTreeView();
            createNewTreeDashboard.DataContext = new CreateNewTreeViewModel();
            createNewTreeDashboard.Show();
        }
    }
}
