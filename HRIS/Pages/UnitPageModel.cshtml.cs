using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRIS.Pages {
    public class UnitPageModel : CrudPageModel<Unit> {
        [BindProperty]
        public int SelectedGroupId { get; set; }
        public List<SelectListItem> Groups { get; set; }

        public UnitPageModel(ApplicationDbContext context) : base(context) { }

        public override IQueryable<Unit> GetAll() =>
            _context.Set<Unit>()
                .Include(u => u.Group);

        public override void PreFetch() {
            Groups = _context.UnitsGroups
                .Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.UnitsGroupName })
                .ToList();
        }

        public override void PreSave() {
            if (NewItem != null) {
                NewItem.GroupId = SelectedGroupId;
            }
            if (CurrentItem != null) {
                CurrentItem.GroupId = SelectedGroupId;
            }
        }
    }
}
