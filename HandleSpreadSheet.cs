using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_List_Multiple_Sheets
{
    public class HandleSpreadSheet
    {
        public static int GetNumberOfSheetsInSpreadSheet()
        {
            return (Program.SpreadSheet_ObjectList.Count);
        }

        public static bool IsThereAnySheetsInSpreadSheet()
        {
            return (GetNumberOfSheetsInSpreadSheet() > 0);
        }

        public static void AddRowToSpreadSheet()
        {
            if (IsThereAnySheetsInSpreadSheet())
            {
                int CurrentRowNumber;

                CurrentRowNumber = GetSpreadSheetRowNumber("Indtast række nummer der skal have række indsat før  (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet() - 1) + ") : ");
                if (CurrentRowNumber >= 0)
                {
                    Program.SpreadSheet_ObjectList[Program.SheetNumber].InsertRowInSpreadSheet(CurrentRowNumber);
                }
            }
        }

        public static void AddColumnToSpreadSheet()
        {
            if (IsThereAnySheetsInSpreadSheet())
            {
                int CurrentColumnNumber;

                CurrentColumnNumber = GetSpreadSheetColumnNumber("Indtast søjle nummer der skal have søjle indsat før (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetMaxNumberOfColumnsInRows() - 1) + ") : ");
                if (CurrentColumnNumber >= 0)
                {

                    Program.SpreadSheet_ObjectList[Program.SheetNumber].AddColumnToSpreadSheet(CurrentColumnNumber);
                }
            }
        }

        private static int GetSpreadSheet_SheetNumber(string InputString)
        {
            int NumberOfSheetsInSpreadSheet = GetNumberOfSheetsInSpreadSheet();
            int CurrentSheetNumber = 0;

            if (NumberOfSheetsInSpreadSheet > 0)
            {
                ToolsScreen.MakeEmptyLines(2);
                do
                {
                    ToolsInput.GetUserInput(out CurrentSheetNumber, InputString);
                    if (!((CurrentSheetNumber >= 0) && (CurrentSheetNumber < NumberOfSheetsInSpreadSheet)))
                    {
                        ToolsScreen.ClearLine();
                    }
                } while (!((CurrentSheetNumber >= 0) && (CurrentSheetNumber < NumberOfSheetsInSpreadSheet)));
            }
            else
            {
                CurrentSheetNumber = Const.NoSheetInSpreadSheet;
            }

            return (CurrentSheetNumber);
        }

        private static int GetSpreadSheetRowNumber(string InputString)
        {
            int NumberOfRowsInSpreadSheet = Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet();
            int CurrentRowNumber = 0;

            if (NumberOfRowsInSpreadSheet > 0)
            {
                ToolsScreen.MakeEmptyLines(1);
                do
                {
                    ToolsInput.GetUserInput(out CurrentRowNumber, InputString);
                    if (!((CurrentRowNumber >= 0) && (CurrentRowNumber < NumberOfRowsInSpreadSheet)))
                    {
                        ToolsScreen.ClearLine();
                    }
                } while (!((CurrentRowNumber >= 0) && (CurrentRowNumber < NumberOfRowsInSpreadSheet)));
            }
            else
            {
                CurrentRowNumber = Const.NoRowsInSpreadSheet;
            }

            return (CurrentRowNumber);
        }

        private static int GetSpreadSheetColumnNumber(string InputString)
        {
            int CurrentColumnNumber;

            ToolsScreen.MakeEmptyLines(1);
            do
            {
                ToolsInput.GetUserInput(out CurrentColumnNumber, InputString);
                if (!((CurrentColumnNumber >= 0) && (CurrentColumnNumber < Program.SpreadSheet_ObjectList[Program.SheetNumber].GetMaxNumberOfColumnsInRows())))
                {
                    ToolsScreen.ClearLine();
                }
            } while (!((CurrentColumnNumber >= 0) && (CurrentColumnNumber < Program.SpreadSheet_ObjectList[Program.SheetNumber].GetMaxNumberOfColumnsInRows())));

            return (CurrentColumnNumber);
        }
        
        public static void AddPointToRowInSpreadSheet()
        {
            int CurrentRowNumber;

            CurrentRowNumber = GetSpreadSheetRowNumber("Indtast række nummer der skal have punkt adderet  (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet() - 1) + ") : ");
            if (CurrentRowNumber >= 0)
            {
                ToolsScreen.MakeEmptyLines(1);
                double XCoordinate = 0;
                double YCoordinate = 0;

                ToolsInput.GetUserInput(out XCoordinate, "Indtast punktets x-koordinat : ");
                ToolsInput.GetUserInput(out YCoordinate, "Indtast punktets y-koordinat : ");

                Point Point_Object = new Point(XCoordinate, YCoordinate);
                Program.SpreadSheet_ObjectList[Program.SheetNumber].AddPointValueToSpreadSheetRow(CurrentRowNumber, Point_Object);

                ToolsInput.WaitForUser();
            }
        }

        public static void GetRowAndColumnNumber(ref int RowNumber, ref int ColumnNumber, string RowText, string ColumnText)
        {
            RowNumber = -1;
            ColumnNumber = -1;

            RowNumber = GetSpreadSheetRowNumber(RowText);
            if (RowNumber >= 0)
            {
                ColumnNumber = GetSpreadSheetColumnNumber(ColumnText);
            }
        }

        public static void RemovePointFromSpredSheet()
        {
            int CurrentRowNumber = -1;
            int CurrentColumnNumber = -1;

            GetRowAndColumnNumber(ref CurrentRowNumber, ref CurrentColumnNumber,
                "Indtast række nummer der skal have punkt slettet  (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet() - 1) + ") : ",
                "Indtast søjle nummer der skal punkt slettet (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfColumnsInSpreadSheet() - 1) + ") : ");

            if ((CurrentRowNumber >= 0) && (CurrentColumnNumber >= 0))
            {
                Program.SpreadSheet_ObjectList[Program.SheetNumber].RemovePointFromSpreadSheet(CurrentRowNumber, CurrentColumnNumber);

                Program.SpreadSheet_ObjectList[Program.SheetNumber].AddPointValueToSpreadSheetRow(CurrentRowNumber, Const.DefaultPointValue_Object);
            }
        }

        public static void ResetPointFromSpreadSheet()
        {
            int CurrentRowNumber = -1;
            int CurrentColumnNumber = -1;

            GetRowAndColumnNumber(ref CurrentRowNumber, ref CurrentColumnNumber,
                "Indtast række nummer der skal have punkt nulstillet  (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet() - 1) + ") : ",
                "Indtast søjle nummer der skal punkt nulstillet (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfColumnsInSpreadSheet() - 1) + ") : ");

            if ((CurrentRowNumber >= 0) && (CurrentColumnNumber >= 0))
            {
                Program.SpreadSheet_ObjectList[Program.SheetNumber].ResetPointFromSpreadSheet(CurrentRowNumber, CurrentColumnNumber);
            }
        }

        public static void InsertPointInSpreadSheet()
        {
        }

        public static void ChangePointFromSpreadSheet()
        {
            int CurrentRowNumber = -1;
            int CurrentColumnNumber = -1;

            GetRowAndColumnNumber(ref CurrentRowNumber, ref CurrentColumnNumber,
                "Indtast række nummer der skal have punkt ændret  (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet() - 1) + ") : ",
                "Indtast søjle nummer der skal punkt ændret (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfColumnsInSpreadSheet() -1) + ") : ");

            if ((CurrentRowNumber >= 0) && (CurrentColumnNumber >= 0))
            {
                ToolsScreen.MakeEmptyLines(1);
                double XCoordinate = 0;
                double YCoordinate = 0;

                ToolsInput.GetUserInput(out XCoordinate, "Indtast punktets nye x-koordinat : ");
                ToolsInput.GetUserInput(out YCoordinate, "Indtast punktets nye y-koordinat : ");

                Program.SpreadSheet_ObjectList[Program.SheetNumber].ChangePointInSpreadSheet(CurrentRowNumber, CurrentColumnNumber,
                    XCoordinate, YCoordinate);
            }
        }

        public static void RemoveRowFromSpreadSheet()
        {
            int CurrentRowNumber;

            CurrentRowNumber = GetSpreadSheetRowNumber("Indtast række nummer der skal have punkt slettet  (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet() - 1) + ") : ");
            if (CurrentRowNumber >= 0)
            {
                Program.SpreadSheet_ObjectList[Program.SheetNumber].RemoveRowFromSpreadSheet(CurrentRowNumber);
            }
        }

        public static void RemoveColumnFromSpreadSheet()
        {
            int CurrentColumnNumber;

            CurrentColumnNumber = GetSpreadSheetColumnNumber("Indtast søjle nummer der skal slettes (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetMaxNumberOfColumnsInRows() - 1) + ") : ");
            if (CurrentColumnNumber >= 0)
            {
                Program.SpreadSheet_ObjectList[Program.SheetNumber].RemoveColumnFromSpreadSheet(CurrentColumnNumber);
            }
        }

        public static void PrintPointsInSpreadSheetRow()
        {
            int CurrentRowNumber;
         
            CurrentRowNumber = GetSpreadSheetRowNumber("Indtast række nummer der skal udskrives (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet() - 1) + ") : ");
            if (CurrentRowNumber >= 0)
            {
                Program.SpreadSheet_ObjectList[Program.SheetNumber].PrintAllColumnsWithinSpreadSheetRow(CurrentRowNumber);
                ToolsInput.WaitForUser();
            }
        }

        public static void PrintPointsInSpreadSheetColumn()
        {
            int CurrentColumnNumber;

            CurrentColumnNumber = GetSpreadSheetColumnNumber("Indtast søjle nummer der skal udskrives (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetMaxNumberOfColumnsInRows() - 1) + ") : ");
            if (CurrentColumnNumber >= 0)
            {
                Program.SpreadSheet_ObjectList[Program.SheetNumber].PrintAllRowsWithinSpreadSheetColumn(CurrentColumnNumber);
                ToolsInput.WaitForUser();
            }
        }

        public static void PrintPointsInSpreadSheet(bool WaitForKeypress = false)
        {
            Program.SpreadSheet_ObjectList[Program.SheetNumber].PrintAllRows_Columns_WithinSpreadSheet();
            if (true == WaitForKeypress)
            {
                ToolsInput.WaitForUser();
            }
            ToolsScreen.MakeEmptyLines(1);
        }

        public static void AddSheetToSpreadSheet(bool init = false)
        {
            SpreadSheet SpreadSheetObject = new SpreadSheet();

            Program.SpreadSheet_ObjectList.Add(SpreadSheetObject);
            SpreadSheet.AddRowsAndColumsToSheetInSpreadSheet(SpreadSheetObject);
            
            if (!init)
            {
                ToolsScreen.MakeEmptyLines(2);
                ToolsInput.GetUserInput(out Program.SpreadSheet_ObjectList[Program.SpreadSheet_ObjectList.Count - 1].SheetNameInSpreadSheet, "Indtast ønsket navn for Sheet " + (Program.SpreadSheet_ObjectList.Count - 1) + " : ");
            }
            else
            {
                Program.SpreadSheet_ObjectList[Program.SpreadSheet_ObjectList.Count - 1].SheetNameInSpreadSheet = Const.DefaultNameForFirstSheet;
            }
        }

        public static void RemoveSheetFromSpreadSheet()
        {
            int CurrentSheetNumber;

            CurrentSheetNumber = GetSpreadSheet_SheetNumber("Indtast Sheet nummer der skal slettes  (0 - " + (GetNumberOfSheetsInSpreadSheet() - 1) + ") : ");
            if (CurrentSheetNumber >= 0)
            {
                Program.SpreadSheet_ObjectList.RemoveAt(CurrentSheetNumber);
            }
        }

        public static void RenameSheetNameInSpreadSheet()
        {
            ToolsScreen.MakeEmptyLines(2);
            ToolsInput.GetUserInput(out Program.SpreadSheet_ObjectList[Program.SheetNumber].SheetNameInSpreadSheet, "Indtast nyt ønsket navn for nuværende Sheet => " + Program.SheetNumber + " (" + Program.SpreadSheet_ObjectList[Program.SheetNumber].SheetNameInSpreadSheet + ") : ");
        }

        public static int SelectSheetInSpreadSheet()
        {
            int CurrentSheetNumber;
            
            CurrentSheetNumber = GetSpreadSheet_SheetNumber("Indtast Sheet nummer der skal arbejdes på (0 - " + (GetNumberOfSheetsInSpreadSheet() - 1) + ") : ");
            
            return (CurrentSheetNumber);
        }

        public static void AddPointsInRow()
        {
            int CurrentRowNumber;
            
            CurrentRowNumber = GetSpreadSheetRowNumber("Indtast række nummer der skal have punkter adderet (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetNumberOfRowsInSpreadSheet() - 1) + ") : ");
            if (CurrentRowNumber >= 0)
            {
                Program.SpreadSheet_ObjectList[Program.SheetNumber].AddAllColumnsWithinSpreadSheetRow(CurrentRowNumber);
                ToolsInput.WaitForUser();
            }
        }

        public static void AddPointsInColumn()
        {
            int CurrentColumnNumber;

            CurrentColumnNumber = GetSpreadSheetColumnNumber("Indtast søjle nummer der skal udskrives (0 - " + (Program.SpreadSheet_ObjectList[Program.SheetNumber].GetMaxNumberOfColumnsInRows() - 1) + ") : ");
            if (CurrentColumnNumber >= 0)
            {
                Program.SpreadSheet_ObjectList[Program.SheetNumber].AddAllRowsWithinSpreadSheetColumn(CurrentColumnNumber);
                ToolsInput.WaitForUser();
            }
        }

        public static void AddPointsInSheet()
        {
            Program.SpreadSheet_ObjectList[Program.SheetNumber].AddAllPointsWithinSheet();
            ToolsInput.WaitForUser();
        }
    }
}
