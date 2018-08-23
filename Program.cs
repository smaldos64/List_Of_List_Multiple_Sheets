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
                ToolsOutput.PrintStringOnSeperateLine("Sheet nummer i Regneark       : " + SheetNumber);
                ToolsOutput.PrintStringOnSeperateLine("Antal rækker i Sheet " + SheetNumber + " : " + SpreadSheet_ObjectList[SheetNumber].GetNumberOfRowsInSpreadSheet());
                ToolsOutput.PrintStringOnSeperateLine("Max søjler i række i sheet " + SheetNumber + " : " + SpreadSheet_ObjectList[SheetNumber].GetMaxNumberOfColumnsInRows());
                ToolsOutput.PrintStringOnSeperateLine("---------------------------------");
                ToolsScreen.MakeEmptyLines(1);
            }
        }

        public static void MainMenu()
        {
            string[] StringList = { "1 : Adder række til Regneark",
                                    "2 : Adder punkt til række-søjle",
                                    "3 : Vis punkter i række",
                                    "4 : Vis punkter i søjle",
                                    "5 : Via alle punkter i regneark",
                                    "6 : Fjern punkt fra regneark",
                                    "7 : Adder Sheet til regneark",
                                    "8 : Vis Sheet i regneark",
                                    "9 : Afslut program !!!"};

            int KeypressedValue = 0;
            HandleSpreadSheet.AddSheetToSpreadSheet();
            SheetNumber = HandleSpreadSheet.GetNumberOfSheetsInSpreadSheet() - 1;

            do
            {
                PrintTopOfScreen(SheetNumber);
                KeypressedValue = ToolsMenu.MakeMenu(StringList);

                switch (KeypressedValue)
                {
                    case 1:
                        HandleSpreadSheet.AddRowToSpreadSheet();
                        break;

                    case 2:
                        HandleSpreadSheet.AddPointToRowInSpreadSheet();
                        break;

                    case 3:
                        HandleSpreadSheet.PrintPointsInSpreadSheetRow();
                        break;

                    case 4:
                        HandleSpreadSheet.PrintPointsInSpreadSheetColumn();
                        break;

                    case 5:
                        HandleSpreadSheet.PrintPointsInSpreadSheet();
                        break;

                    case 6:
                        HandleSpreadSheet.RemovePointFromSpredSheet();
                        break;

                    case 7:
                        HandleSpreadSheet.AddSheetToSpreadSheet();
                        break;

                    case 8:
                        SheetNumber = HandleSpreadSheet.SelectSheetInSpreadSheet();
                        break;
                }
            } while (KeypressedValue < StringList.Length);
        }
    }
}
