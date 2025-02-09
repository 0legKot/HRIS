using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRIS.Pages {
    public class VnzListPageModel : CrudPageModel<VnzList> {
        public VnzListPageModel(ApplicationDbContext context) : base(context) { }
        public override IQueryable<VnzList> GetAll() =>
            _context.Set<VnzList>().Include(v => v.Faculties);
    }
}
