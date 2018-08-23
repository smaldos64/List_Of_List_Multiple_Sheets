using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Of_List_Multiple_Sheets
{
    public class ToolsOutput
    {
        public static void PrintStringOnSeperateLine(string StringToPrint)
        {
            Console.WriteLine(StringToPrint);
        }

        public static void PrintStringOnSameLine(string StringToPrint)
        {
            Console.Write(StringToPrint);
        }

        public static void PrintPoint(Point Point_Object)
        {
            Console.Write(Point_Object);
        }
    }
}
