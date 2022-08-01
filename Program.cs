using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the specific Individual id or Family Id or Notes Id wants to search from the Genealogical file");
            Console.WriteLine();
            Console.WriteLine("Example.....");
            Console.WriteLine();
            Console.WriteLine("For Individual Id From I0001 to I0263");
            Console.WriteLine();
            Console.WriteLine("For Family Id From  F0001 to F0124");
            Console.WriteLine();
            Console.WriteLine("For Note Id From N0001 to N0137");
            Console.WriteLine();
            Console.WriteLine("For Source Id S0001");
            Console.WriteLine();
            Console.WriteLine("Leave blank to get all the information");
            Console.WriteLine();
            Console.WriteLine("Press Enter key to continue after entering the Id value....");
            Console.WriteLine();
            string idFilter = Console.ReadLine();            
            string import_ged = @"E:\GitHub\GedcomGenerator\Input\Genealogical_data.txt";
            string export_xml = "output.xml";           
            GEDCOMtoXML.Converter.ConvertXML(import_ged, export_xml, idFilter);
        }
    }
}
