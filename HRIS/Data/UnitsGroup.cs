﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
public class UnitsGroup : Entity {

    [Required]
    [MaxLength(20)]
    public string UnitsGroupName { get; set; } = null!;

    public ICollection<Unit>? Units { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as UnitsGroup;
        if (copy != null) {
            UnitsGroupName = copy.UnitsGroupName;
            Units ??= [];
            Units.Clear();
            foreach (var item in copy.Units ?? []) {
                Units.Add(item);
            }
        }
    }
}
