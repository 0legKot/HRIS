using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

public class Specialty : Entity {
    [Display(Name = "Шифр")]
    public int? Chiper { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "Спецiальнiсть")]
    public string SpecialtyName { get; set; } = null!;

    public override void Copy(Entity entity) {
        var copy = entity as Specialty;
        if (copy != null) {
            Chiper = copy.Chiper;
            SpecialtyName = copy.SpecialtyName;
        }
    }
}
