using System;
using System.Collections.Generic;
using System.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using HomeTask3.Entity;

namespace HomeTask3
{
    public class Reader
    {
        public List<Barcelona1> Barcelona1 = new List<Barcelona1>();
        public List<Barcelona1> Barcelona2 = new List<Barcelona1>();

        public void ReadBarcelona1(string fileName)
        {
            List<string[]> dataSource = CsvReader.Parse(fileName);
            foreach (var row in dataSource)
            {
                try
                {
                    Barcelona1.Add(new Barcelona1(row));
                }
                catch (ArgumentException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            Barcelona1.RemoveAt(0);
        }

        public void ReadBarcelona2(string fileName)
        {
            List<string[]> dataSource = CsvReader.Parse(fileName);
            foreach (var row in dataSource)
            {
                try
                {
                    Barcelona2.Add(new Barcelona2(row));
                }
                catch (ArgumentException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            Barcelona2.RemoveAt(0);
        }

        public Reader()
        {
            ReadBarcelona1("Barcelona1.csv");
            ReadBarcelona2("Barcelona2.csv");
        }

        public void CallUnionAll()
        {
            var unionAllResult = Unions.UnionAll(Barcelona1.ToArray(), Barcelona2.ToArray());
            Console.WriteLine(@"Union all total records {0}", unionAllResult.Length);
        }

        public void CallUnion()
        {
            var unionResult = Unions.Union(Barcelona1.ToArray(), Barcelona2.ToArray());
            Console.WriteLine(@"Union total records {0}", unionResult.Length);
        }
    }

    public class Program
    {
        [Benchmark]
        public void UnionOperationTest()
        {

            Reader reader = new Reader();
            reader.CallUnion();
        }

        [Benchmark]
        public void UnionAllOperationTest()
        {

            Reader reader = new Reader();
            reader.CallUnionAll();
        }

        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Program>();
            Console.ReadLine();
        }
    }
}
