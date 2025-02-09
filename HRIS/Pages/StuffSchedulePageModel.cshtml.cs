using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRIS.Pages {
    public class StuffSchedulePageModel : CrudPageModel<StaffSchedule> {
        public StuffSchedulePageModel(ApplicationDbContext context) : base(context) { }

        [BindProperty]
        public int SelectedUnitId { get; set; }
        [BindProperty]
        public int SelectedPositionId { get; set; }
        public List<SelectListItem> Units { get; set; }
        public List<SelectListItem> Positions { get; set; }



        public override IQueryable<StaffSchedule> GetAll() =>
            _context.Set<StaffSchedule>()
                .Include(s => s.Unit)
                .Include(s => s.Position);

        public override void PreFetch() {
            Units = _context.Units
                .Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.UnitName })
                .ToList();
            Positions = _context.Positions
                .Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.PositionName })
                .ToList();
        }

        public override void PreSave() {
            if (NewItem != null) {
                NewItem.UnitId = SelectedUnitId;
                NewItem.PositionId = SelectedPositionId;
            }
            if (CurrentItem != null) {
                CurrentItem.UnitId = SelectedUnitId;
                CurrentItem.PositionId = SelectedPositionId;
            }
        }
    }
}
