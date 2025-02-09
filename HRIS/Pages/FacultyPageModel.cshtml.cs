using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRIS.Pages {
    public class FacultyPageModel : CrudPageModel<Faculty> {
        [BindProperty]
        public int SelectedVnzId { get; set; }
        public List<SelectListItem> VnzList { get; set; }

        public FacultyPageModel(ApplicationDbContext context) : base(context) { }

        public override IQueryable<Faculty> GetAll() =>
            _context.Set<Faculty>().Include(x => x.Vnz);

        public override void PreFetch() {
            VnzList = _context.VnzLists
                .Select(v => new SelectListItem { Value = v.Id.ToString(), Text = v.VnzNameFull })
                .ToList();
        }

        public override void PreSave() {
            if (NewItem != null) {
                NewItem.VnzId = SelectedVnzId;
            }
            if (CurrentItem != null) {
                CurrentItem.VnzId = SelectedVnzId;
            }
        }
    }
}
