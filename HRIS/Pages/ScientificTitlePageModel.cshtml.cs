using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace HRIS.Pages {
    public class ScientificTitlePageModel : CrudPageModel<ScientificTitle> {
        public ScientificTitlePageModel(ApplicationDbContext context) : base(context) { }
    }
}
