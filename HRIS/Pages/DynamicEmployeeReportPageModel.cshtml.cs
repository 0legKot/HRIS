using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Playwright;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRIS.Pages {
    public class DynamicEmployeeReportPageModel : PageModel {
        private readonly ApplicationDbContext _context;
        public DynamicEmployeeReportPageModel(ApplicationDbContext context) {
            _context = context;
        }

        [BindProperty]
        public string FilterPib { get; set; } = string.Empty;
        [BindProperty]
        public string FilterFullName { get; set; } = string.Empty;
        [BindProperty]
        public DateTime? FilterBirthDateFrom { get; set; }
        [BindProperty]
        public DateTime? FilterBirthDateTo { get; set; }
        [BindProperty]
        public string FilterResidence { get; set; } = string.Empty;
        [BindProperty]
        public string FilterPhone { get; set; } = string.Empty;
        [BindProperty]
        public string FilterPosition { get; set; } = string.Empty;
        [BindProperty]
        public string FilterUnit { get; set; } = string.Empty;
        [BindProperty]
        public DateTime? FilterDateEmploymentFrom { get; set; }
        [BindProperty]
        public DateTime? FilterDateEmploymentTo { get; set; }
        [BindProperty]
        public DateTime? FilterDateDismissalFrom { get; set; }
        [BindProperty]
        public DateTime? FilterDateDismissalTo { get; set; }
        [BindProperty]
        public decimal? FilterWorkingRateMin { get; set; }
        [BindProperty]
        public decimal? FilterWorkingRateMax { get; set; }


        [BindProperty]
        public bool IncludePib { get; set; }
        [BindProperty]
        public bool IncludeFullName { get; set; }
        [BindProperty]
        public bool IncludeBirthDate { get; set; }
        [BindProperty]
        public bool IncludeResidence { get; set; }
        [BindProperty]
        public bool IncludePhone { get; set; }


        [BindProperty]
        public bool IncludePosition { get; set; }
        [BindProperty]
        public bool IncludeUnit { get; set; }
        [BindProperty]
        public bool IncludeDateEmployment { get; set; }
        [BindProperty]
        public bool IncludeDateDismissal { get; set; }
        [BindProperty]
        public bool IncludeWorkingRate { get; set; }

        
        [BindProperty]
        public bool IncludeIdentificationNumber { get; set; }
        [BindProperty]
        public bool IncludePassportNumber { get; set; }
        [BindProperty]
        public bool IncludePassportSeries { get; set; }
        [BindProperty]
        public bool IncludePassportIssueDate { get; set; }
        [BindProperty]
        public bool IncludePassportIssuePlace { get; set; }

        
        [BindProperty]
        public bool IncludePersonEducation { get; set; }
        [BindProperty]
        public bool IncludePersonQualification { get; set; }
        [BindProperty]
        public bool IncludeDiplomaNumber { get; set; }
        [BindProperty]
        public bool IncludeDateOfGraduation { get; set; }
        [BindProperty]
        public bool IncludeCategory { get; set; }
        [BindProperty]
        public bool IncludeIsMale { get; set; }
        [BindProperty]
        public bool IncludeDischarge { get; set; }
        [BindProperty]
        public bool IncludeFaculty { get; set; }
        [BindProperty]
        public bool IncludeScientificTitle { get; set; }
        [BindProperty]
        public bool IncludeScientificDegree { get; set; }
        [BindProperty]
        public bool IncludeSpecialty { get; set; }

        public void OnGet() {
            FilterPib = string.Empty;
            FilterFullName = string.Empty;
            FilterResidence = string.Empty;
            FilterPhone = string.Empty;
            FilterPosition = string.Empty;
            FilterUnit = string.Empty;

            IncludePib = true;
            IncludeFullName = false;
            IncludeBirthDate = false;
            IncludeResidence = false;
            IncludePhone = false;
            IncludePosition = true;
            IncludeUnit = true;
            IncludeDateEmployment = true;
            IncludeDateDismissal = false;
            IncludeWorkingRate = true;

            IncludeIdentificationNumber = false;
            IncludePassportNumber = false;
            IncludePassportSeries = false;
            IncludePassportIssueDate = false;
            IncludePassportIssuePlace = false;

            IncludePersonEducation = false;
            IncludePersonQualification = false;
            IncludeDiplomaNumber = false;
            IncludeDateOfGraduation = false;
            IncludeCategory = false;
            IncludeDischarge = false;
            IncludeFaculty = false;
            IncludeScientificTitle = false;
            IncludeScientificDegree = false;
            IncludeSpecialty = false;
        }

        public async Task<IActionResult> OnPost() {
            var query = _context.Employees
                .Include(e => e.EmployeePerson)
                    .ThenInclude(p => p.Faculty)
                    .ThenInclude(x=>x.Vnz)
                .Include(e => e.EmployeePerson)
                    .ThenInclude(p => p.ScientificTitle)
                .Include(e => e.EmployeePerson)
                    .ThenInclude(p => p.ScientificDegree)
                .Include(e => e.EmployeePerson)
                    .ThenInclude(p => p.Specialty)
                .Include(e => e.Position)
                .Include(e => e.Unit)
                    .ThenInclude(u => u.Group)
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(FilterPib))
                query = query.Where(e => e.EmployeePerson.PersonName.ToUpper().Contains(FilterPib.ToUpper()));
            if (!string.IsNullOrWhiteSpace(FilterFullName))
                query = query.Where(e => e.EmployeePerson.PersonNameFull.ToUpper().Contains(FilterFullName.ToUpper()));
            if (FilterBirthDateFrom.HasValue)
                query = query.Where(e => e.EmployeePerson.BirthDate >= FilterBirthDateFrom.Value);
            if (FilterBirthDateTo.HasValue)
                query = query.Where(e => e.EmployeePerson.BirthDate <= FilterBirthDateTo.Value);
            if (!string.IsNullOrWhiteSpace(FilterResidence))
                query = query.Where(e => e.EmployeePerson.Residence.ToUpper().Contains(FilterResidence.ToUpper()));
            if (!string.IsNullOrWhiteSpace(FilterPhone))
                query = query.Where(e => e.EmployeePerson.PhoneNumber.Contains(FilterPhone));
            if (!string.IsNullOrWhiteSpace(FilterPosition))
                query = query.Where(e => e.Position.PositionName.ToUpper().Contains(FilterPosition.ToUpper()));
            if (!string.IsNullOrWhiteSpace(FilterUnit))
                query = query.Where(e => e.Unit.UnitName.ToUpper().Contains(FilterUnit.ToUpper()));
            if (FilterDateEmploymentFrom.HasValue)
                query = query.Where(e => e.DateEmployment >= FilterDateEmploymentFrom.Value);
            if (FilterDateEmploymentTo.HasValue)
                query = query.Where(e => e.DateEmployment <= FilterDateEmploymentTo.Value);
            if (FilterDateDismissalFrom.HasValue)
                query = query.Where(e => e.DateDismissal >= FilterDateDismissalFrom.Value);
            if (FilterDateDismissalTo.HasValue)
                query = query.Where(e => e.DateDismissal <= FilterDateDismissalTo.Value);
            if (FilterWorkingRateMin.HasValue)
                query = query.Where(e => e.EmployeeWorkingRate >= FilterWorkingRateMin.Value);
            if (FilterWorkingRateMax.HasValue)
                query = query.Where(e => e.EmployeeWorkingRate <= FilterWorkingRateMax.Value);

            var employees = query.ToList();

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
    <tr>";
            if (IncludePib)
                html += "<th>ПІБ</th>";
            if (IncludeFullName)
                html += "<th>Повне ім'я</th>";
            if (IncludeIsMale)
                html += "<th>Чоловiк?</th>";
            if (IncludeBirthDate)
                html += "<th>Дата народження</th>";
            if (IncludeResidence)
                html += "<th>Місце проживання</th>";
            if (IncludePhone)
                html += "<th>Телефон</th>";
            if (IncludePosition)
                html += "<th>Посада</th>";
            if (IncludeUnit)
                html += "<th>Підрозділ</th>";
            if (IncludeDateEmployment)
                html += "<th>Дата прийняття</th>";
            if (IncludeDateDismissal)
                html += "<th>Дата звільнення</th>";
            if (IncludeWorkingRate)
                html += "<th>Зарплатний коефіцієнт</th>";
            if (IncludeIdentificationNumber)
                html += "<th>Ідентифікаційний номер</th>";
            if (IncludePassportNumber)
                html += "<th>Номер паспорта</th>";
            if (IncludePassportSeries)
                html += "<th>Серія паспорта</th>";
            if (IncludePassportIssueDate)
                html += "<th>Дата видачі паспорта</th>";
            if (IncludePassportIssuePlace)
                html += "<th>Місце видачі паспорта</th>";
            if (IncludePersonEducation)
                html += "<th>Освіта</th>";
            if (IncludePersonQualification)
                html += "<th>Кваліфікація</th>";
            if (IncludeDiplomaNumber)
                html += "<th>Номер диплома</th>";
            if (IncludeDateOfGraduation)
                html += "<th>Дата закінчення</th>";
            if (IncludeCategory)
                html += "<th>Категорія</th>";
            if (IncludeDischarge)
                html += "<th>Розряд</th>";
            if (IncludeFaculty)
                html += "<th>Факультет</th>";
            if (IncludeScientificTitle)
                html += "<th>Наукове звання</th>";
            if (IncludeScientificDegree)
                html += "<th>Науковий ступінь</th>";
            if (IncludeSpecialty)
                html += "<th>Спеціальність</th>";
            html += "</tr>";
            foreach (var emp in employees) {
                html += "<tr>";
                if (IncludePib)
                    html += $"<td>{emp.EmployeePerson.PersonName}</td>";
                if (IncludeFullName)
                    html += $"<td>{emp.EmployeePerson.PersonNameFull}</td>";
                if (IncludeIsMale) {
                    var tmp = emp.EmployeePerson.IsMale ? "Так" : "Нi";
                    html += $"<td>{tmp}</td>";
                }
                if (IncludeBirthDate)
                    html += $"<td>{emp.EmployeePerson.BirthDate.ToString("dd.MM.yyyy")}</td>";
                if (IncludeResidence)
                    html += $"<td>{emp.EmployeePerson.Residence}</td>";
                if (IncludePhone)
                    html += $"<td>{emp.EmployeePerson.PhoneNumber}</td>";
                if (IncludePosition)
                    html += $"<td>{emp.Position.PositionName}</td>";
                if (IncludeUnit)
                    html += $"<td>{emp.Unit.UnitName}</td>";
                if (IncludeDateEmployment)
                    html += $"<td>{emp.DateEmployment?.ToString("dd.MM.yyyy")}</td>";
                if (IncludeDateDismissal)
                    html += $"<td>{emp.DateDismissal?.ToString("dd.MM.yyyy")}</td>";
                if (IncludeWorkingRate)
                    html += $"<td>{emp.EmployeeWorkingRate}</td>";
                if (IncludeIdentificationNumber)
                    html += $"<td>{emp.EmployeePerson.IdentificationNumber}</td>";
                if (IncludePassportNumber)
                    html += $"<td>{emp.EmployeePerson.PassportNumber}</td>";
                if (IncludePassportSeries)
                    html += $"<td>{emp.EmployeePerson.PassportSeries}</td>";
                if (IncludePassportIssueDate)
                    html += $"<td>{emp.EmployeePerson.PassportIssueDate.ToString("dd.MM.yyyy")}</td>";
                if (IncludePassportIssuePlace)
                    html += $"<td>{emp.EmployeePerson.PassportIssuePlace}</td>";
                if (IncludePersonEducation)
                    html += $"<td>{emp.EmployeePerson.PersonEducation}</td>";
                if (IncludePersonQualification)
                    html += $"<td>{emp.EmployeePerson.PersonQualification}</td>";
                if (IncludeDiplomaNumber)
                    html += $"<td>{emp.EmployeePerson.DiplomaNumber}</td>";
                if (IncludeDateOfGraduation)
                    html += $"<td>{emp.EmployeePerson.DateOfGraduation?.ToString("dd.MM.yyyy")}</td>";
                if (IncludeCategory)
                    html += $"<td>{emp.EmployeePerson.Category}</td>";
                if (IncludeDischarge)
                    html += $"<td>{emp.EmployeePerson.Discharge}</td>";
                if (IncludeFaculty)
                    html += $"<td>{emp.EmployeePerson.Faculty?.FacultyNameFull}</td>";
                if (IncludeScientificTitle)
                    html += $"<td>{emp.EmployeePerson.ScientificTitle?.ScientificTitleName}</td>";
                if (IncludeScientificDegree)
                    html += $"<td>{emp.EmployeePerson.ScientificDegree?.ScientificDegreeName}</td>";
                if (IncludeSpecialty)
                    html += $"<td>{emp.EmployeePerson.Specialty?.SpecialtyName}</td>";
                html += "</tr>";
            }
            html += @"</table>
</div>
</body>
</html>";

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();
            await page.SetContentAsync(html);
            var pdfBytes = await page.PdfAsync(new PagePdfOptions { Format = "A4" });
            return new FileContentResult(pdfBytes, "application/pdf") {
                FileDownloadName = $"DynamicEmployeeReport_{DateTime.Now:yyyy_MM_dd}.pdf"
            };
        }
    }
}
