using System.ComponentModel.DataAnnotations;

public class ScientificDegree : Entity {

    [Required]
    [MaxLength(10)]
    [Display(Name = "Освiтнiй рiвень")]
    public string ScientificDegreeName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [Display(Name = "Освiтнiй рiвень (повна назва)")]
    public string ScientificDegreeNameFull { get; set; } = null!;

    public override void Copy(Entity entity) {
        var copy = entity as ScientificDegree;
        if (copy != null) {
            ScientificDegreeName = copy.ScientificDegreeName;
            ScientificDegreeNameFull = copy.ScientificDegreeNameFull;
        }
    }
}
