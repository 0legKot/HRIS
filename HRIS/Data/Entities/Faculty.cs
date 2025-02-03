using System.ComponentModel.DataAnnotations;

public class Faculty : Entity {

    [Required]
    [MaxLength(20)]
    [Display(Name = "Факультет")]
    public string FacultyName { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    [Display(Name = "Факультет (повна назва)")]
    public string FacultyNameFull { get; set; } = null!;

    public int VnzId { get; set; }

    public VnzList? Vnz { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as Faculty;
        if (copy != null) {
            FacultyName = copy.FacultyName;
            FacultyNameFull = copy.FacultyNameFull;
            VnzId = copy.VnzId;
        }
    }
}
