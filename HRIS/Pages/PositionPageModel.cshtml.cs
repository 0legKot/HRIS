using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HRIS.Pages {
    public class PositionPageModel : CrudPageModel<Position> {
        public PositionPageModel(ApplicationDbContext context) : base(context) { }
    }
}
