using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Pages {
    public class EmployeesPageModel : CrudPageModel<Employee> {
        public EmployeesPageModel(ApplicationDbContext applicationDbContext) : base(applicationDbContext) {}
        public override IQueryable<Employee> GetAll() => _context.Set<Employee>()
            .Include(x => x.EmployeePerson)
            .Include(x => x.Position)
            .Include(x => x.Unit);
    }
}
