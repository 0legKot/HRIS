using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRIS.Pages {
    public class UnitsGroupPageModel : CrudPageModel<UnitsGroup> {
        public UnitsGroupPageModel(ApplicationDbContext context) : base(context) { }
        public override IQueryable<UnitsGroup> GetAll() =>
            _context.Set<UnitsGroup>().Include(g => g.Units);
    }
}
