using HRIS.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace HRIS.Pages {
    public class PersonPageModel : CrudPageModel<Person> {
        [BindProperty]
        [Display(Name = "Факультет")]
        public int SelectedFacultyId { get; set; }
        [BindProperty]
        [Display(Name = "Наукове звання")]
        public int SelectedScientificTitleId { get; set; }
        [BindProperty]
        [Display(Name = "Науковий ступінь")]
        public int SelectedScientificDegreeId { get; set; }
        [BindProperty]
        [Display(Name = "Спеціальність")]
        public int SelectedSpecialtyId { get; set; }

        public List<SelectListItem> Faculties { get; set; }
        public List<SelectListItem> ScientificTitles { get; set; }
        public List<SelectListItem> ScientificDegrees { get; set; }
        public List<SelectListItem> Specialties { get; set; }

        public PersonPageModel(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
        public override IQueryable<Person> GetAll() => _context.Set<Person>().Include(x => x.Faculty).Include(x => x.ScientificTitle).Include(x => x.ScientificDegree).Include(x => x.Specialty);
        public override void PreFetch() {
            Faculties = _context.Faculties.Select(f => new SelectListItem { Value = f.Id.ToString(), Text = f.FacultyName }).ToList(); 
            ScientificTitles = _context.ScientificTitles.Select(st => new SelectListItem { Value = st.Id.ToString(), Text = st.ScientificTitleName }).ToList();
            ScientificDegrees = _context.ScientificDegrees.Select(sd => new SelectListItem { Value = sd.Id.ToString(), Text = sd.ScientificDegreeName }).ToList();
            Specialties = _context.Specialties.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.SpecialtyName }).ToList();
        }
        public override void PreSave() { 
            NewItem.FacultyId = SelectedFacultyId; 
            NewItem.ScientificTitleId = SelectedScientificTitleId; 
            NewItem.ScientificDegreeId = SelectedScientificDegreeId; 
            NewItem.SpecialtyId = SelectedSpecialtyId; 
        }

        public override void PostFetch() {
            SelectedFacultyId = CurrentItem.FacultyId ?? 0;
            SelectedScientificTitleId = CurrentItem.ScientificTitleId ?? 0;
            SelectedScientificDegreeId = CurrentItem.ScientificDegreeId ?? 0;
            SelectedSpecialtyId = CurrentItem.SpecialtyId ?? 0;
        }
    }
}