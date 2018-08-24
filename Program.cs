using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_List_Multiple_Sheets
{
    class Program
    {
        public static int SheetNumber = Const.NoSheetInSpreadSheet;
        public static List<SpreadSheet> SpreadSheet_ObjectList = new List<SpreadSheet>();

        static void Main(string[] args)
        {
            MainMenu();
            ToolsInput.WaitForUser();
        }
        
        public static void PrintTopOfScreen(int SheetNumber)
        {
            ToolsScreen.ClearScreen();

            if (Const.NoSheetInSpreadSheet != SheetNumber)
            {
                ToolsOutput.PrintStringOnSeperateLine("Antal Sheet i Regneark       : " + HandleSpreadSheet.GetNumberOfSheetsInSpreadSheet());
                ToolsOutput.PrintStringOnSameLine("Sheet : ");
                for (int SheetCounter = 0; SheetCounter < HandleSpreadSheet.GetNumberOfSheetsInSpreadSheet(); SheetCounter++)
                {
                    ToolsOutput.PrintStringOnSameLine(SheetCounter + " (" + SpreadSheet_ObjectList[SheetCounter].SheetNameInSpreadSheet + ")");
                    if (SheetCounter < HandleSpreadSheet.GetNumberOfSheetsInSpreadSheet() - 1)
                    {
                        ToolsOutput.PrintStringOnSameLine(" - ");
                    }
                }
                ToolsOutput.PrintStringOnSeperateLine("");
                ToolsOutput.PrintStringOnSeperateLine("Aktiv Sheet nummer i Regneark       : " + SheetNumber);
                ToolsOutput.PrintStringOnSeperateLine("Antal rækker i Sheet " + SheetNumber + " : " + SpreadSheet_ObjectList[SheetNumber].GetNumberOfRowsInSpreadSheet());
                ToolsOutput.PrintStringOnSeperateLine("Max søjler i række i sheet " + SheetNumber + " : " + SpreadSheet_ObjectList[SheetNumber].GetMaxNumberOfColumnsInRows());
                ToolsOutput.PrintStringOnSeperateLine("---------------------------------");
                ToolsScreen.MakeEmptyLines(1);
            }
        }

        public static void MainMenu()
        {
            string[] StringList = { "1 : Håndter Points i Sheet i Regneark",
                                    "2 : Udskriv Points i Sheet i Regneark",
                                    "3 : Håndter Sheets i Regneark",
                                    "4 : Afslut program !!!"};

            int KeypressedValue = 0;
            HandleSpreadSheet.AddSheetToSpreadSheet(true);
            SheetNumber = HandleSpreadSheet.GetNumberOfSheetsInSpreadSheet() - 1;

            do
            {
                PrintTopOfScreen(SheetNumber);
                KeypressedValue = ToolsMenu.MakeMenu(StringList);

                switch (KeypressedValue)
                {
                    case 1:
                        PointMenu();
                        break;

                    case 2:
                        PrintMenu();
                        break;

                    case 3:
                        SheetMenu();
                        break;
                }
            } while (KeypressedValue < StringList.Length);
        }

        public static void PointMenu()
        {
            string[] StringList = { "1 : Slet Point i Sheet række-søjle i Regneark",
                                    "2 : Nulstil Point i Sheet række-søjle i Regneark",
                                    "3 : Indtast Point værdi før Sheet række-søjle i Regneark",
                                    "4 : Ret Point værdi i Sheet række-søjle i Regneark",
                                    "5 : Adder Point værdi i Sheet række-søjle i Regneark",
                                    "6 : Slet række i Sheet i Regneark",
                                    "7 : Slet søjle i Sheet i Regneark",
                                    "8 : Indsæt række i Sheet i Regneark",
                                    "9 : Indsæt søjle i Sheet i Regneark",
                                    "10 : Tilbage !!!"};

            int KeypressedValue = 0;

            do
            {
                PrintTopOfScreen(SheetNumber);
                KeypressedValue = ToolsMenu.MakeMenuMoreChars(StringList);

                switch (KeypressedValue)
                {
                    case 1:
                        HandleSpreadSheet.RemovePointFromSpredSheet();
                        break;

                    case 2:
                        HandleSpreadSheet.ResetPointFromSpreadSheet();
                        break;

                    case 3:
                        HandleSpreadSheet.InsertPointInSpreadSheet();
                        break;

                    case 4:
                        HandleSpreadSheet.ChangePointFromSpreadSheet();
                        break;

                    case 5:
                        HandleSpreadSheet.AddPointToRowInSpreadSheet();
                        break;

                    case 6:
                        HandleSpreadSheet.RemoveRowFromSpreadSheet();
                        break;

                    case 7:
                        HandleSpreadSheet.RemoveColumnFromSpreadSheet();
                        break;

                    case 8:
                        HandleSpreadSheet.AddRowToSpreadSheet();
                        break;

                    case 9:
                        HandleSpreadSheet.AddColumnToSpreadSheet();
                        break;
                }
            } while (KeypressedValue < StringList.Length);
        }

        public static void PrintMenu()
        {
            string[] StringList = { "1 : Vis punkter i række i Sheet i Regneark",
                                    "2 : Vis punkter i søjle i Sheet i Regneark",
                                    "3 : Via alle punkter i Sheet i Regneark",
                                    "4 : Tilbage !!!"};

            int KeypressedValue = 0;

            do
            {
                PrintTopOfScreen(SheetNumber);
                KeypressedValue = ToolsMenu.MakeMenu(StringList);

                switch (KeypressedValue)
                {
                    case 1:
                        HandleSpreadSheet.PrintPointsInSpreadSheetRow();
                        break;

                    case 2:
                        HandleSpreadSheet.PrintPointsInSpreadSheetColumn();
                        break;

                    case 3:
                        HandleSpreadSheet.PrintPointsInSpreadSheet();
                        break;
                }
            } while (KeypressedValue < StringList.Length);
        }

        public static void SheetMenu()
        {
            string[] StringList = { "1 : Adder Sheet til Regneark",
                                    "2 : Slet Sheet i Regneark",
                                    "3 : Omdøb Sheet Navn i Regneark",
                                    "4 : Vælg Sheet i Regneark",
                                    "5 : Tilbage !!!"};

            int KeypressedValue = 0;

            do
            {
                PrintTopOfScreen(SheetNumber);
                KeypressedValue = ToolsMenu.MakeMenu(StringList);

                switch (KeypressedValue)
                {
                    case 1:
                        HandleSpreadSheet.AddSheetToSpreadSheet();
                        break;

                    case 2:
                        HandleSpreadSheet.RemoveSheetFromSpreadSheet();
                        break;

                    case 3:
                        HandleSpreadSheet.RenameSheetNameInSpreadSheet();
                        break;
                }
            } while (KeypressedValue < StringList.Length);
        }
    }
}
