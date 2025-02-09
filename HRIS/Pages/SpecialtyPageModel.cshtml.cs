using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace HRIS.Pages {
    public class SpecialtyPageModel : CrudPageModel<Specialty> {
        public SpecialtyPageModel(ApplicationDbContext context) : base(context) { }
    }
}
