using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    public enum ReportOutputFormatType
    {
        NameFirst,
        SalaryFirst
    }

    internal class ReportGenerator
    {
        private readonly ReportDataFetcher _reportDataFetcher;
        
        private ReportOutputFormatType _currentOutputFormat;

        public ReportGenerator(EmployeeDB employeeDb)
        {
            _reportDataFetcher = new ReportDataFetcher(employeeDb);
        }

        public void CompileReport()
        {
            var employees = _reportDataFetcher.FetchData();
            ReportPrinter reportPrinter = new ReportPrinter(employees);
            reportPrinter.CurrentOutputFormat = _currentOutputFormat;
            reportPrinter.Print();
        }


        public void SetOutputFormat(ReportOutputFormatType format)
        {
            _currentOutputFormat = format;
        }
    }
}