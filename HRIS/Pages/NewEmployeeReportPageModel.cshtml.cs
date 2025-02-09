﻿using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS.Pages {
    public class NewEmployeeReportPageModel : PageModel {
        private readonly ApplicationDbContext _context;
        public NewEmployeeReportPageModel(ApplicationDbContext context) {
            _context = context;
        }

        [BindProperty]
        public string SearchCriteria { get; set; } = string.Empty;

        [BindProperty]
        public DateTime? StartDate { get; set; }

        [BindProperty]
        public DateTime? ReportDate { get; set; }

        public void OnGet() {
            SearchCriteria = string.Empty;
            StartDate = new DateTime(DateTime.Now.Year, 1, 1);
            ReportDate = DateTime.Now;
        }

        public async Task<IActionResult> OnPost() {
            var employees = _context.Employees
                .Include(e => e.EmployeePerson)
                .Include(e => e.Position)
                .Include(e => e.Unit)
                .Where(e =>
                    (string.IsNullOrWhiteSpace(SearchCriteria) ||
                     e.EmployeePerson.PersonNameFull.ToUpper().Contains(SearchCriteria.ToUpper()))
                    && e.DateEmployment != null
                    && (!StartDate.HasValue || e.DateEmployment >= StartDate)
                    && (!ReportDate.HasValue || e.DateEmployment <= ReportDate))
                .ToList();

            string html = @"<html>
<head>
  <meta charset='utf-8'>
  <style>
    body { font-family: Arial, sans-serif; margin: 20px; }
    table { width: 100%; border-collapse: collapse; margin: 20px 0; }
    table, th, td { border: 1px solid #dddddd; }
    th, td { text-align: left; padding: 12px; }
    th { background-color: #4CAF50; color: white; }
    tr:nth-child(even) { background-color: #f2f2f2; }
  </style>
</head>
<body>
<div>
  <table>
    <tr>
      <th>ПІБ</th>
      <th>Посада</th>
      <th>Підрозділ</th>
      <th>Дата прийняття</th>
    </tr>";

            foreach (var employee in employees) {
                html += "<tr>";
                html += $"<td>{employee.EmployeePerson.PersonName}</td>";
                html += $"<td>{employee.Position.PositionName}</td>";
                html += $"<td>{employee.Unit.UnitName}</td>";
                html += $"<td>{employee.DateEmployment?.ToString("dd.MM.yyyy")}</td>";
                html += "</tr>";
            }

            html += @"
  </table>
</div>
</body>
</html>";

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            await page.SetContentAsync(html);
            var pdfBytes = await page.PdfAsync(new PagePdfOptions { Format = "A4" });
            return new FileContentResult(pdfBytes, "application/pdf") {
                FileDownloadName = $"NewEmployeeReport_{DateTime.Now:yyyy_MM_dd}.pdf"
            };
        }
    }
}
