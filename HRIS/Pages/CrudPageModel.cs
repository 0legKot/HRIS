using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRIS.Data;
using System.Linq;

public abstract class CrudPageModel<T> : PageModel where T : Entity, new() {
    protected readonly ApplicationDbContext _context;

    public List<T>? Items { get; set; }
    [BindProperty]
    public T? CurrentItem { get; set; }
    [BindProperty]
    public T? NewItem { get; set; }

    public CrudPageModel(ApplicationDbContext context) {
        _context = context;
    }

    public virtual void OnGet(int id) {
        if (id == -1) {
            Items = null;
            CurrentItem = null;
            NewItem = new T();
        } else if (id == 0) {
            Items = _context.Set<T>().ToList();
            CurrentItem = null;
            NewItem = null;
        } else {
            Items = null;
            CurrentItem = _context.Set<T>().FirstOrDefault(x => x.Id == id);
            NewItem = null;
        }
    }

    public virtual IActionResult OnPost() {
        if (NewItem != null && NewItem.Id == -1) {
            NewItem.Id = 0;
            _context.Set<T>().Add(NewItem);
        } else if (CurrentItem != null) {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == CurrentItem.Id);
            if (entity != null) {
                entity.Copy(CurrentItem);
            }
        }

        _context.SaveChanges();
        return RedirectToPage(new { id = 0 });
    }
}
