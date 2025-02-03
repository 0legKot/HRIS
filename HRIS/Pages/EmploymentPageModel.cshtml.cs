using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Pages {
    public class EmploymentPageModel : CrudPageModel<EmploymentOrder> {
        [BindProperty]
        public int SelectedPersonId { get; set; }
        public List<SelectListItem> People { get; set; }
        public int SelectedPositionId { get; set; }
        public List<SelectListItem> Positions { get; set; }
        public int SelectedUnitId { get; set; }
        public List<SelectListItem> Units { get; set; }
        public EmploymentPageModel(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {}

        public override IQueryable<EmploymentOrder> GetAll() => _context.Set<EmploymentOrder>()
            .Include(x => x.Person)
            .Include(x => x.Position)
            .Include(x => x.Unit);

        public override void PreFetch() {
            People = _context.Persons
            .Select(e => new SelectListItem {
                Value = e.Id.ToString(),
                Text = e.PersonNameFull
            })
            .ToList();
            Positions = _context.Positions
            .Select(e => new SelectListItem {
                Value = e.Id.ToString(),
                Text = e.PositionName
            })
            .ToList();
            Units = _context.Units
            .Select(e => new SelectListItem {
                Value = e.Id.ToString(),
                Text = e.UnitName
            })
            .ToList();
        }
        public override void PreSave() {
            NewItem.PersonId = SelectedPersonId;
            NewItem.PositionId = SelectedPositionId;
            NewItem.UnitId = SelectedUnitId;
            _context.Employees.Add(new Employee() {
                DateEmployment = NewItem.EmploymentDate,
                EmployeePersonId = SelectedPersonId,
                PositionId = SelectedPositionId,
                UnitId = SelectedUnitId,
                EmployeeWorkingRate = NewItem.WorkingRates
            });
        }
    }
}
