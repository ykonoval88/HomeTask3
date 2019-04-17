using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;
namespace HomeTask3
{
    public static class CsvReader
    {
        public static List<string[]> Parse(string filePath)
        {
            List<string[]> table = new List<string[]>();
            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    //Processing row
                    string[] fields = parser.ReadFields();
                    table.Add(fields);
                }
            }

            return table;
        }
    }
}
