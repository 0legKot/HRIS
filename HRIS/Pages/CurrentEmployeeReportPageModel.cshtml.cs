using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;

namespace HRIS.Pages {
    public class CurrentEmployeeReportPageModel : PageModel {
        ApplicationDbContext context;
        [BindProperty]
        public string SearchCriteria { get; set; }
        public CurrentEmployeeReportPageModel(ApplicationDbContext applicationDbContext) {
            context = applicationDbContext;
        }
       
        public void OnGet() {
            SearchCriteria = "";
        }

        public async Task<IActionResult> OnPost() {
            List<Employee> employees = context.Employees
                .Include(x => x.EmployeePerson)
                .Include(x => x.Position)
                .Include(x => x.Unit)
                .Where(x => string.IsNullOrWhiteSpace(SearchCriteria) || x.EmployeePerson.PersonNameFull.ToUpper().Contains(SearchCriteria.ToUpper()))
                .ToList();
            string s = @"<html>
<head>
  <meta charset='utf-8'>
  <style>
    body {
      font-family: Arial, sans-serif;
      margin: 20px;
    }
    table {
      width: 100%;
      border-collapse: collapse;
      margin: 20px 0;
    }
    table, th, td {
      border: 1px solid #dddddd;
    }
    th, td {
      text-align: left;
      padding: 12px;
    }
    th {
      background-color: #4CAF50;
      color: white;
    }
    tr:nth-child(even) {
      background-color: #f2f2f2;
    }
  </style>
</head>
<body>
<div>
  <table>
    <tr>
      <th>ПІБ</th>
      <th>Посада</th>
      <th>Підрозділ</th>
    </tr>";

            foreach (var employee in employees) {
                s += "<tr>";
                s += $"<td>{employee.EmployeePerson.PersonName}</td>";
                s += $"<td>{employee.Position.PositionName}</td>";
                s += $"<td>{employee.Unit.UnitName}</td>";
                s += "</tr>";
            }

            s += @"
  </table>
</div>
</body>
</html>";
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {
                Headless = true
            });
            var page = await browser.NewPageAsync();
            await page.SetContentAsync(s);
            var pdfBytes = await page.PdfAsync(new PagePdfOptions { Format = "A4" });
            return new FileContentResult(pdfBytes, "application/pdf") {
                FileDownloadName = $"EmployeeReport_{DateTime.Now:yyyy_MM_dd}.pdf"
            };
        }
    }
}
