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
            PreFetch();
        } else if (id == 0) {
            Items = GetAll().ToList();
            CurrentItem = null;
            NewItem = null;
        } else {
            Items = null;
            PreFetch();
            CurrentItem = GetAll().FirstOrDefault(x => x.Id == id);
            PostFetch();
            NewItem = null;
        }
    }

    public virtual IQueryable<T> GetAll() => _context.Set<T>();

    public virtual void PreSave() {
        
    }

    public virtual void PreFetch() {

    }

    public virtual void PostFetch() {

    }

    public virtual IActionResult OnPost() {
        if (NewItem != null && NewItem.Id == -1) {
            NewItem.Id = 0;
            PreSave();
            _context.Set<T>().Add(NewItem);
        } else if (CurrentItem != null) {
            var entity = _context.Set<T>().FirstOrDefault(x => x.Id == CurrentItem.Id);
            if (entity != null) {
                PreSave();
                entity.Copy(CurrentItem);
            }
        }

        _context.SaveChanges();
        return RedirectToPage(new { id = 0 });
    }
}
