using System;
using System.Runtime.InteropServices;
using Application = Microsoft.Office.Interop.Word.Application;

namespace Services.LogicHandlers.Helpers
{
    public static class Dispatcher
    {
        public static void DisposeOfWordInstance(Application instance)
        {
            instance.DisplayAlerts = Microsoft.Office.Interop.Word.WdAlertLevel.wdAlertsNone;
            instance.Visible = false;
            instance.Quit();
            //Marshal.FinalReleaseComObject(instance);
            GC.Collect();
        }
    }
}
