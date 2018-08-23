using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_List_Multiple_Sheets
{
    public class SpreadSheet
    {
        public List<List<Point>> SpreadSheetMatrix = new List<List<Point>>();

        #region CheckRow_Column
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
        public void AddRowToSpreadSheet()
        {
            SpreadSheetMatrix.Add(new List<Point>());
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

        public int GetNumberOfRowsInSpreadSheet()
        {
            return (SpreadSheetMatrix.Count);
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

    }
}
