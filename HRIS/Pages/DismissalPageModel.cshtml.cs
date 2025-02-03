using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Pages {
    public class DismissalPageModel : CrudPageModel<DismissalOrder> {
        [BindProperty]
        public int SelectedEmployeeId { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public DismissalPageModel(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {}

        public override IQueryable<DismissalOrder> GetAll() => _context.Set<DismissalOrder>().Include(x => x.Employee).ThenInclude(x => x.EmployeePerson);

        public override void PreFetch() {
            Employees = _context.Employees.Include(x => x.EmployeePerson)
            .Select(e => new SelectListItem {
                Value = e.Id.ToString(),
                Text = e.EmployeePerson!.PersonNameFull
            })
            .ToList();
        }
        public override void PreSave() {
            NewItem.EmployeeId = SelectedEmployeeId;
            var employee = _context.Employees.FirstOrDefault(x=>x.Id ==  SelectedEmployeeId);
            employee.DateDismissal = NewItem.DismissalDate;
        }
    }
}
