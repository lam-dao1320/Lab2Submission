using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Lab2Submission;

// Create a lists from supplied file
List<Employee> employeeList = new List<Employee>();
const string PATH = @"..\..\..\res\employees.txt";
const char sep = ':';
StreamReader sr = new StreamReader(PATH);
string line;
string[] info;
while (!sr.EndOfStream)
{
    line = sr.ReadLine() ?? "";
    info = line.Split(sep);
    Employee emp = null;
    switch (info[0][0])
    {
        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
            emp = new Salaried(info[0].Trim(), info[1].Trim(), info[2].Trim(), info[3].Trim(), info[4].Trim(), info[7].Trim());
            break;
        case '5':
        case '6':
        case '7':
            emp = new Wages(info[0].Trim(), info[1].Trim(), info[2].Trim(), info[3].Trim(), info[4].Trim(), info[7].Trim(), info[8].Trim());
            break;
        case '8':
        case '9':
            emp = new PartTime(info[0].Trim(), info[1].Trim(), info[2].Trim(), info[3].Trim(), info[4].Trim(), info[7].Trim(), info[8].Trim());
            break;
    }
    employeeList.Add(emp!);
}
sr.Close();

// Calculate the average weekly pay
double total = 0;
foreach (Employee employee in employeeList)
{
    total += employee.CalculatePay();
}
double average = total / employeeList.Count;
Console.WriteLine($"The average weekly pay for all employees is: {average.ToString("f2")}");

// The highest weekly pay for wage employees
double highest = 0;
string highestName = "";
string getType;
foreach (Employee employee in employeeList)
{
    getType = employee.GetType().ToString();
    if (getType == "Lab2Submission.Wages")
    {
        highest = employee.CalculatePay();
        highestName = employee.Name;
        
    }
}
foreach (Employee employee in employeeList)
{
    getType = employee.GetType().ToString();
    if ((employee.CalculatePay() > highest) && (getType == "Lab2Submission.Wages"))
    {
        highest = employee.CalculatePay();
        highestName = employee.Name;          
    }
}
Console.WriteLine($"The highest weekly pay for the wage employees is {highest.ToString("f2")} - {highestName}");

// The lowest weekly pay for the salaried employees
double lowest = 0;
string lowestName = "";
foreach (Employee employee in employeeList)
{
    getType = employee.GetType().ToString();
    if (getType == "Lab2Submission.Salaried")
    {
        lowest = employee.CalculatePay();
        lowestName = employee.Name;
    }
}
foreach (Employee employee in employeeList)
{
    getType = employee.GetType().ToString();
    if ((employee.CalculatePay() < lowest) && (getType == "Lab2Submission.Salaried"))
    {
        lowest = employee.CalculatePay();
        lowestName = employee.Name;             
    }
}
Console.WriteLine($"The lowest salary for the salaried employees {lowest.ToString("f2")} - {lowestName}");

// Percentage of each employee category
double countSalaried = 0;
double countWages = 0;
double countPartTime = 0;
foreach (Employee employee in employeeList)
{
    getType = employee.GetType().ToString();
    switch (getType)
    {
        case "Lab2Submission.Salaried":
            countSalaried++; break;
        case "Lab2Submission.Wages":
            countWages++; break;
        case "Lab2Submission.PartTime":
            countPartTime++; break;
    }
}
Console.WriteLine($"Percentage of Salaried: {(countSalaried * 100 / employeeList.Count).ToString("f2")}%");
Console.WriteLine($"Percentage of Wages   : {(countWages * 100 / employeeList.Count).ToString("f2")}%");
Console.WriteLine($"Percentage of PartTime: {(countPartTime * 100 / employeeList.Count).ToString("f2")}%");