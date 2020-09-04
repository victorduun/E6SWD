using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportGenerator
{
    public class ReportPrinter
    {
        List<Employee> _employees;
        public ReportPrinter(List<Employee> employees)
        {
            _employees = employees;
        }

        public ReportOutputFormatType CurrentOutputFormat { get; set; }

        public void Print()
        {
            // All employees collected - let's output them
            switch (CurrentOutputFormat)
            {
                case ReportOutputFormatType.NameFirst:
                    Console.WriteLine("Name-first report");
                    foreach (var e in _employees)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("Age: {0}", e.Age);
                        Console.WriteLine("------------------");
                    }
                    break;

                case ReportOutputFormatType.SalaryFirst:
                    Console.WriteLine("Salary-first report");
                    foreach (var e in _employees)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("Age: {0}", e.Age);
                        Console.WriteLine("------------------");
                    }
                    break;
                case ReportOutputFormatType.AgeFirst:
                    Console.WriteLine("Age-first report");
                    foreach (var e in _employees)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Age: {0}", e.Age);
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("------------------");
                    }
                    break;
            }
        }
    }
}
