using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_List_Multiple_Sheets
{
    //public class SpreadSheetWithName
    //{
    //    Point ThisPoint;
    //    string SheetName;
    //}

    public class SpreadSheet
    {
        public List<List<Point>> SpreadSheetMatrix = new List<List<Point>>();
        public string SheetNameInSpreadSheet;

        #region CheckRow_Column
        public int GetNumberOfRowsInSpreadSheet()
        {
            return (SpreadSheetMatrix.Count);
        }

        public int GetNumberOfColumnsInSpreadSheet()
        {
            if (GetNumberOfRowsInSpreadSheet() > 0)
            {
                return (SpreadSheetMatrix[0].Count);
            }
            else
            {
                return (-1);
            }
        }

        private bool CheckSpreadSheetRow_Column_Index(int SpreadSheetRow, int SpreadSheetColumn)
        {
            bool IndexIsWithinRange = false;

            if (CheckSpreadSheetRow_Index(SpreadSheetRow))
            {
                if (CheckSpreadSheetColumn_Index_WithinRow(SpreadSheetRow, SpreadSheetColumn))
                {
                    IndexIsWithinRange = true;
                }
            }
            return (IndexIsWithinRange);
        }

        private bool CheckSpreadSheetRow_Index(int SpreadSheetRow)
        {
            bool IndexIsWithinRange = false;

            if (SpreadSheetRow < SpreadSheetMatrix.Count)
            {
                IndexIsWithinRange = true;
            }
            return (IndexIsWithinRange);
        }

        private bool CheckSpreadSheetColumn_Index_WithinRow(int SpreadSheetRow, int SpreadSheetColumn)
        {
            bool IndexIsWithinRange = false;

            if (SpreadSheetColumn < SpreadSheetMatrix[SpreadSheetRow].Count)
            {
                IndexIsWithinRange = true;
            }
            return (IndexIsWithinRange);
        }

        private bool CheckSpreadSheetColumnInAllRows(int SpreadSheetColumn)
        {
            bool IndexIsWithinRange = false;

            for (int SpreadSheetRowCounter = 0; SpreadSheetRowCounter < GetNumberOfRowsInSpreadSheet(); SpreadSheetRowCounter++)
            {
                if (CheckSpreadSheetColumn_Index_WithinRow(SpreadSheetRowCounter, SpreadSheetColumn))
                {
                    IndexIsWithinRange = true;
                }
            }
            return (IndexIsWithinRange);
        }
        #endregion

        #region AddToSpreadSheet
        public void AddRowToSpreadSheet(int RowNumber = -1)
        {
            if (-1 == RowNumber)
            {
                SpreadSheetMatrix.Add(new List<Point>());
            }
            else
            {
                SpreadSheetMatrix.Insert(RowNumber, new List<Point>());
            }
            
        }

        public void InsertRowInSpreadSheet(int RowNumber = -1)
        {
            if (-1 == RowNumber)
            {
                AddRowToSpreadSheet();

                for (int ColumnCounter = 0; ColumnCounter < GetMaxNumberOfColumnsInRows(); ColumnCounter++)
                {
                    AddColumnToSpreadSheet();
                }
            }
            else
            {
                AddRowToSpreadSheet(RowNumber);

                for (int ColumnCounter = 0; ColumnCounter < GetMaxNumberOfColumnsInRows(); ColumnCounter++)
                {
                    AddPointValueToSpreadSheetRow(RowNumber, Const.DefaultPointValue_Object);
                }
            }
        }

        public void AddColumnToSpreadSheet(int ColumnNumber = -1)
        {
            if (-1 == ColumnNumber)
            {
                for (int RowCounter = 0; RowCounter < GetNumberOfRowsInSpreadSheet(); RowCounter++)
                {
                    Point Point_Object = new Point();

                    SpreadSheetMatrix[RowCounter].Add(Point_Object);
                }
            }
            else
            {
                for (int RowCounter = 0; RowCounter < GetNumberOfRowsInSpreadSheet(); RowCounter++)
                {
                    Point Point_Object = new Point();

                    SpreadSheetMatrix[RowCounter].Insert(ColumnNumber, Point_Object);
                }
            }
        }

        public void AddColumnToSpreadSheetRow(int SpreadSheetRow)
        {
            Point Point_Object = new Point();

            if (CheckSpreadSheetRow_Index(SpreadSheetRow))
            {
                SpreadSheetMatrix[SpreadSheetRow].Add(Point_Object);
            }
        }
        
        public void AddPointValueToSpreadSheetRow_Column(int SpreadSheetRow, int SpreadSheetColumn, Point Point_Object)
        {
            if (CheckSpreadSheetRow_Column_Index(SpreadSheetRow, SpreadSheetColumn))
            {
                SpreadSheetMatrix[SpreadSheetRow][SpreadSheetColumn] = Point_Object;
            }
        }

        public void AddPointValueToSpreadSheetRow(int SpreadSheetRow, Point Point_Object)
        {
            if (CheckSpreadSheetRow_Index(SpreadSheetRow))
            {
                SpreadSheetMatrix[SpreadSheetRow].Add(Point_Object);
            }
        }
        #endregion

        #region RemoveFromSpreadSheet
        public void RemovePointFromSpreadSheet(int SpreadSheetRow, int SpreadSheetColumn)
        {
            if (CheckSpreadSheetRow_Column_Index(SpreadSheetRow, SpreadSheetColumn))
            {
                SpreadSheetMatrix[SpreadSheetRow].RemoveAt(SpreadSheetColumn);
            }
        }

        public void RemoveRowFromSpreadSheet(int SpreadSheetRow)
        {
            if (CheckSpreadSheetRow_Index(SpreadSheetRow))
            {
                SpreadSheetMatrix.RemoveAt(SpreadSheetRow);
            }
        }

        public void RemoveColumnFromSpreadSheet(int SpreadSheetColumn)
        {
            if (CheckSpreadSheetColumnInAllRows(SpreadSheetColumn))
            {
                for (int SpreadSheetRowCounter = 0; SpreadSheetRowCounter < GetNumberOfRowsInSpreadSheet(); SpreadSheetRowCounter++)
                {
                    if (CheckSpreadSheetColumn_Index_WithinRow(SpreadSheetRowCounter, SpreadSheetColumn))
                    {
                        SpreadSheetMatrix[SpreadSheetRowCounter].RemoveAt(SpreadSheetColumn);
                    }
                }
            }
        }
        #endregion

        #region GetValuesFromSpreadSheet
        public Point GetPointValueFromSpreadSheetRow_Column(int SpreadSheetRow, int SpreadSheetColumn)
        {
            if (CheckSpreadSheetRow_Column_Index(SpreadSheetRow, SpreadSheetColumn))
            {
                return (SpreadSheetMatrix[SpreadSheetRow][SpreadSheetColumn]);
            }
            else
            {
                Point Point_Object = new Point();
                return (Point_Object);
            }
        }

        public int GetNumberOfColumnsInSpreadSheetRow(int SpreadSheetRow)
        {
            if (SpreadSheetRow < SpreadSheetMatrix.Count)
            {
                return (SpreadSheetMatrix[SpreadSheetRow].Count);
            }
            else
            {
                return (0);
            }
        }

        public int GetMaxNumberOfColumnsInRows()
        {
            int MaxNumberOfColumnsInRow = 0;
            int NumberOfColumnsInCurrentRow = 0;

            for (int SpreadSheetRowCounter = 0; SpreadSheetRowCounter < GetNumberOfRowsInSpreadSheet(); SpreadSheetRowCounter++)
            {
                NumberOfColumnsInCurrentRow = GetNumberOfColumnsInSpreadSheetRow(SpreadSheetRowCounter);
                if (NumberOfColumnsInCurrentRow > MaxNumberOfColumnsInRow)
                {
                    MaxNumberOfColumnsInRow = NumberOfColumnsInCurrentRow;
                }
            }
            return (MaxNumberOfColumnsInRow);
        }
        #endregion

        #region ChangeValuesInSpreadSheet
        public void ResetPointFromSpreadSheet(int SpreadSheetRow, int SpreadSheetColumn)
        {
            if (CheckSpreadSheetRow_Column_Index(SpreadSheetRow, SpreadSheetColumn))
            {
                SpreadSheetMatrix[SpreadSheetRow][SpreadSheetColumn].XCoordinate = 0;
                SpreadSheetMatrix[SpreadSheetRow][SpreadSheetColumn].YCoordinate = 0;
            }
        }

        public void ChangePointInSpreadSheet(int SpreadSheetRow, int SpreadSheetColumn,
            double XCoordinate, double YCoordinate)
        {
            if (CheckSpreadSheetRow_Column_Index(SpreadSheetRow, SpreadSheetColumn))
            {
                SpreadSheetMatrix[SpreadSheetRow][SpreadSheetColumn].XCoordinate = XCoordinate;
                SpreadSheetMatrix[SpreadSheetRow][SpreadSheetColumn].YCoordinate = YCoordinate;
            }
        }
        #endregion

        #region PrintValuesInSpreadSheet
        public void PrintAllRows_Columns_WithinSpreadSheet()
        {
            ToolsScreen.MakeEmptyLines(1);
            for (int RowCounter = 0; RowCounter < SpreadSheetMatrix.Count; RowCounter++)
            {
                ToolsOutput.PrintStringOnSameLine("Række " + RowCounter + " : ");
                for (int ColumnCounter = 0; ColumnCounter < SpreadSheetMatrix[RowCounter].Count; ColumnCounter++)
                {
                    ToolsOutput.PrintPoint(SpreadSheetMatrix[RowCounter][ColumnCounter]);
                    ToolsOutput.PrintStringOnSameLine(" ");
                }
                ToolsScreen.MakeEmptyLines(1);
            }
        }

        public void PrintAllColumnsWithinSpreadSheetRow(int SpreadSheetRow)
        {
            ToolsScreen.MakeEmptyLines(1);
            for (int ColumnCounter = 0; ColumnCounter < SpreadSheetMatrix[SpreadSheetRow].Count; ColumnCounter++)
            {
                ToolsOutput.PrintPoint(SpreadSheetMatrix[SpreadSheetRow][ColumnCounter]);
                ToolsOutput.PrintStringOnSameLine(" ");
            }
            ToolsScreen.MakeEmptyLines(1);
        }

        public void PrintAllRowsWithinSpreadSheetColumn(int SpreadSheetColumn)
        {
            if (GetMaxNumberOfColumnsInRows() >= SpreadSheetColumn)
            {
                ToolsScreen.MakeEmptyLines(1);
                for (int RowCounter = 0; RowCounter < SpreadSheetMatrix.Count; RowCounter++)
                {
                    ToolsOutput.PrintStringOnSameLine("Række " + RowCounter + " : ");
                    if (SpreadSheetMatrix[RowCounter].Count > SpreadSheetColumn)
                    {
                        ToolsOutput.PrintPoint(SpreadSheetMatrix[RowCounter][SpreadSheetColumn]);
                    }
                    ToolsOutput.PrintStringOnSeperateLine("");
                }
                ToolsScreen.MakeEmptyLines(1);
            }
        }
        #endregion

        #region AddValuesInSpreadSheet
        public void AddAllColumnsWithinSpreadSheetRow(int SpreadSheetRow)
        {
            Point AddPoint_Object = new Point(Const.DefaultPointValue_Object.XCoordinate, Const.DefaultPointValue_Object.YCoordinate);
            ToolsScreen.MakeEmptyLines(1);
            for (int ColumnCounter = 0; ColumnCounter < SpreadSheetMatrix[SpreadSheetRow].Count; ColumnCounter++)
            {
                AddPoint_Object += SpreadSheetMatrix[SpreadSheetRow][ColumnCounter];
            }
            ToolsScreen.MakeEmptyLines(1);
            ToolsOutput.PrintStringOnSameLine("Summen af alle punkter i række " + SpreadSheetRow + " er : " + AddPoint_Object);
        }

        public void AddAllRowsWithinSpreadSheetColumn(int SpreadSheetColumn)
        {
            Point AddPoint_Object = new Point(Const.DefaultPointValue_Object.XCoordinate, Const.DefaultPointValue_Object.YCoordinate);
            ToolsScreen.MakeEmptyLines(1);
            for (int RowCounter = 0; RowCounter < SpreadSheetMatrix.Count; RowCounter++)
            {
                AddPoint_Object += SpreadSheetMatrix[RowCounter][SpreadSheetColumn];
            }
            ToolsScreen.MakeEmptyLines(1);
            ToolsOutput.PrintStringOnSameLine("Summen af alle punkter i søjle " + SpreadSheetColumn + " er : " + AddPoint_Object);
        }

        public void AddAllPointsWithinSheet()
        {
            Point AddPoint_Object = new Point(Const.DefaultPointValue_Object.XCoordinate, Const.DefaultPointValue_Object.YCoordinate);
            ToolsScreen.MakeEmptyLines(1);
            for (int RowCounter = 0; RowCounter < SpreadSheetMatrix.Count; RowCounter++)
            {
                for (int ColumnCounter = 0; ColumnCounter < GetMaxNumberOfColumnsInRows(); ColumnCounter++)
                {
                    AddPoint_Object += SpreadSheetMatrix[RowCounter][ColumnCounter];
                }
            }
            ToolsScreen.MakeEmptyLines(1);
            ToolsOutput.PrintStringOnSameLine("Summen af alle punkter i sheet " + Program.SheetNumber + " er : " + AddPoint_Object);
        }
        #endregion

        #region Static_Functions
        public static void AddRowsAndColumsToSheetInSpreadSheet(SpreadSheet SpreadSheet_Object)
        {
            for (int RowCounter = 0; RowCounter < Const.DefaulNumberOfRowsInSheet; RowCounter++)
            {
                SpreadSheet_Object.AddRowToSpreadSheet();
            }

            for (int ColumnCounter = 0; ColumnCounter < Const.DefaultNumberOfColumnsInSheet; ColumnCounter++)
            {
                SpreadSheet_Object.AddColumnToSpreadSheet();
            }
        }
        #endregion
    }
}
