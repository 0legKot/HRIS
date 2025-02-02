using System.ComponentModel.DataAnnotations;

public class ScientificDegree : Entity {

    [Required]
    [MaxLength(10)]
    public string ScientificDegreeName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string ScientificDegreeNameFull { get; set; } = null!;

    public override void Copy(Entity entity) {
        var copy = entity as ScientificDegree;
        if (copy != null) {
            ScientificDegreeName = copy.ScientificDegreeName;
            ScientificDegreeNameFull = copy.ScientificDegreeNameFull;
        }
    }
}
