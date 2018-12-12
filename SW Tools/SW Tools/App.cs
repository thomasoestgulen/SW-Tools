using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Windows.Media.Imaging;

namespace SW_Tools
{
    public class App : IExternalApplication
    {
        // define a method that will create our tab and button

        static void AddRibbonPanel(UIControlledApplication application)
        {
            // Create a custom ribbon tab
            String tabName = "SW Tools";
            application.CreateRibbonTab(tabName);

            // Add a new ribbon panel
            RibbonPanel ribbonPanel = application.CreateRibbonPanel(tabName, "Tools");

            // Get dll assembly path
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;

            // create push button for CurveTotalLength
            PushButtonData b1Data = new PushButtonData(
                "cmdFirstButton",
                "Total" + System.Environment.NewLine + "  Length  ", 
                thisAssemblyPath,
                "SW_Tools.FirstApp");

            PushButton pb1 = ribbonPanel.AddItem(b1Data) as PushButton;
            pb1.ToolTip = "This is the tooltip for the functin";
            BitmapImage pb1Image = new BitmapImage(new Uri("pack://application:,,,/SW Tools;component/Resources/iconStar.png"));
            pb1.LargeImage = pb1Image;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // do nothing
            // return result.succeeded
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // call our method that will load up our toolbar
            // return result.succeeded

        }
    }
}
