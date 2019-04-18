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
        public static IEnumerable<Barcelona1> UnionAll(this List<Barcelona1> table1, List<Barcelona1> table2)
        {
            table1.AddRange(table2);
            return table1;
        }

        public static IEnumerable<Barcelona1> Union(this List<Barcelona1> table1, List<Barcelona1> table2)
        {
            //List<Barcelona1> result = new List<Barcelona1>();
            int totalLength = table1.Count + table2.Count;

            int table1Pos = 0;
            int table2Pos = 0;
            for (int position = 0; position < totalLength && table1Pos+table2Pos < totalLength; position++)
            {
                if (table1Pos > table1.Count - 1)
                {
                    yield return table2[table2Pos];
                    table2Pos++;
                }
                else if (table2Pos > table2.Count - 1)
                {
                    yield return table1[table1Pos];
                    table1Pos++;
                }
                else if (table1[table1Pos] < table2[table2Pos])
                {
                    yield return table1[table1Pos];
                    table1Pos++;
                }
                // Exclude duplication.
                else if (table1[table1Pos] == table2[table2Pos])
                {
                    yield return table2[table2Pos];
                    table2Pos++;
                    table1Pos++;
                }
                else
                {
                    yield return table2[table2Pos];
                    table2Pos++;
                }
            }

           // return result.ToArray();
        }
    }
}
