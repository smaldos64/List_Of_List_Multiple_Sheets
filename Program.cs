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
                ToolsOutput.PrintStringOnSameLine("Sheets : ");
                for (int SheetCounter = 0; SheetCounter < HandleSpreadSheet.GetNumberOfSheetsInSpreadSheet(); SheetCounter++)
                {
                    ToolsOutput.PrintStringOnSameLine(SheetCounter + " (" + SpreadSheet_ObjectList[SheetCounter].SheetNameInSpreadSheet + ")");
                    if (SheetCounter < HandleSpreadSheet.GetNumberOfSheetsInSpreadSheet() - 1)
                    {
                        ToolsOutput.PrintStringOnSameLine(" - ");
                    }
                }
                ToolsOutput.PrintStringOnSeperateLine("");
                ToolsOutput.PrintStringOnSeperateLine("Aktiv Sheet i Regneark       : " + SheetNumber + " (" + SpreadSheet_ObjectList[SheetNumber].SheetNameInSpreadSheet + ")");
                ToolsOutput.PrintStringOnSeperateLine("Antal rækker i Sheet " + SheetNumber + " : " + SpreadSheet_ObjectList[SheetNumber].GetNumberOfRowsInSpreadSheet());
                ToolsOutput.PrintStringOnSeperateLine("Max søjler i række i sheet " + SheetNumber + " : " + SpreadSheet_ObjectList[SheetNumber].GetMaxNumberOfColumnsInRows());
                ToolsOutput.PrintStringOnSeperateLine("---------------------------------");
                ToolsScreen.MakeEmptyLines(1);
            }
        }

        public static void MainMenu()
        {
            string[] StringList = { "1 : Håndter Points i Sheet i Regneark",
                                    "2 : Beregninger på Points i Sheet i Regneark",
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
                        CalculateMenu();
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
                                    "3 : Ret Point værdi i Sheet række-søjle i Regneark",
                                    "4 : Slet række i Sheet i Regneark",
                                    "5 : Slet søjle i Sheet i Regneark",
                                    "6 : Indsæt række i Sheet i Regneark",
                                    "7 : Indsæt søjle i Sheet i Regneark",
                                    "8 : Tilbage !!!"};

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
                        HandleSpreadSheet.ChangePointFromSpreadSheet();
                        break;

                   case 4:
                        HandleSpreadSheet.RemoveRowFromSpreadSheet();
                        break;

                    case 5:
                        HandleSpreadSheet.RemoveColumnFromSpreadSheet();
                        break;

                    case 6:
                        HandleSpreadSheet.AddRowToSpreadSheet();
                        break;

                    case 7:
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

                    case 4:
                        SheetNumber = HandleSpreadSheet.SelectSheetInSpreadSheet();
                        break;
                }
            } while (KeypressedValue < StringList.Length);
        }

        public static void CalculateMenu()
        {
            string[] StringList = { "1 : Adder punkter i Række",
                                    "2 : Adder punkter i Kolonne",
                                    "3 : Adder alle punkter i Sheet i Regneark",
                                    "4 : Tilbage !!!"};

            int KeypressedValue = 0;

            do
            {
                PrintTopOfScreen(SheetNumber);
                KeypressedValue = ToolsMenu.MakeMenu(StringList);

                switch (KeypressedValue)
                {
                    case 1:
                        HandleSpreadSheet.AddPointsInRow();
                        break;

                    case 2:
                        HandleSpreadSheet.AddPointsInColumn();
                        break;

                    case 3:
                        HandleSpreadSheet.AddPointsInSheet();
                        break;
                }
            } while (KeypressedValue < StringList.Length);
        }
    }
}
