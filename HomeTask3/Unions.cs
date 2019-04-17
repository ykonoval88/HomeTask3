using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeTask3.Entity;

namespace HomeTask3
{
    public static class Unions
    {
        public static Barcelona1[] UnionAll(Barcelona1[] table1, Barcelona1[] table2)
        {
            Barcelona1[] result = new Barcelona1[table1.Length + table2.Length];

            int table1Pos = 0;
            int table2Pos = 0;
            for (int position = 0; position < result.Length; position++)
            {

                if (table1Pos > table1.Length - 1)
                {
                    result[position] = table2[table2Pos];
                    table2Pos++;
                }
                else if (table2Pos > table2.Length - 1)
                {
                    result[position] = table1[table1Pos];
                    table1Pos++;
                }
                else if (table1[table1Pos] < table2[table2Pos])
                {
                    result[position] = table1[table1Pos];
                    table1Pos++;
                }
                else
                {
                    result[position] = table2[table2Pos];
                    table2Pos++;
                }
            }

            return result;
        }

        public static Barcelona1[] Union(Barcelona1[] table1, Barcelona1[] table2)
        {
            List<Barcelona1> result = new List<Barcelona1>();
            int totalLength = table1.Length + table2.Length;

            int table1Pos = 0;
            int table2Pos = 0;
            for (int position = 0; position < totalLength && table1Pos+table2Pos < totalLength; position++)
            {
                if (table1Pos > table1.Length - 1)
                {
                    result.Add(table2[table2Pos]);
                    table2Pos++;
                }
                else if (table2Pos > table2.Length - 1)
                {
                    result.Add(table1[table1Pos]);
                    table1Pos++;
                }
                else if (table1[table1Pos] < table2[table2Pos])
                {
                    result.Add(table1[table1Pos]);
                    table1Pos++;
                }
                // Exclude duplication.
                else if (table1[table1Pos] == table2[table2Pos])
                {
                    result.Add(table2[table2Pos]);
                    table2Pos++;
                    table1Pos++;
                }
                else
                {
                    result.Add(table2[table2Pos]);
                    table2Pos++;
                }
            }

            return result.ToArray();
        }
    }
}
