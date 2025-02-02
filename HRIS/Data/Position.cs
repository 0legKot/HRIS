using System.ComponentModel.DataAnnotations;

public class Position : Entity {

    [Required]
    [MaxLength(20)]
    public string PositionName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string PositionNameFull { get; set; } = null!;

    public ICollection<StaffSchedule>? StaffSchedules { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as Position;
        if (copy != null) {
            PositionName = copy.PositionName;
            PositionNameFull = copy.PositionNameFull;
            StaffSchedules ??= [];
            StaffSchedules.Clear();
            foreach (var item in copy.StaffSchedules ?? []) {
                StaffSchedules.Add(item);
            }
        }
    }
}

