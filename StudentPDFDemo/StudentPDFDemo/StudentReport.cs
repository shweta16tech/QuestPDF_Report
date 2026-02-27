using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace StudentPDFDemo
{
    public class StudentReport : IDocument
    {
        private List<Student> Students { get; }
        public StudentReport (List<Student> students)
        {
            Students = students;
        }
        public void Compose (IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(20);
                page.DefaultTextStyle(x => x.FontSize(12));

                page.Header()
                    .Text("Student Information Report")
                    .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);
                page.Content()
                    .Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);
                            columns.RelativeColumn(2);
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(4);
                        });
                        table.Header(header =>
                        {
                            header.Cell().Text("ID");
                            header.Cell().Text("Name");
                            header.Cell().Text("Class");
                            header.Cell().Text("GPA");
                        });
                        foreach (var student in Students)
                        {
                            table.Cell().Text(student.ID.ToString());
                            table.Cell().Text(student.Name);
                            table.Cell().Text(student.Class);
                            table.Cell().Text(student.GPA.ToString("F2"));
                        }
                    });
                //page.Footer()
                //    .AlignCenter()
                //    .Text(x => x.CurrentPageNumber() + "/" + x.TotalPages());

            });
        }
    }
}
