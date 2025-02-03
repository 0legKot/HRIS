using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace HRIS.Pages {
    public class JobChangePageModel : CrudPageModel<JobChangeOrder> {
        [BindProperty]
        [Display(Name = "Спiвробiтник")]
        public int SelectedEmployeeId { get; set; }
        [BindProperty]
        [Display(Name = "Позицiя")]
        public int SelectedNewPositionId { get; set; }
        [BindProperty]
        [Display(Name = "Пiдроздiл")]
        public int SelectedNewUnitId { get; set; }
        public List<SelectListItem> Employees { get; set; }
        public List<SelectListItem> Positions { get; set; }
        public List<SelectListItem> Units { get; set; }

        public JobChangePageModel(ApplicationDbContext context) : base(context) { }

        public override IQueryable<JobChangeOrder> GetAll() =>
            _context.Set<JobChangeOrder>()
                .Include(j => j.Employee).ThenInclude(e => e.EmployeePerson)
                .Include(j => j.NewPosition)
                .Include(j => j.NewUnit);

        public override void PreFetch() {
            Employees = _context.Employees.Include(e => e.EmployeePerson)
                .Select(e => new SelectListItem {
                    Value = e.Id.ToString(),
                    Text = e.EmployeePerson.PersonNameFull
                })
                .ToList();
            Positions = _context.Positions
                .Select(p => new SelectListItem {
                    Value = p.Id.ToString(),
                    Text = p.PositionName
                })
                .ToList();
            Units = _context.Units
                .Select(u => new SelectListItem {
                    Value = u.Id.ToString(),
                    Text = u.UnitName
                })
                .ToList();
        }

        public override void PreSave() {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == SelectedEmployeeId);
            employee.PositionId = SelectedNewPositionId;
            employee.UnitId = SelectedNewUnitId;
            NewItem.EmployeeId = SelectedEmployeeId;
            NewItem.NewPositionId = SelectedNewPositionId;
            NewItem.NewUnitId = SelectedNewUnitId;
        }
    }
}
