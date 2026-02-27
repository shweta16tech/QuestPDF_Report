// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using StudentPDFDemo;
using System.Collections.Generic;
QuestPDF.Settings.License = LicenseType.Community; // free community license
var students = new List<Student>
{
    new Student {ID = 1, Name = "John", Class= "10-A",GPA = 3.8},
    new Student {ID = 2, Name = "Alice", Class= "10-B",GPA = 3.5},
    new Student {ID = 3, Name = "Bob", Class= "10-A",GPA = 3.3},
    new Student {ID = 4, Name = "Carol", Class= "8-A",GPA = 3.45},
    new Student {ID = 5, Name = "Joe", Class= "7-A",GPA = 3.63},

};
var report = new StudentReport(students);
report.GeneratePdf("StudentReport.pdf");
Console.WriteLine("PDF generated successfully !");

