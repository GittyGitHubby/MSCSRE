using System;
using System.Windows.Forms;

namespace PluginClass
{
    public class Class1
    {
        const string menuHeader = "-&OOP Metrics";
        const string menuPbCR = "&Public Class Metrics";
        const string menuPrCR = "&Private Class Metrics";
        const string menuInterfaceCount = "&Interface Count";
        const string menuStaticInterfaceOperations = "&Static Interface Operations";
        const string menuNonStaticInterfaceOperations = "&Non-Static Interface Operations";
        const string menuTotalOperationCount = "&Total Operation Count";
        const string menuPrivateOperationCount = "&Private Operation Count";
        const string menuPublicOperationCount = "&Public Operation Count";
        const string menuDistinctBackColorCount = "&Distinct BackColor Count";
        const string menuDistinctAuthorCount = "&Distinct Author Count";

        private bool shouldWeSayHello = true;

        public String EA_Connect(EA.Repository Repository)
        {
            // No special processing required.
            return "a string";
        }

        public object EA_GetMenuItems(EA.Repository Repository, string Location, string MenuName)
        {
            switch (MenuName)
            {
                case "":
                    return menuHeader;
                case menuHeader:
                    string[] subMenus = { menuPbCR, menuPrCR, menuInterfaceCount, menuStaticInterfaceOperations, menuNonStaticInterfaceOperations,
                        menuTotalOperationCount, menuPrivateOperationCount, menuPublicOperationCount, menuDistinctBackColorCount, menuDistinctAuthorCount };
                    return subMenus;
            }
            return "";
        }

        bool IsProjectOpen(EA.Repository Repository)
        {
            try
            {
                EA.Collection c = Repository.Models;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void EA_GetMenuState(EA.Repository Repository, string Location, string MenuName, string ItemName, ref bool IsEnabled, ref bool IsChecked)
        {
            if (IsProjectOpen(Repository))
            {
                switch (ItemName)
                {
                    case menuPbCR:
                    case menuPrCR:
                    case menuInterfaceCount:
                    case menuStaticInterfaceOperations:
                    case menuNonStaticInterfaceOperations:
                    case menuTotalOperationCount:
                    case menuPrivateOperationCount:
                    case menuPublicOperationCount:
                    case menuDistinctBackColorCount:
                    case menuDistinctAuthorCount:
                        IsEnabled = true;
                        break;
                    default:
                        IsEnabled = false;
                        break;
                }
            }
            else
            {
                IsEnabled = false;
            }
        }

        public void EA_MenuClick(EA.Repository Repository, string Location, string MenuName, string ItemName)
        {
            switch (ItemName)
            {
                case menuPbCR:
                    this.PbCR(Repository);
                    break;
                    // Add cases for other menu options
            }
        }

        private void PbCR(EA.Repository Repository)
        {
            // Add logic for menuPbCR (Public Class Metrics)
            // Use the provided SQL query for public class metrics
        }

        // Implement methods for other menu options similarly

        public void EA_Disconnect()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
