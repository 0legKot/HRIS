using System.ComponentModel.DataAnnotations;
public class Unit : Entity {

    [Required]
    [MaxLength(20)]
    [Display(Name = "Назва пiдроздiлу")]
    public string UnitName { get; set; } = null!;

    public int GroupId { get; set; }

    public UnitsGroup? Group { get; set; }

    [Display(Name = "Розклади")]
    public ICollection<StaffSchedule>? StaffSchedules { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as Unit;
        if (copy != null) {
            UnitName = copy.UnitName;
            GroupId = copy.GroupId;
            StaffSchedules ??= [];
            StaffSchedules.Clear();
            foreach (var item in copy.StaffSchedules ?? []) {
                StaffSchedules.Add(item);
            }
        }
    }
}
