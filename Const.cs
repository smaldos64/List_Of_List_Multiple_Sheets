using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_List_Multiple_Sheets
{
    public enum MATRIX_COLUMN_OPERATION_ENUM
    {
        SEARCH_ALL_ROWS,
        SEARCH_CURRENT_ROW
    }

    public class Const
    {
        public const int NoRowsInSpreadSheet = -1;
        public const int NoColumnsInSpreadSheet = -1;
        public const int NoSheetInSpreadSheet = -1;

        public const int DefaulNumberOfRowsInSheet = 10;
        public const int DefaultNumberOfColumnsInSheet = 10;
    }
}
