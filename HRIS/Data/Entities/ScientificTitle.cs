﻿using System.ComponentModel.DataAnnotations;
public class ScientificTitle : Entity {
    [Required]
    [MaxLength(10)]
    [Display(Name = "Наукове звання")]
    public string ScientificTitleName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [Display(Name = "Наукове звання (повна назва)")]
    public string ScientificTitleNameFull { get; set; } = null!;

    public override void Copy(Entity entity) {
        var copy = entity as ScientificTitle;
        if (copy != null) {
            ScientificTitleName = copy.ScientificTitleName;
            ScientificTitleNameFull = copy.ScientificTitleNameFull;
        }
    }
}
