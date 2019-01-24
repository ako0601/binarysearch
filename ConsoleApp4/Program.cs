using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = 0;
            int nn;
            BS a;
            Employee[] employees;
            int[] num;
            double average;
            string filename;
            string query;



            // catch missing arguments error.
            try
            {
                filename = args[0];
                query = args[1];

                // catch file not found exception.
                try
                {
                    var sr = new StreamReader(filename);
                    var sr2 = new StreamReader(query);
                    nn = int.Parse(sr2.ReadLine());
                    n = int.Parse(sr.ReadLine());
                    employees = new Employee[n];
                    num = new int[nn];
                    a = new BS();
                    average = 0;

                    // reading Employee information by for loop
                    for (int i = 0; i < n; i++)
                    {
                        string nextLine = sr.ReadLine();
                        employees[i] = new Employee(nextLine);
                    }

                    // reading query
                    for (int i = 0; i < nn; i++)
                    {
                        int nl = int.Parse(sr2.ReadLine());
                        num[i] = nl;
                    }

                    
                    //sequential search
                    foreach (int j in num)
                    {
                        var result = a.BinarySearch(j, employees, 0, employees.Count());                        
                        Console.WriteLine("Looking for " + j + " ... Found " + employees[result.Item1].name + " at position " + result.Item1 + " after " + result.Item2 + " comparisons.");
                        average += result.Item2;                        
                                               
                    }

                    Console.WriteLine("Average number of comparisons overall : " + average / nn);

                    sr2.Close();
                    sr.Close();
                }
                catch (FileNotFoundException e)
                {
                    Console.WriteLine("File has not found.");
                }
            }
            catch (IndexOutOfRangeException a)
            {
                Console.WriteLine("Missing argument line");
            }

        }
    }

    class Employee
    {
        public string name;
        public int id;
        private int age;
        private string job;
        private int year;

        public Employee(string data)
        {
            string[] fields = data.Split('|');
            name = fields[0];
            id = int.Parse(fields[1]);
            age = int.Parse(fields[2]);
            job = fields[3];
            year = int.Parse(fields[4]);
        }
    }

    class BS
    {
        public Tuple<int, int > BinarySearch(int value, Employee[] T, int start, int end)
        {
            int count = 0;
            int low = start;
            int high = end;

            while (low < high)
            {                
                int mid = (low + high) / 2;

                if (value <= T[mid].id)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }

                count++;
            }
            var tuple = new Tuple<int, int>(high, count);
            return tuple;
        }
    }
}






