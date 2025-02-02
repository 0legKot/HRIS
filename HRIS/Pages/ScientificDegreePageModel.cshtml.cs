using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HRIS.Pages {
    public class ScientificDegreePageModel : CrudPageModel<ScientificDegree> {
        public ScientificDegreePageModel(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {}
    }
}
